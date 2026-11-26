using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Repositories;

public interface IPartidoRepository
{
    int Add(Partido partido);

    List<Partido> GetAll(
        bool disponibles = false,
        string? filtro = null);
}