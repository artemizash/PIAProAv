namespace TemplateCSharp.Models;

public class Boleto
{
    public int IdBoleto { get; set; }

    public int IdPartidoEquipo { get; set; }

    public int IdAsiento { get; set; }

    public decimal PrecioUnitario { get; set; }

    public string Estado { get; set; } = "disponible";

    public DateTime FechaRegistro { get; set; }

    public int IdPartido { get; set; }

    public int IdZona { get; set; }

    public string NombreZona { get; set; } = "";

    public string Fila { get; set; } = "";

    public int NumeroAsiento { get; set; }

    public string NombreAsiento =>
        Fila + "-" + NumeroAsiento;
}