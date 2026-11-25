using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface IAsientoRepository
{
    void Add(
        int idZona,
        string fila,
        int numeroInicio,
        int numeroFin);

    List<Asiento> GetAll(
        int? idEstadio = null,
        int? idZona = null);
}