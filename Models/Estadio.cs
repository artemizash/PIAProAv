namespace TemplateCSharp.Models;

public class Estadio
{
    public int IdEstadio { get; set; }

    public int IdUsuarioRegistro { get; set; }

    public string Nombre { get; set; } = "";

    public string Ciudad { get; set; } = "";

    public int CapacidadTotal { get; set; }

    public byte[]? Mapa { get; set; }

    public DateTime FechaRegistro { get; set; }
}