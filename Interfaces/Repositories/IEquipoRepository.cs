using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface IEquipoRepository
{
    void Add(Equipo equipo);

    List<Equipo> GetAll(bool soloActivos = false);
}