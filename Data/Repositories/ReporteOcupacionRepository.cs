using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;

namespace TemplateCSharp.Data.Repositories;

public class ReporteOcupacionRepository : IReporteOcupacionRepository
{
    private readonly DatabaseConnection _database;
    public ReporteOcupacionRepository(DatabaseConnection database) => _database = database;

    public List<ReporteOcupacion> Consultar(int? idPartido, int? idZona, bool soloDisponibles)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = new("dbo.usp_Reporte_Ocupacion", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@id_partido", SqlDbType.Int).Value = (object?)idPartido ?? DBNull.Value;
        cmd.Parameters.Add("@id_zona", SqlDbType.Int).Value = (object?)idZona ?? DBNull.Value;
        cmd.Parameters.Add("@solo_disponibles", SqlDbType.Bit).Value = soloDisponibles;
        conn.Open();
        List<ReporteOcupacion> resultado = new();
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            resultado.Add(new ReporteOcupacion
            {
                Partido = Convert.ToString(reader["partido"]) ?? "",
                Zona = Convert.ToString(reader["zona"]) ?? "",
                PrecioBase = Convert.ToDecimal(reader["precio_base"]),
                AsientosTotales = Convert.ToInt32(reader["asientos_totales"]),
                Vendidos = Convert.ToInt32(reader["vendidos"]),
                Disponibles = Convert.ToInt32(reader["disponibles"]),
                Porcentaje = Convert.ToDecimal(reader["porcentaje"])
            });
        }
        return resultado;
    }
}
