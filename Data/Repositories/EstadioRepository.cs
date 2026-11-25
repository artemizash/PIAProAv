using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Models;
namespace TemplateCSharp.Data.Repositories;

public class EstadioRepository : IEstadioRepository
{
    private readonly DatabaseConnection _database;

    public EstadioRepository(DatabaseConnection database)
    {
        _database = database;
    }

    // Registrar un estadio
    public void Add(Estadio estadio)
    {
        using SqlConnection conn = _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Estadio_Crear", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@id_usuario_registro", SqlDbType.Int
        ).Value = estadio.IdUsuarioRegistro;

        cmd.Parameters.Add(
            "@nombre", SqlDbType.VarChar, 100
        ).Value = estadio.Nombre;

        cmd.Parameters.Add(
            "@ciudad", SqlDbType.VarChar, 100
        ).Value = estadio.Ciudad;

        cmd.Parameters.Add(
            "@capacidad_total", SqlDbType.Int
        ).Value = estadio.CapacidadTotal;

        cmd.Parameters.Add(
            "@mapa", SqlDbType.VarBinary, -1
        ).Value = (object?)estadio.Mapa ?? DBNull.Value;

        conn.Open();
        cmd.ExecuteNonQuery();
    }

    // Consultar los estadios registrados
    public List<Estadio> GetAll()
    {
        List<Estadio> estadios = new List<Estadio>();

        using SqlConnection conn = _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Estadio_Listar", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Estadio estadio = new Estadio();

            estadio.IdEstadio =
                Convert.ToInt32(reader["id_estadio"]);

            estadio.IdUsuarioRegistro =
                Convert.ToInt32(reader["id_usuario_registro"]);

            estadio.Nombre =
                Convert.ToString(reader["nombre"]) ?? "";

            estadio.Ciudad =
                Convert.ToString(reader["ciudad"]) ?? "";

            estadio.CapacidadTotal =
                Convert.ToInt32(reader["capacidad_total"]);

            if (reader["mapa"] != DBNull.Value)
            {
                estadio.Mapa = (byte[])reader["mapa"];
            }

            if (reader["fecha_registro"] != DBNull.Value)
            {
                estadio.FechaRegistro =
                    Convert.ToDateTime(reader["fecha_registro"]);
            }

            estadios.Add(estadio);
        }

        return estadios;
    }
}