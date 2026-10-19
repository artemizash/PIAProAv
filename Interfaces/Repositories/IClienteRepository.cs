using TemplateCSharp.Models;
namespace TemplateCSharp.Interfaces.Repositories;

// Contrato de acceso a la entidad Cliente.
public interface IClienteRepository
{
    List<Cliente> GetAll(string filtro);
    void Add(Cliente cliente);
    void Update(Cliente cliente);
    void Delete(int id);
}
