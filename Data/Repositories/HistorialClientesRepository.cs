using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;

namespace TemplateCSharp.Data.Repositories;

public class HistorialClientesRepository : IHistorialClientesRepository
{
    private readonly DatabaseConnection _database;
    public HistorialClientesRepository(DatabaseConnection database) => _database = database;

    public List<HistorialCompra> Consultar(int idCliente, DateTime? fechaCompra, DateTime? fechaPartido, bool ordenPartido)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = new("dbo.usp_Cliente_Historial", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = idCliente;
        cmd.Parameters.Add("@fecha_compra", SqlDbType.Date).Value = (object?)fechaCompra ?? DBNull.Value;
        cmd.Parameters.Add("@fecha_partido", SqlDbType.Date).Value = (object?)fechaPartido ?? DBNull.Value;
        cmd.Parameters.Add("@orden_partido", SqlDbType.Bit).Value = ordenPartido;
        conn.Open();
        List<HistorialCompra> resultado = new();
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            resultado.Add(new HistorialCompra
            {
                Folio = reader["folio"] == DBNull.Value ? null : (Guid)reader["folio"],
                FechaVenta = reader["fecha_venta"] == DBNull.Value ? null : Convert.ToDateTime(reader["fecha_venta"]),
                Partido = Convert.ToString(reader["partido"]) ?? "",
                Estadio = Convert.ToString(reader["estadio"]) ?? "",
                Zona = Convert.ToString(reader["zona"]) ?? "",
                FechaPartido = reader["fecha_partido"] == DBNull.Value ? null : Convert.ToDateTime(reader["fecha_partido"]),
                Cantidad = Convert.ToInt32(reader["cantidad"]),
                Subtotal = Convert.ToDecimal(reader["subtotal"]),
                Total = Convert.ToDecimal(reader["total"]),
                MetodoPago = Convert.ToString(reader["metodo_pago"]) ?? "",
                FolioFactura = Convert.ToString(reader["folio_factura"]) ?? "",
                EstadoVenta = Convert.ToString(reader["estado_venta"]) ?? ""
            });
        }
        return resultado;
    }
}
