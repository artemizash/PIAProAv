using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Services;

public class ZonaService : IZonaService
{
    private readonly IZonaRepository _repository;

    public ZonaService(IZonaRepository repository)
    {
        _repository = repository;
    }

    // Validar y registrar una zona
    public void Registrar(Zona zona)
    {
        zona.Nombre = zona.Nombre.Trim();

        if (zona.IdEstadio <= 0)
        {
            throw new ArgumentException(
                "Seleccione un estadio.");
        }

        if (string.IsNullOrWhiteSpace(zona.Nombre))
        {
            throw new ArgumentException(
                "Ingrese el nombre de la zona.");
        }

        if (zona.Nombre.Length > 50)
        {
            throw new ArgumentException(
                "El nombre no puede superar 50 caracteres.");
        }

        if (zona.PrecioBase <= 0)
        {
            throw new ArgumentException(
                "El precio debe ser mayor a cero.");
        }

        if (zona.PrecioBase > 99999999.99m)
        {
            throw new ArgumentException(
                "El precio supera el límite permitido.");
        }

        if (decimal.Round(zona.PrecioBase, 2)
            != zona.PrecioBase)
        {
            throw new ArgumentException(
                "El precio solo puede tener dos decimales.");
        }

        if (zona.Cupo <= 0)
        {
            throw new ArgumentException(
                "El cupo debe ser mayor a cero.");
        }

        _repository.Add(zona);
    }

    // Consultar zonas
    public List<Zona> Consultar(int? idEstadio = null)
    {
        return _repository.GetAll(idEstadio);
    }
}