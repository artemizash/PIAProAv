using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface IVentaService
{
    List<Boleto> ConsultarDisponibles(
        int idPartido,
        int? idZona = null);

    Venta Registrar(
        Venta venta,
        List<int> boletos);
}