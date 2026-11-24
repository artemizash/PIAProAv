namespace TemplateCSharp.Models;

public class Venta
{
    public int IdVenta { get; set; }
    public int IdCliente { get; set; }
    public int IdUsuario { get; set; }
    public Guid? Folio { get; set; }
    public string MetodoPago { get; set; } = "";
    public string Estado { get; set; } = "completada";
    public DateTime? FechaVenta { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Iva { get; set; }
    public decimal Total { get; set; }
}