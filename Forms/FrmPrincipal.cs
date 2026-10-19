using Microsoft.Extensions.DependencyInjection;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;


public partial class FrmPrincipal : Form
{
    private IServiceProvider _serviceProvider = null!;
    private int _rolActual;
    private int _idRolAdministrador;
    
    private UsuarioCredenciales? _usuarioActual;

    
    public FrmPrincipal()
    {
        InitializeComponent();
        EnlazarBotones();
    }

    
    public FrmPrincipal(IServiceProvider serviceProvider) : this()
    {
        _serviceProvider = serviceProvider;
        Shown += (_, _) => PrimerAcceso();
    }

    private void EnlazarBotones()
    {
        
        btnUsuarios.Click += (_, _) => Abrir<FrmUsuarios>();
        btnClientes.Click += (_, _) => Abrir<FrmClientes>();
        btnCambiarUsuario.Click += (_, _) => CambiarUsuario();
        btnMiCuenta.Click += (_, _) => AbrirMiCuenta();
        btnEstadios.Click += (_, _) => Abrir<FrmEstadios>();
        btnZonas.Click += (_, _) => Abrir<FrmZonas>();
        btnAsientos.Click += (_, _) => Abrir<FrmAsientos>();
        btnEquipos.Click += (_, _) => Abrir<FrmEquipos>();
        btnPartidos.Click += (_, _) => Abrir<FrmPartidos>();
        btnVentas.Click += (_, _) => Abrir<FrmVentas>();
        btnCancelaciones.Click += (_, _) => Abrir<FrmCancelaciones>();
        btnFacturas.Click += (_, _) => Abrir<FrmFacturas>();
        btnReporteVentas.Click += (_, _) => Abrir<FrmReporteVentas>();
        btnReporteOcupacion.Click += (_, _) => Abrir<FrmReporteOcupacion>();
        btnHistorial.Click += (_, _) => Abrir<FrmHistorialClientes>();
        menuUsuarios.Click += (_, _) => Abrir<FrmUsuarios>();
        menuClientes.Click += (_, _) => Abrir<FrmClientes>();
        menuCambiarUsuario.Click += (_, _) => CambiarUsuario();
        menuMiCuenta.Click += (_, _) => AbrirMiCuenta();
        menuSalir.Click += (_, _) => Close();
    }

    
    private void PrimerAcceso()
    {
        try
        {
            IUsuarioService usuarios = _serviceProvider.GetRequiredService<IUsuarioService>();
            _idRolAdministrador = usuarios.ObtenerIdAdministrador();

            if (!usuarios.Consultar().Any(u => u.IdRol == _idRolAdministrador))
            {
                MessageBox.Show("Para acceder se requiere un Administrador. Regístrelo primero.",
                    "Primer uso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using FrmUsuarios alta = _serviceProvider.GetRequiredService<FrmUsuarios>();
                alta.ShowDialog(this);
            }

            if (!usuarios.Consultar().Any(u => u.IdRol == _idRolAdministrador))
            {
                MessageBox.Show("Se necesita al menos un Administrador para ingresar.");
                Close();
                return;
            }

            CambiarUsuario();
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se pudo iniciar el sistema. Verifique SQL Server.\n" + ex.Message,
                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
    }

    private void CambiarUsuario()
    {
       
        _rolActual = 0;
        _usuarioActual = null;
        Text = "Sistema de boletos - Sin sesión";

        using FrmAcceso acceso = _serviceProvider.GetRequiredService<FrmAcceso>();
        if (acceso.ShowDialog(this) != DialogResult.OK || acceso.UsuarioAutenticado is null)
        {
            Close();
            return;
        }

        UsuarioCredenciales nuevoUsuario = acceso.UsuarioAutenticado;

       
        if (nuevoUsuario.DebeCambiarContrasena)
        {
            IUsuarioService servicio = _serviceProvider.GetRequiredService<IUsuarioService>();
            using FrmMiCuenta cambio = new(servicio, nuevoUsuario, obligatorio: true);
            if (cambio.ShowDialog(this) != DialogResult.OK)
            {
                MessageBox.Show("Debes cambiar la contraseña temporal para ingresar.",
                    "Acceso pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }
            nuevoUsuario.DebeCambiarContrasena = false;
        }

        
        _usuarioActual = nuevoUsuario;
        _rolActual = nuevoUsuario.IdRol;
        Text = "Sistema de boletos - " + nuevoUsuario.NombreCompleto;
    }

    // Mi cuenta siempre corresponde al empleado autenticado; no muestra listados.
    private void AbrirMiCuenta()
    {
        if (_rolActual == 0 || _usuarioActual is null)
        {
            MessageBox.Show("Primero debes iniciar sesión.");
            return;
        }

        IUsuarioService servicio = _serviceProvider.GetRequiredService<IUsuarioService>();
        using FrmMiCuenta cuenta = new(servicio, _usuarioActual, obligatorio: false);
        cuenta.ShowDialog(this);
    }

    private void Abrir<T>() where T : Form
    {
        // Ninguna funcionalidad puede abrirse sin iniciar sesión.
        if (_rolActual == 0)
        {
            MessageBox.Show("Debes iniciar sesión para acceder al sistema.");
            return;
        }

        // Solo Administrador puede acceder a los módulos administrativos.
        // Operativo puede usar Clientes y Ventas.
        if (_rolActual != _idRolAdministrador &&
            typeof(T) != typeof(FrmClientes) &&
            typeof(T) != typeof(FrmVentas))
        {
            MessageBox.Show("Esta sección está reservada para administradores.");
            return;
        }

        using T form = _serviceProvider.GetRequiredService<T>();
        form.ShowDialog(this);
    }
}
