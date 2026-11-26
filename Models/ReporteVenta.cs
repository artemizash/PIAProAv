namespace TemplateCSharp.Models;

public class ReporteVenta
{
    public Guid? Folio { get; set; }
    public DateTime? FechaVenta { get; set; }
    public string Estadio { get; set; } = "";
    public string Partido { get; set; } = "";
    public DateTime? FechaPartido { get; set; }
    public string Zona { get; set; } = "";
    public int Cantidad { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public string MetodoPago { get; set; } = "";
}
