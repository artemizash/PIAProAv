using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface IHistorialClientesRepository
{
    List<HistorialCompra> Consultar(int idCliente, DateTime? fechaCompra, DateTime? fechaPartido, bool ordenPartido);
}
