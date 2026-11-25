using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface IAsientoService
{
    void Registrar(
        int idZona,
        string fila,
        int numeroInicio,
        int numeroFin);

    List<Asiento> Consultar(
        int? idEstadio = null,
        int? idZona = null);
}