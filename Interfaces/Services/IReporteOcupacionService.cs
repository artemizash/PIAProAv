using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface IReporteOcupacionService
{
    List<ReporteOcupacion> Consultar(int? idPartido, int? idZona, bool soloDisponibles);
}
