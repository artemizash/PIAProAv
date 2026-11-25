using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Models;

namespace TemplateCSharp.Data.Repositories;

public class EquipoRepository : IEquipoRepository
{
    private readonly DatabaseConnection _database;

    public EquipoRepository(DatabaseConnection database)
    {
        _database = database;
    }

    // Registrar un equipo.
    public void Add(Equipo equipo)
    {
        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Equipo_Crear", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@nombre", SqlDbType.VarChar, 100
        ).Value = equipo.Nombre;

        cmd.Parameters.Add(
            "@ciudad", SqlDbType.VarChar, 100
        ).Value = equipo.Ciudad;

        cmd.Parameters.Add(
            "@activo", SqlDbType.Bit
        ).Value = equipo.Activo;

        conn.Open();

        cmd.ExecuteNonQuery();
    }

    // Consultar equipos registrados.
    public List<Equipo> GetAll(bool soloActivos = false)
    {
        List<Equipo> equipos = new List<Equipo>();

        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Equipo_Listar", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@solo_activos", SqlDbType.Bit
        ).Value = soloActivos;

        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Equipo equipo = new Equipo();

            equipo.IdEquipo =
                Convert.ToInt32(reader["id_equipo"]);

            equipo.Nombre =
                Convert.ToString(reader["nombre"]) ?? "";

            equipo.Ciudad =
                Convert.ToString(reader["ciudad"]) ?? "";

            equipo.Activo =
                reader["activo"] != DBNull.Value &&
                Convert.ToBoolean(reader["activo"]);

            equipos.Add(equipo);
        }

        return equipos;
    }
}