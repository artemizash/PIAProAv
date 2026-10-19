using TemplateCSharp.Models;
namespace TemplateCSharp.Interfaces.Repositories;

public interface IUsuarioRepository
{
    List<Usuario> GetAll(string filtro);
    List<Rol> GetRoles();
    void Add(Usuario usuario, string hashContrasena);
    void Update(Usuario usuario);
    void Delete(int id);
    List<string> GetRecentPasswordHashes(int id);
    void ChangePassword(int id, string nuevoHash, bool esTemporal);
    UsuarioCredenciales? FindCredentials(string correo);
}
