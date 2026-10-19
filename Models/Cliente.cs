namespace TemplateCSharp.Models;

public class Cliente
{
    public int IdCliente { get; set; }
    public string NombreCompleto { get; set; } = string.Empty;
    public string Rfc { get; set; } = string.Empty;
    public string Domicilio { get; set; } = string.Empty;
    public string TelefonoCasa { get; set; } = string.Empty;
    public string TelefonoCelular { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public DateTime FechaNacimiento { get; set; }
    public DateTime FechaRegistro { get; set; }
}
