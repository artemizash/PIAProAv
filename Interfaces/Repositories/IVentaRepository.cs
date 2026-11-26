using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface IVentaRepository
{
    List<Boleto> GetDisponibles(
        int idPartido,
        int? idZona = null);

    Venta Add(
        Venta venta,
        List<int> boletos);
}