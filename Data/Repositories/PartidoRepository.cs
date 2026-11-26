using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Models;

namespace TemplateCSharp.Data.Repositories;

public class PartidoRepository : IPartidoRepository
{
    private readonly DatabaseConnection _database;

    public PartidoRepository(DatabaseConnection database)
    {
        _database = database;
    }

    // Registrar partido y generar boletos.
    public int Add(Partido partido)
    {
        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Partido_Crear", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@id_estadio", SqlDbType.Int
        ).Value = partido.IdEstadio;

        cmd.Parameters.Add(
            "@id_usuario_registro", SqlDbType.Int
        ).Value = partido.IdUsuarioRegistro;

        cmd.Parameters.Add(
            "@fecha_hora", SqlDbType.DateTime2
        ).Value = partido.FechaHora;

        cmd.Parameters.Add(
            "@id_equipo_local", SqlDbType.Int
        ).Value = partido.IdEquipoLocal;

        cmd.Parameters.Add(
            "@id_equipo_visitante", SqlDbType.Int
        ).Value = partido.IdEquipoVisitante;

        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            partido.IdPartido =
                Convert.ToInt32(reader["id_partido"]);

            partido.IdPartidoEquipo =
                Convert.ToInt32(reader["id_partido_equipo"]);

            return Convert.ToInt32(
                reader["boletos_generados"]);
        }

        throw new InvalidOperationException(
            "No se obtuvo el resultado del registro.");
    }

    // Consultar partidos.
    public List<Partido> GetAll(
        bool disponibles = false,
        string? filtro = null)
    {
        List<Partido> partidos = new List<Partido>();

        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Partido_Listar", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@disponibles", SqlDbType.Bit
        ).Value = disponibles;

        cmd.Parameters.Add(
            "@filtro", SqlDbType.VarChar, 150
        ).Value = (object?)filtro ?? DBNull.Value;

        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Partido partido = new Partido();

            partido.IdPartido =
                Convert.ToInt32(reader["id_partido"]);

            partido.IdEstadio =
                Convert.ToInt32(reader["id_estadio"]);

            partido.IdPartidoEquipo =
                Convert.ToInt32(reader["id_partido_equipo"]);

            partido.NombreEstadio =
                Convert.ToString(reader["estadio"]) ?? "";

            partido.EquipoLocal =
                Convert.ToString(reader["equipo_local"]) ?? "";

            partido.EquipoVisitante =
                Convert.ToString(reader["equipo_visitante"]) ?? "";

            partido.FechaHora =
                Convert.ToDateTime(reader["fecha_hora"]);

            partido.Estado =
                Convert.ToString(reader["estado"]) ?? "";

            partidos.Add(partido);
        }

        return partidos;
    }
}