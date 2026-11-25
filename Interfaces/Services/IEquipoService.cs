using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface IEquipoService
{
    void Registrar(Equipo equipo);

    List<Equipo> Consultar(bool soloActivos = false);
}