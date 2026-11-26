using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface IHistorialClientesService
{
    List<HistorialCompra> Consultar(int idCliente, DateTime? fechaCompra, DateTime? fechaPartido, bool ordenPartido);
}
