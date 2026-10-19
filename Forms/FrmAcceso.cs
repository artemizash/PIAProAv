using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmAcceso : Form
{
    private IAccesoService? _accesoService;

    public UsuarioCredenciales? UsuarioAutenticado { get; private set; }

    public FrmAcceso()
    {
        InitializeComponent();
    }
    public FrmAcceso(IAccesoService accesoService) : this()
    {
        _accesoService = accesoService;
    }

    private void btnEntrar_Click(object? sender, EventArgs e)
    {
        if (_accesoService is null)
        {
            MessageBox.Show("El servicio de acceso no está disponible.",
                "Error de configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        try
        {
            UsuarioCredenciales? usuario = _accesoService.IniciarSesion(
                txtCorreo.Text, txtContrasena.Text);

            if (usuario is null)
            {
                MessageBox.Show("Correo o contraseña incorrectos.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return;
            }

            UsuarioAutenticado = usuario;
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "No se pudo iniciar sesión",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            txtContrasena.Clear();
        }
    }
}
