using System.Security.Cryptography;

namespace TemplateCSharp.Services;

// Las contraseñas se almacenan como HASH con salt usando PBKDF2 (nunca texto plano).
public static class ContrasenaHelper
{
    private const int Iteraciones = 100_000;
    private const int SaltSize = 16;
    private const int HashSize = 32;

    public static void Validar(string contrasena)
    {
        if (string.IsNullOrWhiteSpace(contrasena) || contrasena.Length < 8 ||
            !contrasena.Any(char.IsUpper) || !contrasena.Any(char.IsLower) ||
            !contrasena.Any(c => !char.IsLetterOrDigit(c)))
            throw new ArgumentException(
                "La contraseña necesita 8 caracteres, una mayúscula, una minúscula y un símbolo.");
    }

    public static string CrearHash(string contrasena)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(contrasena, salt, Iteraciones, HashAlgorithmName.SHA256, HashSize);
        return $"PBKDF2${Iteraciones}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public static bool Verificar(string contrasena, string guardado)
    {
        try
        {
            string[] partes = guardado.Split('$');
            if (partes.Length != 4 || partes[0] != "PBKDF2") return false;
            int iter = int.Parse(partes[1]);
            if (iter < 10_000 || iter > 2_000_000) return false;
            byte[] salt = Convert.FromBase64String(partes[2]);
            byte[] esperado = Convert.FromBase64String(partes[3]);
            byte[] obtenido = Rfc2898DeriveBytes.Pbkdf2(contrasena, salt, iter,
                HashAlgorithmName.SHA256, esperado.Length);
            return CryptographicOperations.FixedTimeEquals(obtenido, esperado);
        }
        catch (Exception ex) when (ex is FormatException or ArgumentException or OverflowException)
        {
            return false;
        }
    }
}
