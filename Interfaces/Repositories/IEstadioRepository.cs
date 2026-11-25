using TemplateCSharp.Models;
namespace TemplateCSharp.Interfaces.Repositories;

public interface IEstadioRepository
{
    void Add(Estadio estadio);

    List<Estadio> GetAll();
}