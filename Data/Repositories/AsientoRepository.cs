using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Models;

namespace TemplateCSharp.Data.Repositories;

public class AsientoRepository : IAsientoRepository
{
    private readonly DatabaseConnection _database;

    public AsientoRepository(DatabaseConnection database)
    {
        _database = database;
    }

    // Registrar asientos.
    public void Add(
        int idZona,
        string fila,
        int numeroInicio,
        int numeroFin)
    {
        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Asiento_Crear", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@id_zona", SqlDbType.Int
        ).Value = idZona;

        cmd.Parameters.Add(
            "@fila", SqlDbType.VarChar, 5
        ).Value = fila;

        cmd.Parameters.Add(
            "@numero_inicio", SqlDbType.Int
        ).Value = numeroInicio;

        cmd.Parameters.Add(
            "@numero_fin", SqlDbType.Int
        ).Value = numeroFin;

        conn.Open();

        cmd.ExecuteNonQuery();
    }

    // Consultar los asientos registrados.
    public List<Asiento> GetAll(
        int? idEstadio = null,
        int? idZona = null)
    {
        List<Asiento> asientos = new List<Asiento>();

        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Asiento_Listar", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@id_estadio", SqlDbType.Int
        ).Value = (object?)idEstadio ?? DBNull.Value;

        cmd.Parameters.Add(
            "@id_zona", SqlDbType.Int
        ).Value = (object?)idZona ?? DBNull.Value;

        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Asiento asiento = new Asiento();

            asiento.IdAsiento =
                Convert.ToInt32(reader["id_asiento"]);

            asiento.IdZona =
                Convert.ToInt32(reader["id_zona"]);

            asiento.IdEstadio =
                Convert.ToInt32(reader["id_estadio"]);

            asiento.NombreEstadio =
                Convert.ToString(reader["nombre_estadio"]) ?? "";

            asiento.NombreZona =
                Convert.ToString(reader["nombre_zona"]) ?? "";

            asiento.Fila =
                Convert.ToString(reader["fila"]) ?? "";

            asiento.Numero =
                Convert.ToInt32(reader["numero"]);

            asiento.Activo =
                reader["activo"] != DBNull.Value &&
                Convert.ToBoolean(reader["activo"]);

            asientos.Add(asiento);
        }

        return asientos;
    }
}