using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface IFacturaRepository
{
    List<Factura> Consultar(Guid? folio);
    List<DetalleFactura> Detalle(int idFactura);
}
