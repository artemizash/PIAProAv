using TemplateCSharp.Models;
namespace TemplateCSharp.Interfaces.Services;

public interface IAccesoService
{
    UsuarioCredenciales? IniciarSesion(string correo, string contrasena);
}
