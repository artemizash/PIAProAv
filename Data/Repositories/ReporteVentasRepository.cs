using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;

namespace TemplateCSharp.Data.Repositories;

public class ReporteVentasRepository : IReporteVentasRepository
{
    private readonly DatabaseConnection _database;
    public ReporteVentasRepository(DatabaseConnection database) => _database = database;

    public List<ReporteVenta> Consultar(DateTime inicio, DateTime fin, int? idEstadio, int? idPartido)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = new("dbo.usp_Reporte_Ventas", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@inicio", SqlDbType.Date).Value = inicio;
        cmd.Parameters.Add("@fin", SqlDbType.Date).Value = fin;
        cmd.Parameters.Add("@id_estadio", SqlDbType.Int).Value = (object?)idEstadio ?? DBNull.Value;
        cmd.Parameters.Add("@id_partido", SqlDbType.Int).Value = (object?)idPartido ?? DBNull.Value;
        conn.Open();
        List<ReporteVenta> resultado = new();
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            resultado.Add(new ReporteVenta
            {
                Folio = reader["folio"] == DBNull.Value ? null : (Guid)reader["folio"],
                FechaVenta = reader["fecha_venta"] == DBNull.Value ? null : Convert.ToDateTime(reader["fecha_venta"]),
                Estadio = Convert.ToString(reader["estadio"]) ?? "",
                Partido = Convert.ToString(reader["partido"]) ?? "",
                FechaPartido = reader["fecha_partido"] == DBNull.Value ? null : Convert.ToDateTime(reader["fecha_partido"]),
                Zona = Convert.ToString(reader["zona"]) ?? "",
                Cantidad = Convert.ToInt32(reader["cantidad"]),
                Subtotal = Convert.ToDecimal(reader["subtotal"]),
                Total = Convert.ToDecimal(reader["total"]),
                MetodoPago = Convert.ToString(reader["metodo_pago"]) ?? ""
            });
        }
        return resultado;
    }
}
