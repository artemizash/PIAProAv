using TemplateCSharp.Models;

namespace TemplateCSharp.Interfaces.Services;

public interface IZonaService
{
    void Registrar(Zona zona);

    List<Zona> Consultar(int? idEstadio = null);
}
