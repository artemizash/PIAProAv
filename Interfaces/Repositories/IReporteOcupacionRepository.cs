using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface IReporteOcupacionRepository
{
    List<ReporteOcupacion> Consultar(int? idPartido, int? idZona, bool soloDisponibles);
}
