using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Services;

// Compara credenciales sin poner lógica de autenticación en WinForms.
public class AccesoService : IAccesoService
{
    private readonly IUsuarioRepository _repository;
    public AccesoService(IUsuarioRepository repository) => _repository = repository;

    public UsuarioCredenciales? IniciarSesion(string correo, string contrasena)
    {
        if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrEmpty(contrasena))
            throw new ArgumentException("Escriba correo y contraseña.");
        UsuarioCredenciales? usuario = _repository.FindCredentials(correo.Trim().ToLowerInvariant());
        if (usuario is null || !ContrasenaHelper.Verificar(contrasena, usuario.HashContrasena))
            return null;
        // El formulario no necesita ni recibe el hash.
        usuario.HashContrasena = string.Empty;
        return usuario;
    }
}
