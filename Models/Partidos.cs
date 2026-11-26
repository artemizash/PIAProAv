namespace TemplateCSharp.Models;

public class Partido
{
    public int IdPartido { get; set; }

    public int IdPartidoEquipo { get; set; }

    public int IdEstadio { get; set; }

    public int IdUsuarioRegistro { get; set; }

    public int IdEquipoLocal { get; set; }

    public int IdEquipoVisitante { get; set; }

    public string NombreEstadio { get; set; } = "";

    public string EquipoLocal { get; set; } = "";

    public string EquipoVisitante { get; set; } = "";

    public DateTime FechaHora { get; set; }

    public string Estado { get; set; } = "programado";

    public string NombrePartido =>
        EquipoLocal + " vs " + EquipoVisitante;
}