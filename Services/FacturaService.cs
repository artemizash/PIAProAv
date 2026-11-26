using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;

namespace TemplateCSharp.Services;

public class FacturaService : IFacturaService
{
    private readonly IFacturaRepository _repository;
    public FacturaService(IFacturaRepository repository) => _repository = repository;

    public List<Factura> Consultar(Guid? folio)
    {
        return _repository.Consultar(folio);
    }

    public List<DetalleFactura> Detalle(int idFactura)
    {
        if (idFactura <= 0) throw new ArgumentException("Seleccione una factura.");
        return _repository.Detalle(idFactura);
    }
}
