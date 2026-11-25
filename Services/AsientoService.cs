using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Services;

public class AsientoService : IAsientoService
{
    private readonly IAsientoRepository _repository;

    public AsientoService(IAsientoRepository repository)
    {
        _repository = repository;
    }

    // Validar y registrar los asientos.
    public void Registrar(
        int idZona,
        string fila,
        int numeroInicio,
        int numeroFin)
    {
        fila = fila.Trim().ToUpperInvariant();

        if (idZona <= 0)
        {
            throw new ArgumentException(
                "Seleccione una zona.");
        }

        if (string.IsNullOrWhiteSpace(fila))
        {
            throw new ArgumentException(
                "Ingrese la fila.");
        }

        if (fila.Length > 5)
        {
            throw new ArgumentException(
                "La fila no puede superar 5 caracteres.");
        }

        if (!fila.All(char.IsLetterOrDigit))
        {
            throw new ArgumentException(
                "La fila solo puede contener letras y numeros.");
        }

        if (numeroInicio <= 0)
        {
            throw new ArgumentException(
                "El numero debe ser mayor a cero.");
        }

        if (numeroFin < numeroInicio)
        {
            throw new ArgumentException(
                "El rango de asientos no es valido.");
        }

        _repository.Add(
            idZona,
            fila,
            numeroInicio,
            numeroFin);
    }

    // Consultar asientos.
    public List<Asiento> Consultar(
        int? idEstadio = null,
        int? idZona = null)
    {
        return _repository.GetAll(idEstadio, idZona);
    }
}