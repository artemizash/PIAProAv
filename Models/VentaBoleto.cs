namespace TemplateCSharp.Models;

public class VentaBoleto
{
    public int IdVentaBoleto { get; set; }
    public int IdVenta { get; set; }
    public int IdBoleto { get; set; }
    public decimal PrecioUnitario { get; set; }
    public DateTime FechaAsignacion { get; set; }
    public DateTime? FechaLiberacion { get; set; }
}
