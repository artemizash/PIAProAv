using System.Text.RegularExpressions;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Services;

// Aplica formato de RFC y teléfonos y valida los campos de Cliente.
public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;
    public ClienteService(IClienteRepository repository) => _repository = repository;

    public List<Cliente> Consultar(string filtro = "") => _repository.GetAll((filtro ?? "").Trim());

    private static void Validar(Cliente c)
    {
        c.NombreCompleto = c.NombreCompleto.Trim();
        c.Rfc = c.Rfc.Trim().ToUpperInvariant();
        c.Domicilio = c.Domicilio.Trim();
        c.TelefonoCasa = c.TelefonoCasa.Trim();
        c.TelefonoCelular = c.TelefonoCelular.Trim();
        c.Correo = c.Correo.Trim().ToLowerInvariant();
        Validaciones.Nombre(c.NombreCompleto);
        Validaciones.Obligatorio(c.Domicilio,"el domicilio",255);
        Validaciones.Correo(c.Correo);
        Validaciones.Nacimiento(c.FechaNacimiento);
        if (!Regex.IsMatch(c.Rfc,@"^[A-ZÑ&]{3,4}\d{6}[A-Z0-9]{3}$"))
            throw new ArgumentException("El RFC debe tener 12 o 13 caracteres con formato válido.");
        if (!Regex.IsMatch(c.TelefonoCasa,@"^\d{7,15}$"))
            throw new ArgumentException("Teléfono de casa: entre 7 y 15 dígitos.");
        if (!Regex.IsMatch(c.TelefonoCelular,@"^\d{10}$"))
            throw new ArgumentException("Teléfono celular: exactamente 10 dígitos.");
    }

    public void Registrar(Cliente c)
    {
        ArgumentNullException.ThrowIfNull(c);
        Validar(c);
        _repository.Add(c);
    }
    public void Actualizar(Cliente c)
    {
        ArgumentNullException.ThrowIfNull(c);
        if (c.IdCliente <= 0) throw new ArgumentException("Seleccione un cliente.");
        Validar(c);
        _repository.Update(c);
    }
    public void Eliminar(int id)
    {
        if (id <= 0) throw new ArgumentException("Seleccione un cliente.");
        _repository.Delete(id);
    }
}
