using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Services;

public class EquipoService : IEquipoService
{
    private readonly IEquipoRepository _repository;

    public EquipoService(IEquipoRepository repository)
    {
        _repository = repository;
    }

    // Validar y registrar un equipo.
    public void Registrar(Equipo equipo)
    {
        equipo.Nombre = equipo.Nombre.Trim();

        equipo.Ciudad = equipo.Ciudad.Trim();

        if (string.IsNullOrWhiteSpace(equipo.Nombre))
        {
            throw new ArgumentException(
                "Ingrese el nombre del equipo.");
        }

        if (equipo.Nombre.Length > 100)
        {
            throw new ArgumentException(
                "El nombre no puede superar 100 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(equipo.Ciudad))
        {
            throw new ArgumentException(
                "Ingrese la ciudad del equipo.");
        }

        if (equipo.Ciudad.Length > 100)
        {
            throw new ArgumentException(
                "La ciudad no puede superar 100 caracteres.");
        }

        _repository.Add(equipo);
    }

    // Consultar equipos.
    public List<Equipo> Consultar(bool soloActivos = false)
    {
        return _repository.GetAll(soloActivos);
    }
}