using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface ICancelacionRepository
{
    List<Cancelacion> Consultar();
    List<VentaConsulta> Buscar(Guid folio);
    void Registrar(Guid folio, int idUsuario, string motivo);
}
