namespace TemplateCSharp.Models;

public class ReporteOcupacion
{
    public string Partido { get; set; } = "";
    public string Zona { get; set; } = "";
    public decimal PrecioBase { get; set; }
    public int AsientosTotales { get; set; }
    public int Vendidos { get; set; }
    public int Disponibles { get; set; }
    public decimal Porcentaje { get; set; }
}
