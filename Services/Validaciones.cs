using System.Net.Mail;
using System.Text.RegularExpressions;

namespace TemplateCSharp.Services;

// Reglas reutilizables (para Usuarios y Clientes) sin depender de la interfaz.
public static class Validaciones
{
    public static void Obligatorio(string valor, string nombre, int largoMaximo)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException($"Debe escribir {nombre}.");
        if (valor.Trim().Length > largoMaximo)
            throw new ArgumentException($"{nombre} permite hasta {largoMaximo} caracteres.");
    }

    public static void Nombre(string valor)
    {
        Obligatorio(valor,"el nombre completo",150);
        if (!Regex.IsMatch(valor, @"^[\p{L}\p{M}.'\- ]+$"))
            throw new ArgumentException("El nombre debe contener letras y espacios.");
    }

    public static void Correo(string valor)
    {
        Obligatorio(valor,"el correo",100);
        if (!MailAddress.TryCreate(valor, out MailAddress? email) ||
            !string.Equals(email.Address, valor, StringComparison.OrdinalIgnoreCase) ||
            !valor.Contains('.'))
            throw new ArgumentException("Escriba un correo electrónico válido.");
    }

    public static void Nacimiento(DateTime fecha)
    {
        if (fecha.Date >= DateTime.Today || fecha.Year < 1900)
            throw new ArgumentException("La fecha de nacimiento debe ser válida y anterior a hoy.");
    }
}
