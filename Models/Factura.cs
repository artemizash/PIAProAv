namespace TemplateCSharp.Models;

public class Factura
{
    public int IdFactura { get; set; }
    public string FolioFactura { get; set; } = "";
    public Guid? Folio { get; set; }
    public string ReceptorNombre { get; set; } = "";
    public decimal Total { get; set; }
    public string Estado { get; set; } = "";
}
