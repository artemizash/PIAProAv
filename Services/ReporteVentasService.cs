using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;

namespace TemplateCSharp.Services;

public class ReporteVentasService : IReporteVentasService
{
    private readonly IReporteVentasRepository _repository;
    public ReporteVentasService(IReporteVentasRepository repository) => _repository = repository;

    public List<ReporteVenta> Consultar(DateTime inicio, DateTime fin, int? idEstadio, int? idPartido)
    {
        if (inicio.Date > fin.Date) throw new ArgumentException("La fecha inicial no puede ser posterior a la final.");
        return _repository.Consultar(inicio, fin, idEstadio, idPartido);
    }
}
