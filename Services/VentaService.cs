using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Services;

public class VentaService : IVentaService
{
    private readonly IVentaRepository _repository;

    public VentaService(IVentaRepository repository)
    {
        _repository = repository;
    }

    // Consultar boletos disponibles.
    public List<Boleto> ConsultarDisponibles(
        int idPartido,
        int? idZona = null)
    {
        if (idPartido <= 0)
        {
            throw new ArgumentException(
                "Seleccione un partido.");
        }

        return _repository.GetDisponibles(
            idPartido, idZona);
    }

    // Validar y registrar la compra.
    public Venta Registrar(
        Venta venta,
        List<int> boletos)
    {
        if (venta.IdCliente <= 0)
        {
            throw new ArgumentException(
                "Seleccione un cliente.");
        }

        if (venta.IdUsuario <= 0)
        {
            throw new ArgumentException(
                "No existe una sesión iniciada.");
        }

        if (boletos.Count < 1 || boletos.Count > 4)
        {
            throw new ArgumentException(
                "Seleccione de uno a cuatro boletos.");
        }

        if (boletos.Any(id => id <= 0))
        {
            throw new ArgumentException(
                "Existe un boleto inválido.");
        }

        if (boletos.Distinct().Count() != boletos.Count)
        {
            throw new ArgumentException(
                "No puede repetir boletos.");
        }

        venta.MetodoPago =
            venta.MetodoPago.Trim().ToLowerInvariant();

        if (venta.MetodoPago != "efectivo" &&
            venta.MetodoPago != "credito" &&
            venta.MetodoPago != "debito")
        {
            throw new ArgumentException(
                "Seleccione un método de pago válido.");
        }

        return _repository.Add(venta, boletos);
    }
}