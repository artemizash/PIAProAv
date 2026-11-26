using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface IPartidoService
{
    int Registrar(Partido partido);

    List<Partido> Consultar(
        bool disponibles = false,
        string? filtro = null);
}