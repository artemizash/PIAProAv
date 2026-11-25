using TemplateCSharp.Models;
namespace TemplateCSharp.Interfaces.Services;

public interface IEstadioService
{
    void Registrar(Estadio estadio);

    List<Estadio> Consultar();
}