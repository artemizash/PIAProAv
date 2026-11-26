namespace TemplateCSharp.Models;

public class DetalleFactura
{
    public int IdFactura { get; set; }
    public string FolioFactura { get; set; } = "";
    public DateTime? FechaEmision { get; set; }
    public string Estado { get; set; } = "";
    public string EmisorNombre { get; set; } = "";
    public string EmisorRfc { get; set; } = "";
    public string EmisorDomicilio { get; set; } = "";
    public string ReceptorNombre { get; set; } = "";
    public string ReceptorRfc { get; set; } = "";
    public string ReceptorDomicilio { get; set; } = "";
    public decimal Subtotal { get; set; }
    public decimal Iva { get; set; }
    public decimal Total { get; set; }
    public Guid? Folio { get; set; }
    public string MetodoPago { get; set; } = "";
    public string Partido { get; set; } = "";
    public string Estadio { get; set; } = "";
    public string Zona { get; set; } = "";
    public string Fila { get; set; } = "";
    public int Numero { get; set; }
    public decimal PrecioUnitario { get; set; }
    public int IdBoleto { get; set; }
}
