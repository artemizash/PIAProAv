using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;

namespace TemplateCSharp.Services;

public class CancelacionService : ICancelacionService
{
    private readonly ICancelacionRepository _repository;
    public CancelacionService(ICancelacionRepository repository) => _repository = repository;

    public List<Cancelacion> Consultar()
    {
        return _repository.Consultar();
    }

    public List<VentaConsulta> Buscar(Guid folio)
    {
        if (folio == Guid.Empty) throw new ArgumentException("Folio inválido.");
        return _repository.Buscar(folio);
    }

    public void Registrar(Guid folio, int idUsuario, string motivo)
    {
        if (folio == Guid.Empty || idUsuario <= 0) throw new ArgumentException("Folio o usuario inválido.");
        motivo = motivo.Trim();
        if (motivo.Length == 0 || motivo.Length > 255) throw new ArgumentException("Escriba un motivo de 1 a 255 caracteres.");
        _repository.Registrar(folio, idUsuario, motivo);
    }
}
