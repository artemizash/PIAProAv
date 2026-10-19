namespace TemplateCSharp.Models;

// Solo lo usa el servicio de inicio de sesión para comprobar el hash.
public class UsuarioCredenciales
{
    public int IdUsuario { get; set; }
    public int IdRol { get; set; }
    // SQL indica si debe cambiar la contraseña antes de acceder al sistema.
    public bool DebeCambiarContrasena { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string HashContrasena { get; set; } = string.Empty;
}
