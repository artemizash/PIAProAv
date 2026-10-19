using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmMiCuenta : Form
{
    private IUsuarioService? _service;
    private UsuarioCredenciales? _usuario;
    private bool _obligatorio;

    
    public FrmMiCuenta()
    {
        InitializeComponent();
    }

    public FrmMiCuenta(IUsuarioService service, UsuarioCredenciales usuario, bool obligatorio) : this()
    {
        _service = service;
        _usuario = usuario;
        _obligatorio = obligatorio;

        lblNombreValor.Text = usuario.NombreCompleto;
        lblCorreoValor.Text = usuario.Correo;
        Rol? rol = service.ConsultarRoles().FirstOrDefault(r => r.IdRol == usuario.IdRol);
        lblRolValor.Text = rol?.Nombre ?? "Sin rol";

        if (_obligatorio)
        {
            Text = "Primer acceso - Cambiar contraseña temporal";
            lblTitulo.Text = "CAMBIO OBLIGATORIO";
            lblInstruccion.Text = "Por seguridad, cambia la contraseña temporal antes de ingresar al sistema.";
            btnCerrar.Text = "Salir sin acceder";
        }
        else
        {
            Text = "Mi cuenta - Sistema de boletos";
            lblTitulo.Text = "MI CUENTA";
            lblInstruccion.Text = "Puedes cambiar tu contraseña cuando lo necesites.";
            btnCerrar.Text = "Cerrar";
        }
    }

   
    private void btnGuardar_Click(object? sender, EventArgs e)
    {
        if (_service is null || _usuario is null)
        {
            MessageBox.Show("El servicio de usuarios no está disponible.");
            return;
        }

        try
        {
            if (txtNueva.Text != txtConfirmar.Text)
                throw new ArgumentException("La nueva contraseña y su confirmación no coinciden.");

            _service.CambiarMiContrasena(_usuario.IdUsuario, txtActual.Text, txtNueva.Text);

           
            _usuario.DebeCambiarContrasena = false;
            MessageBox.Show("Contraseña actualizada correctamente.", "Mi cuenta",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "No se pudo cambiar la contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            txtActual.Clear();
            txtNueva.Clear();
            txtConfirmar.Clear();
        }
    }

    private void btnCerrar_Click(object? sender, EventArgs e)
    {
        
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
