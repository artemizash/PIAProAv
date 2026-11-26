using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface ICancelacionService
{
    List<Cancelacion> Consultar();
    List<VentaConsulta> Buscar(Guid folio);
    void Registrar(Guid folio, int idUsuario, string motivo);
}
