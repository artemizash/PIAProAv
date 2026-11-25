namespace TemplateCSharp.Models;

public class Zona
{
    public int IdZona { get; set; }

    public int IdEstadio { get; set; }

    public string NombreEstadio { get; set; } = "";

    public string Nombre { get; set; } = "";

    public decimal PrecioBase { get; set; }

    public int Cupo { get; set; }

    public bool Activa { get; set; } = true;
}
