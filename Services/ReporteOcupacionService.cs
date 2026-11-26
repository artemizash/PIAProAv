using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;

namespace TemplateCSharp.Services;

public class ReporteOcupacionService : IReporteOcupacionService
{
    private readonly IReporteOcupacionRepository _repository;
    public ReporteOcupacionService(IReporteOcupacionRepository repository) => _repository = repository;

    public List<ReporteOcupacion> Consultar(int? idPartido, int? idZona, bool soloDisponibles)
    {
        return _repository.Consultar(idPartido, idZona, soloDisponibles);
    }
}
