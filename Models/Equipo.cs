namespace TemplateCSharp.Models;

public class Equipo
{
    public int IdEquipo { get; set; }

    public string Nombre { get; set; } = "";

    public string Ciudad { get; set; } = "";

    public bool Activo { get; set; } = true;
}