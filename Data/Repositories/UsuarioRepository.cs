using System.Data;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Repositories;
using TemplateCSharp.Models;

namespace TemplateCSharp.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DatabaseConnection _database;
    public UsuarioRepository(DatabaseConnection database) => _database = database;

    private SqlCommand CreateCommand(SqlConnection connection, string name)
        => new(name, connection) { CommandType = CommandType.StoredProcedure };

    private static Usuario Map(SqlDataReader r) => new()
    {
        IdUsuario = r.GetInt32(r.GetOrdinal("id_usuario")),
        IdRol = r.GetInt32(r.GetOrdinal("id_rol")),
        RolNombre = r.GetString(r.GetOrdinal("rol_nombre")),
        NombreCompleto = r.GetString(r.GetOrdinal("nombre_completo")),
        Correo = r.GetString(r.GetOrdinal("correo")),
        NumeroNomina = r.GetString(r.GetOrdinal("numero_nomina")),
        FechaNacimiento = r.GetDateTime(r.GetOrdinal("fecha_nacimiento")),
        FechaRegistro = r.GetDateTime(r.GetOrdinal("fecha_registro"))
    };

    public List<Usuario> GetAll(string filtro)
    {
        List<Usuario> result = [];
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Usuario_Listar");
        cmd.Parameters.Add("@filtro", SqlDbType.VarChar, 150).Value = filtro;
        conn.Open();
        using SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read()) result.Add(Map(rd));
        return result;
    }

    public List<Rol> GetRoles()
    {
        List<Rol> roles = [];
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Rol_Listar");
        conn.Open();
        using SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read()) roles.Add(new Rol
        {
            IdRol = rd.GetInt32(rd.GetOrdinal("id_rol")),
            Nombre = rd.GetString(rd.GetOrdinal("nombre"))
        });
        return roles;
    }

    private static void AddUserParams(SqlCommand cmd, Usuario u)
    {
        cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = u.IdRol;
        cmd.Parameters.Add("@correo", SqlDbType.VarChar, 100).Value = u.Correo;
        cmd.Parameters.Add("@nombre_completo", SqlDbType.VarChar, 150).Value = u.NombreCompleto;
        cmd.Parameters.Add("@numero_nomina", SqlDbType.VarChar, 20).Value = u.NumeroNomina;
        cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.Date).Value = u.FechaNacimiento.Date;
    }

    public void Add(Usuario usuario, string hashContrasena)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Usuario_Crear");
        AddUserParams(cmd, usuario);
        cmd.Parameters.Add("@contrasena", SqlDbType.VarChar, 255).Value = hashContrasena;
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Update(Usuario usuario)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Usuario_Actualizar");
        cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = usuario.IdUsuario;
        AddUserParams(cmd, usuario);
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Usuario_Eliminar");
        cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public List<string> GetRecentPasswordHashes(int id)
    {
        List<string> hashes = [];
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Usuario_ContrasenasRecientes");
        cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
        conn.Open();
        using SqlDataReader rd = cmd.ExecuteReader();
        do
        {
            while (rd.Read()) hashes.Add(rd.GetString(0));
        } while (rd.NextResult());
        return hashes;
    }

    public void ChangePassword(int id, string nuevoHash, bool esTemporal)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Usuario_CambiarContrasena");
        cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@contrasena_nueva", SqlDbType.VarChar, 255).Value = nuevoHash;
        // True = contraseña temporal; false = contraseña definitiva elegida por el empleado.
        cmd.Parameters.Add("@es_temporal", SqlDbType.Bit).Value = esTemporal;
        conn.Open();
        cmd.ExecuteNonQuery();
    }

    public UsuarioCredenciales? FindCredentials(string correo)
    {
        using SqlConnection conn = _database.CreateConnection();
        using SqlCommand cmd = CreateCommand(conn, "dbo.usp_Usuario_BuscarLogin");
        cmd.Parameters.Add("@correo", SqlDbType.VarChar, 100).Value = correo;
        conn.Open();
        using SqlDataReader rd = cmd.ExecuteReader();
        if (!rd.Read()) return null;
        return new UsuarioCredenciales
        {
            IdUsuario = rd.GetInt32(rd.GetOrdinal("id_usuario")),
            Correo = rd.GetString(rd.GetOrdinal("correo")),
            HashContrasena = rd.GetString(rd.GetOrdinal("contrasena")),
            IdRol = rd.GetInt32(rd.GetOrdinal("id_rol")),
            NombreCompleto = rd.GetString(rd.GetOrdinal("nombre_completo")),
            DebeCambiarContrasena = rd.GetBoolean(rd.GetOrdinal("debe_cambiar_contrasena"))
        };
    }
}
