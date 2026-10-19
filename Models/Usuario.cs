namespace TemplateCSharp.Models;

public class Usuario
{
    public int IdUsuario { get; set; }
    public int IdRol { get; set; }
    public string RolNombre { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string NombreCompleto { get; set; } = string.Empty;
    public string NumeroNomina { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public DateTime FechaRegistro { get; set; }
}
