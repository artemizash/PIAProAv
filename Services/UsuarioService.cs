using System.Text.RegularExpressions;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Services;

// Aplica las reglas de Usuario antes de llamar al Repository (Service Layer).
public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _repository;
    public UsuarioService(IUsuarioRepository repository) => _repository = repository;

    public List<Usuario> Consultar(string filtro = "") => _repository.GetAll((filtro ?? "").Trim());
    public List<Rol> ConsultarRoles() => _repository.GetRoles();

    // Obtiene el ID real a partir del nombre del rol, no supone que sea 1.
    public int ObtenerIdAdministrador()
    {
        Rol? rol = _repository.GetRoles().FirstOrDefault(r =>
            string.Equals(r.Nombre.Trim(), "Administrador", StringComparison.OrdinalIgnoreCase));
        if (rol is null)
            throw new InvalidOperationException("Falta el rol Administrador en dbo.Rol.");
        return rol.IdRol;
    }

    private static void Validar(Usuario u)
    {
        if (u.IdRol <= 0) throw new ArgumentException("Seleccione un rol.");
        u.Correo = u.Correo.Trim().ToLowerInvariant();
        u.NombreCompleto = u.NombreCompleto.Trim();
        u.NumeroNomina = u.NumeroNomina.Trim();
        Validaciones.Nombre(u.NombreCompleto);
        Validaciones.Correo(u.Correo);
        Validaciones.Obligatorio(u.NumeroNomina,"el número de nómina",20);
        if (!Regex.IsMatch(u.NumeroNomina,@"^[A-Za-z0-9]+$"))
            throw new ArgumentException("La nómina debe ser alfanumérica.");
        Validaciones.Nacimiento(u.FechaNacimiento);
    }

    public void Registrar(Usuario usuario, string contrasena)
    {
        ArgumentNullException.ThrowIfNull(usuario);
        Validar(usuario);
        ContrasenaHelper.Validar(contrasena);
        _repository.Add(usuario, ContrasenaHelper.CrearHash(contrasena));
    }

    public void Actualizar(Usuario usuario, string? contrasenaNueva = null)
    {
        ArgumentNullException.ThrowIfNull(usuario);
        if (usuario.IdUsuario <= 0) throw new ArgumentException("Seleccione un usuario.");
        Validar(usuario);
        // Actualiza los campos de usuario; si se especificó nueva contraseña,
        // verifica que no sea igual a la actual ni a las dos anteriores.
        if (!string.IsNullOrEmpty(contrasenaNueva))
        {
            ContrasenaHelper.Validar(contrasenaNueva);
            List<string> hashes = _repository.GetRecentPasswordHashes(usuario.IdUsuario);
            if (hashes.Count == 0) throw new ArgumentException("El usuario seleccionado ya no existe.");
            if (hashes.Any(h => ContrasenaHelper.Verificar(contrasenaNueva, h)))
                throw new ArgumentException("No puede repetir las últimas 3 contraseñas (actual y dos anteriores).");
        }
        // Evitar quitar el rol al único administrador.
        int idAdministrador = ObtenerIdAdministrador();
        var admins = _repository.GetAll("").Where(u => u.IdRol == idAdministrador).ToList();
        if (admins.Count == 1 && admins[0].IdUsuario == usuario.IdUsuario && usuario.IdRol != idAdministrador)
            throw new ArgumentException("No puede cambiar de rol al único administrador.");
        _repository.Update(usuario);
        if (!string.IsNullOrEmpty(contrasenaNueva))
            _repository.ChangePassword(usuario.IdUsuario, ContrasenaHelper.CrearHash(contrasenaNueva), esTemporal: true);
    }

    // Cambio voluntario u obligatorio: cada empleado debe conocer su contraseña actual.
    // Rechaza la contraseña actual y las dos anteriores; genera el hash en C#.
    public void CambiarMiContrasena(int idUsuario, string actual, string nueva)
    {
        if (idUsuario <= 0)
            throw new ArgumentException("No hay un usuario autenticado.");
        if (string.IsNullOrWhiteSpace(actual))
            throw new ArgumentException("Introduce tu contraseña actual.");

        ContrasenaHelper.Validar(nueva);

        // El primer hash es el actual. Los demás son los anteriores.
        List<string> hashes = _repository.GetRecentPasswordHashes(idUsuario);
        if (hashes.Count == 0)
            throw new ArgumentException("No se encontró la cuenta.");
        if (!ContrasenaHelper.Verificar(actual, hashes[0]))
            throw new ArgumentException("La contraseña actual no es correcta.");
        if (hashes.Any(hash => ContrasenaHelper.Verificar(nueva, hash)))
            throw new ArgumentException("No puedes repetir tus últimas tres contraseñas.");

        // false: ya no es una contraseña temporal, permite entrar normalmente.
        _repository.ChangePassword(idUsuario, ContrasenaHelper.CrearHash(nueva), esTemporal: false);
    }

    public void Eliminar(int id)
    {
        if (id <= 0) throw new ArgumentException("Seleccione un usuario.");
        int idAdministrador = ObtenerIdAdministrador();
        var admins = _repository.GetAll("").Where(u => u.IdRol == idAdministrador).ToList();
        if (admins.Count == 1 && admins[0].IdUsuario == id)
            throw new ArgumentException("No puede eliminar al único administrador.");
        _repository.Delete(id);
    }
}
