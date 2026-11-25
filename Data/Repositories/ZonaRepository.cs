using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Models;

namespace TemplateCSharp.Data.Repositories;

public class ZonaRepository : IZonaRepository
{
    private readonly DatabaseConnection _database;

    public ZonaRepository(DatabaseConnection database)
    {
        _database = database;
    }

    // Registrar una zona
    public void Add(Zona zona)
    {
        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Zona_Crear", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@id_estadio", SqlDbType.Int
        ).Value = zona.IdEstadio;

        cmd.Parameters.Add(
            "@nombre", SqlDbType.VarChar, 50
        ).Value = zona.Nombre;

        SqlParameter precio = cmd.Parameters.Add(
            "@precio_base", SqlDbType.Decimal);

        precio.Precision = 10;
        precio.Scale = 2;
        precio.Value = zona.PrecioBase;

        cmd.Parameters.Add(
            "@cupo", SqlDbType.Int
        ).Value = zona.Cupo;

        conn.Open();

        cmd.ExecuteNonQuery();
    }

    // Consultar zonas
    public List<Zona> GetAll(int? idEstadio = null)
    {
        List<Zona> zonas = new List<Zona>();

        using SqlConnection conn =
            _database.CreateConnection();

        using SqlCommand cmd = new SqlCommand(
            "dbo.usp_Zona_Listar", conn);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(
            "@id_estadio", SqlDbType.Int
        ).Value = (object?)idEstadio ?? DBNull.Value;

        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Zona zona = new Zona();

            zona.IdZona =
                Convert.ToInt32(reader["id_zona"]);

            zona.IdEstadio =
                Convert.ToInt32(reader["id_estadio"]);

            zona.NombreEstadio =
                Convert.ToString(reader["nombre_estadio"]) ?? "";

            zona.Nombre =
                Convert.ToString(reader["nombre"]) ?? "";

            zona.PrecioBase =
                Convert.ToDecimal(reader["precio_base"]);

            zona.Cupo =
                Convert.ToInt32(reader["cupo"]);

            zona.Activa =
                reader["activa"] != DBNull.Value &&
                Convert.ToBoolean(reader["activa"]);

            zonas.Add(zona);
        }

        return zonas;
    }
}
