using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;
namespace TemplateCSharp.Services;

public class EstadioService : IEstadioService
{
    private readonly IEstadioRepository _repository;

    public EstadioService(IEstadioRepository repository)
    {
        _repository = repository;
    }

    public void Registrar(Estadio estadio)
    {
        estadio.Nombre = estadio.Nombre.Trim();
        estadio.Ciudad = estadio.Ciudad.Trim();

        if (string.IsNullOrWhiteSpace(estadio.Nombre))
        {
            throw new ArgumentException(
                "Ingrese el nombre del estadio.");
        }

        if (estadio.Nombre.Length > 100)
        {
            throw new ArgumentException(
                "El nombre no puede superar 100 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(estadio.Ciudad))
        {
            throw new ArgumentException(
                "Ingrese la ciudad.");
        }

        if (estadio.Ciudad.Length > 100)
        {
            throw new ArgumentException(
                "La ciudad no puede superar 100 caracteres.");
        }

        if (estadio.CapacidadTotal <= 0)
        {
            throw new ArgumentException(
                "La capacidad debe ser mayor a cero.");
        }

        if (estadio.Mapa == null || estadio.Mapa.Length == 0)
        {
            throw new ArgumentException(
                "Seleccione una imagen del estadio.");
        }

        if (estadio.IdUsuarioRegistro <= 0)
        {
            throw new ArgumentException(
                "No hay un usuario registrado en la sesión.");
        }

        _repository.Add(estadio);
    }

    public List<Estadio> Consultar()
    {
        return _repository.GetAll();
    }
}