namespace TemplateCSharp.Models;

public class Asiento
{
    public int IdAsiento { get; set; }

    public int IdZona { get; set; }

    public int IdEstadio { get; set; }

    public string NombreEstadio { get; set; } = "";

    public string NombreZona { get; set; } = "";

    public string Fila { get; set; } = "";

    public int Numero { get; set; }

    public bool Activo { get; set; } = true;
}