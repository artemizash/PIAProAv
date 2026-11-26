using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Services;

public class PartidoService : IPartidoService
{
    private readonly IPartidoRepository _repository;

    public PartidoService(IPartidoRepository repository)
    {
        _repository = repository;
    }

    // Validar y registrar partido.
    public int Registrar(Partido partido)
    {
        if (partido.IdEstadio <= 0)
        {
            throw new ArgumentException(
                "Seleccione un estadio.");
        }

        if (partido.IdUsuarioRegistro <= 0)
        {
            throw new ArgumentException(
                "No existe una sesión iniciada.");
        }

        if (partido.IdEquipoLocal <= 0)
        {
            throw new ArgumentException(
                "Seleccione el equipo local.");
        }

        if (partido.IdEquipoVisitante <= 0)
        {
            throw new ArgumentException(
                "Seleccione el equipo visitante.");
        }

        if (partido.IdEquipoLocal ==
            partido.IdEquipoVisitante)
        {
            throw new ArgumentException(
                "Los equipos deben ser diferentes.");
        }

        if (partido.FechaHora <= DateTime.Now)
        {
            throw new ArgumentException(
                "La fecha y hora deben ser futuras.");
        }

        partido.Estado = "programado";

        return _repository.Add(partido);
    }

    // Consultar partidos.
    public List<Partido> Consultar(
        bool disponibles = false,
        string? filtro = null)
    {
        filtro = filtro?.Trim();

        if (filtro != null && filtro.Length > 150)
        {
            throw new ArgumentException(
                "El filtro no puede superar 150 caracteres.");
        }

        return _repository.GetAll(disponibles, filtro);
    }
}