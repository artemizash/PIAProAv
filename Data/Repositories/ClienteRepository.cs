using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Models;

namespace TemplateCSharp.Data.Repositories;


public class ClienteRepository : IClienteRepository
{
    private readonly DatabaseConnection _database;
    public ClienteRepository(DatabaseConnection database) => _database = database;

    private static SqlCommand CreateCommand(SqlConnection conn, string nombre)
        => new(nombre, conn) { CommandType = CommandType.StoredProcedure };

    private static Cliente Map(SqlDataReader r) => new()
    {
        IdCliente = r.GetInt32(r.GetOrdinal("id_cliente")),
        NombreCompleto = r.GetString(r.GetOrdinal("nombre_completo")),
        Rfc = r.GetString(r.GetOrdinal("rfc")),
        Domicilio = r.GetString(r.GetOrdinal("domicilio")),
        TelefonoCasa = r.GetString(r.GetOrdinal("telefono_casa")),
        TelefonoCelular = r.GetString(r.GetOrdinal("telefono_celular")),
        Correo = r.GetString(r.GetOrdinal("correo")),
        FechaNacimiento = r.GetDateTime(r.GetOrdinal("fecha_nacimiento")),
        FechaRegistro = r.GetDateTime(r.GetOrdinal("fecha_registro"))
    };

    private static void AddParams(SqlCommand cmd, Cliente c)
    {
        cmd.Parameters.Add("@nombre_completo",SqlDbType.VarChar,150).Value = c.NombreCompleto;
        cmd.Parameters.Add("@rfc",SqlDbType.VarChar,13).Value = c.Rfc;
        cmd.Parameters.Add("@domicilio",SqlDbType.VarChar,255).Value = c.Domicilio;
        cmd.Parameters.Add("@telefono_casa",SqlDbType.VarChar,15).Value = c.TelefonoCasa;
        cmd.Parameters.Add("@telefono_celular",SqlDbType.VarChar,15).Value = c.TelefonoCelular;
        cmd.Parameters.Add("@correo",SqlDbType.VarChar,100).Value = c.Correo;
        cmd.Parameters.Add("@fecha_nacimiento",SqlDbType.Date).Value = c.FechaNacimiento.Date;
    }

    public List<Cliente> GetAll(string filtro)
    {
        List<Cliente> result = [];
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Cliente_Listar");
        cmd.Parameters.Add("@filtro",SqlDbType.VarChar,150).Value = filtro;
        conn.Open();
        using SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read()) result.Add(Map(rd));
        return result;
    }

    public void Add(Cliente cliente)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Cliente_Crear");
        AddParams(cmd,cliente);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Update(Cliente cliente)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Cliente_Actualizar");
        cmd.Parameters.Add("@id_cliente",SqlDbType.Int).Value = cliente.IdCliente;
        AddParams(cmd,cliente);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Cliente_Eliminar");
        cmd.Parameters.Add("@id_cliente",SqlDbType.Int).Value = id;
        conn.Open();
        cmd.ExecuteNonQuery();
    }
}
