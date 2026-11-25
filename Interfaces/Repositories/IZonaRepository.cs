using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface IZonaRepository
{
    void Add(Zona zona);

    List<Zona> GetAll(int? idEstadio = null);
}