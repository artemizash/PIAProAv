using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface IFacturaService
{
    List<Factura> Consultar(Guid? folio);
    List<DetalleFactura> Detalle(int idFactura);
}
