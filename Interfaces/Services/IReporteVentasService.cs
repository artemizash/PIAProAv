using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface IReporteVentasService
{
    List<ReporteVenta> Consultar(DateTime inicio, DateTime fin, int? idEstadio, int? idPartido);
}
