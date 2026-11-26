namespace TemplateCSharp.Models;

public class VentaConsulta
{
    public Guid? Folio { get; set; }
    public string Cliente { get; set; } = "";
    public string Partido { get; set; } = "";
    public string Estadio { get; set; } = "";
    public string Zona { get; set; } = "";
    public string Fila { get; set; } = "";
    public int Numero { get; set; }
    public decimal PrecioUnitario { get; set; }
    public string EstadoVenta { get; set; } = "";
    public decimal TotalVenta { get; set; }
}
