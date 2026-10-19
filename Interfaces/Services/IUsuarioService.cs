using TemplateCSharp.Models;
namespace TemplateCSharp.Interfaces.Services;

public interface IUsuarioService
{
    List<Usuario> Consultar(string filtro = "");
    List<Rol> ConsultarRoles();
    int ObtenerIdAdministrador();

    void CambiarMiContrasena(int idUsuario, string actual, string nueva);
    void Registrar(Usuario usuario, string contrasena);
    void Actualizar(Usuario usuario, string? contrasenaNueva = null);
    void Eliminar(int id);
}
