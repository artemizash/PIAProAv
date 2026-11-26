using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;

namespace TemplateCSharp.Services;

public class HistorialClientesService : IHistorialClientesService
{
    private readonly IHistorialClientesRepository _repository;
    public HistorialClientesService(IHistorialClientesRepository repository) => _repository = repository;

    public List<HistorialCompra> Consultar(int idCliente, DateTime? fechaCompra, DateTime? fechaPartido, bool ordenPartido)
    {
        if (idCliente <= 0) throw new ArgumentException("Seleccione un cliente.");
        return _repository.Consultar(idCliente, fechaCompra, fechaPartido, ordenPartido);
    }
}
