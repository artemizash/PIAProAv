using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface IReporteVentasRepository
{
    List<ReporteVenta> Consultar(DateTime inicio, DateTime fin, int? idEstadio, int? idPartido);
}
