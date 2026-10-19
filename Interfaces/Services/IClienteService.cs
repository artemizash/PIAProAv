using TemplateCSharp.Models;
namespace TemplateCSharp.Interfaces.Services;

public interface IClienteService
{
    List<Cliente> Consultar(string filtro = "");
    void Registrar(Cliente cliente);
    void Actualizar(Cliente cliente);
    void Eliminar(int id);
}
