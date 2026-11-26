using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Models;

namespace TemplateCSharp.Data.Repositories;

public class VentaRepository : IVentaRepository
{
    private readonly DatabaseConnection _database;

    public VentaRepository(DatabaseConnection database)
    {
        _database = database;
    }

    // Consultar boletos disponibles.
    public List<Boleto> GetDisponibles(
        int idPartido,
        int? idZona = null)
    {
        List<Boleto> boletos = new List<Boleto>();

        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Boleto_ListarDisponibles", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@id_partido", SqlDbType.Int
        ).Value = idPartido;

        cmd.Parameters.Add(
            "@id_zona", SqlDbType.Int
        ).Value = (object?)idZona ?? DBNull.Value;

        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Boleto boleto = new Boleto();

            boleto.IdBoleto =
                Convert.ToInt32(reader["id_boleto"]);

            boleto.IdPartidoEquipo =
                Convert.ToInt32(reader["id_partido_equipo"]);

            boleto.IdPartido =
                Convert.ToInt32(reader["id_partido"]);

            boleto.IdAsiento =
                Convert.ToInt32(reader["id_asiento"]);

            boleto.IdZona =
                Convert.ToInt32(reader["id_zona"]);

            boleto.NombreZona =
                Convert.ToString(reader["zona"]) ?? "";

            boleto.Fila =
                Convert.ToString(reader["fila"]) ?? "";

            boleto.NumeroAsiento =
                Convert.ToInt32(reader["numero_asiento"]);

            boleto.PrecioUnitario =
                Convert.ToDecimal(reader["precio_unitario"]);

            boleto.Estado =
                Convert.ToString(reader["estado"]) ?? "";

            boletos.Add(boleto);
        }

        return boletos;
    }

    // Registrar una venta.
    public Venta Add(
        Venta venta,
        List<int> boletos)
    {
        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Venta_Crear", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@id_cliente", SqlDbType.Int
        ).Value = venta.IdCliente;

        cmd.Parameters.Add(
            "@id_usuario", SqlDbType.Int
        ).Value = venta.IdUsuario;

        cmd.Parameters.Add(
            "@metodo_pago", SqlDbType.VarChar, 20
        ).Value = venta.MetodoPago;

        // Crear tabla de boletos seleccionados.
        DataTable tablaBoletos = new DataTable();

        tablaBoletos.Columns.Add(
            "id_boleto", typeof(int));

        foreach (int idBoleto in boletos)
        {
            tablaBoletos.Rows.Add(idBoleto);
        }

        // Enviar la tabla a SQL Server.
        SqlParameter parametro = cmd.Parameters.Add(
            "@Boletos", SqlDbType.Structured);

        parametro.TypeName = "dbo.ListaBoletos";
        parametro.Value = tablaBoletos;

        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            venta.IdVenta =
                Convert.ToInt32(reader["id_venta"]);

            venta.Folio =
                (Guid)reader["folio"];

            venta.Subtotal =
                Convert.ToDecimal(reader["subtotal"]);

            venta.Iva =
                Convert.ToDecimal(reader["iva"]);

            venta.Total =
                Convert.ToDecimal(reader["total"]);

            venta.Estado = "completada";

            return venta;
        }

        throw new InvalidOperationException(
            "No se obtuvo el resultado de la venta.");
    }
}