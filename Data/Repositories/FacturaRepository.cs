using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Models;
using TemplateCSharp.Interfaces.Repositories;

namespace TemplateCSharp.Data.Repositories;

public class FacturaRepository : IFacturaRepository
{
    private readonly DatabaseConnection _database;
    public FacturaRepository(DatabaseConnection database) => _database = database;

    public List<Factura> Consultar(Guid? folio)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = new("dbo.usp_Factura_Listar", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@folio", SqlDbType.UniqueIdentifier).Value = (object?)folio ?? DBNull.Value;
        conn.Open();
        List<Factura> resultado = new();
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            resultado.Add(new Factura
            {
                IdFactura = Convert.ToInt32(reader["id_factura"]),
                FolioFactura = Convert.ToString(reader["folio_factura"]) ?? "",
                Folio = reader["folio"] == DBNull.Value ? null : (Guid)reader["folio"],
                ReceptorNombre = Convert.ToString(reader["receptor_nombre"]) ?? "",
                Total = Convert.ToDecimal(reader["total"]),
                Estado = Convert.ToString(reader["estado"]) ?? ""
            });
        }
        return resultado;
    }

    public List<DetalleFactura> Detalle(int idFactura)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = new("dbo.usp_Factura_Detalle", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.Add("@id_factura", SqlDbType.Int).Value = idFactura;
        conn.Open();
        List<DetalleFactura> resultado = new();
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            resultado.Add(new DetalleFactura
            {
                IdFactura = Convert.ToInt32(reader["id_factura"]),
                FolioFactura = Convert.ToString(reader["folio_factura"]) ?? "",
                FechaEmision = reader["fecha_emision"] == DBNull.Value ? null : Convert.ToDateTime(reader["fecha_emision"]),
                Estado = Convert.ToString(reader["estado_factura"]) ?? "",
                EmisorNombre = Convert.ToString(reader["emisor_nombre"]) ?? "",
                EmisorRfc = Convert.ToString(reader["emisor_rfc"]) ?? "",
                EmisorDomicilio = Convert.ToString(reader["emisor_domicilio"]) ?? "",
                ReceptorNombre = Convert.ToString(reader["receptor_nombre"]) ?? "",
                ReceptorRfc = Convert.ToString(reader["receptor_rfc"]) ?? "",
                ReceptorDomicilio = Convert.ToString(reader["receptor_domicilio"]) ?? "",
                Subtotal = Convert.ToDecimal(reader["subtotal"]),
                Iva = Convert.ToDecimal(reader["iva"]),
                Total = Convert.ToDecimal(reader["total"]),
                Folio = reader["folio"] == DBNull.Value ? null : (Guid)reader["folio"],
                MetodoPago = Convert.ToString(reader["metodo_pago"]) ?? "",
                Partido = Convert.ToString(reader["partido"]) ?? "",
                Estadio = Convert.ToString(reader["estadio"]) ?? "",
                Zona = Convert.ToString(reader["zona"]) ?? "",
                Fila = Convert.ToString(reader["fila"]) ?? "",
                Numero = Convert.ToInt32(reader["numero"]),
                PrecioUnitario = Convert.ToDecimal(reader["precio_unitario"]),
                IdBoleto = Convert.ToInt32(reader["id_boleto"])
            });
        }
        return resultado;
    }
}
