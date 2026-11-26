namespace TemplateCSharp.Models;

public class Cancelacion
{
    public Guid? Folio { get; set; }
    public string Motivo { get; set; } = "";
    public string Administrador { get; set; } = "";
    public DateTime? FechaCancelacion { get; set; }
}
