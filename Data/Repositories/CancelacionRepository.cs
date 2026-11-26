using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;

namespace TemplateCSharp.Data.Repositories;

public class CancelacionRepository : ICancelacionRepository
{
    private readonly DatabaseConnection _database;
    public CancelacionRepository(DatabaseConnection database) => _database = database;

    public List<Cancelacion> Consultar()
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = new("dbo.usp_Cancelacion_Listar", conn) { CommandType = CommandType.StoredProcedure };
        conn.Open();
        List<Cancelacion> resultado = new();
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            resultado.Add(new Cancelacion
            {
                Folio = reader["folio"] == DBNull.Value ? null : (Guid)reader["folio"],
                Motivo = Convert.ToString(reader["motivo"]) ?? "",
                Administrador = Convert.ToString(reader["administrador"]) ?? "",
                FechaCancelacion = reader["fecha_cancelacion"] == DBNull.Value ? null : Convert.ToDateTime(reader["fecha_cancelacion"])
            });
        }
        return resultado;
    }

    public List<VentaConsulta> Buscar(Guid folio)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = new("dbo.usp_Venta_Buscar", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@folio", SqlDbType.UniqueIdentifier).Value = folio;
        conn.Open();
        List<VentaConsulta> resultado = new();
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            resultado.Add(new VentaConsulta
            {
                Folio = reader["folio"] == DBNull.Value ? null : (Guid)reader["folio"],
                Cliente = Convert.ToString(reader["cliente"]) ?? "",
                Partido = Convert.ToString(reader["partido"]) ?? "",
                Estadio = Convert.ToString(reader["estadio"]) ?? "",
                Zona = Convert.ToString(reader["zona"]) ?? "",
                Fila = Convert.ToString(reader["fila"]) ?? "",
                Numero = Convert.ToInt32(reader["numero"]),
                PrecioUnitario = Convert.ToDecimal(reader["precio_unitario"]),
                EstadoVenta = Convert.ToString(reader["estado_venta"]) ?? "",
                TotalVenta = Convert.ToDecimal(reader["total_venta"])
            });
        }
        return resultado;
    }

    public void Registrar(Guid folio, int idUsuario, string motivo)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = new("dbo.usp_Venta_Cancelar", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@folio", SqlDbType.UniqueIdentifier).Value = folio;
        cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = idUsuario;
        cmd.Parameters.Add("@motivo", SqlDbType.VarChar, 255).Value = motivo;
        conn.Open();
        cmd.ExecuteNonQuery();
    }
}
