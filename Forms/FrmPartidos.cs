using System.Globalization;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmPartidos : Form
{
    private readonly IPartidoService _partidoService = null!;

    private readonly IEstadioService _estadioService = null!;

    private readonly IEquipoService _equipoService = null!;

    private int _idUsuarioRegistro;

    // Constructor para el Designer.
    public FrmPartidos()
    {
        InitializeComponent();

        btnRegresar.Click += (_, _) => Close();
    }

    // Constructor para recibir los servicios.
    public FrmPartidos(
        IPartidoService partidoService,
        IEstadioService estadioService,
        IEquipoService equipoService) : this()
    {
        _partidoService = partidoService;
        _estadioService = estadioService;
        _equipoService = equipoService;

        // Habilitar controles.
        campo1.Enabled = true;
        campo2.Enabled = true;
        campo3.Enabled = true;
        campo4.Enabled = true;

        btnGuardar.Enabled = true;
        dgvDatos.Enabled = true;

        // Configurar ComboBox.
        campo1.DropDownStyle =
            ComboBoxStyle.DropDownList;

        campo3.DropDownStyle =
            ComboBoxStyle.DropDownList;

        campo4.DropDownStyle =
            ComboBoxStyle.DropDownList;

        campo5.DropDownStyle =
            ComboBoxStyle.DropDownList;

        // Estado inicial.
        campo5.Items.Clear();
        campo5.Items.Add("Programado");
        campo5.SelectedIndex = 0;
        campo5.Enabled = false;

        // Configurar fecha y hora.
        campo2.Format = DateTimePickerFormat.Custom;
        campo2.CustomFormat = "dd-MMM-yyyy HH:mm";
        campo2.MinDate = DateTime.Today;
        campo2.Value = DateTime.Now.AddDays(1);

        // Configurar tabla.
        dgvDatos.AutoGenerateColumns = false;
        dgvDatos.AllowUserToAddRows = false;
        dgvDatos.ReadOnly = true;

        // Eventos.
        btnGuardar.Click += (_, _) =>
            Ejecutar(Guardar);

        // Cargar información al abrir.
        Load += (_, _) => Ejecutar(() =>
        {
            CargarEstadios();
            CargarEquipos();
            CargarLista();
        });
    }

    // Recibir usuario autenticado.
    public void EstablecerUsuario(int idUsuario)
    {
        _idUsuarioRegistro = idUsuario;
    }

    // Cargar estadios.
    private void CargarEstadios()
    {
        List<Estadio> estadios =
            _estadioService.Consultar();

        campo1.DisplayMember = "Nombre";
        campo1.ValueMember = "IdEstadio";
        campo1.DataSource = estadios;

        campo1.SelectedIndex = -1;
    }

    // Cargar equipos activos.
    private void CargarEquipos()
    {
        List<Equipo> equipos =
            _equipoService.Consultar(true);

        // Equipo local.
        campo3.DisplayMember = "Nombre";
        campo3.ValueMember = "IdEquipo";
        campo3.DataSource = equipos.ToList();

        campo3.SelectedIndex = -1;

        // Equipo visitante.
        campo4.DisplayMember = "Nombre";
        campo4.ValueMember = "IdEquipo";
        campo4.DataSource = equipos.ToList();

        campo4.SelectedIndex = -1;
    }

    // Registrar partido.
    private void Guardar()
    {
        if (campo1.SelectedItem is not Estadio estadio)
        {
            throw new ArgumentException(
                "Seleccione un estadio.");
        }

        if (campo3.SelectedItem is not Equipo local)
        {
            throw new ArgumentException(
                "Seleccione el equipo local.");
        }

        if (campo4.SelectedItem is not Equipo visitante)
        {
            throw new ArgumentException(
                "Seleccione el equipo visitante.");
        }

        if (local.IdEquipo == visitante.IdEquipo)
        {
            throw new ArgumentException(
                "Los equipos deben ser diferentes.");
        }

        DateTime fecha = campo2.Value;

        fecha = new DateTime(
            fecha.Year,
            fecha.Month,
            fecha.Day,
            fecha.Hour,
            fecha.Minute,
            0);

        if (fecha <= DateTime.Now)
        {
            throw new ArgumentException(
                "Seleccione una fecha y hora futuras.");
        }

        Partido partido = new Partido();

        partido.IdEstadio = estadio.IdEstadio;
        partido.IdUsuarioRegistro = _idUsuarioRegistro;
        partido.IdEquipoLocal = local.IdEquipo;
        partido.IdEquipoVisitante = visitante.IdEquipo;
        partido.FechaHora = fecha;
        partido.Estado = "programado";

        // Confirmar registro.
        DialogResult respuesta = MessageBox.Show(
            "¿Desea registrar el partido?\n\n" +
            local.Nombre + " vs " + visitante.Nombre +
            "\nEstadio: " + estadio.Nombre +
            "\nFecha: " + fecha.ToString(
                "dd-MMM-yyyy HH:mm",
                CultureInfo.GetCultureInfo("es-MX")) +
            "\n\nSe generarán los boletos automáticamente.",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
        {
            return;
        }

        // Registrar partido y generar boletos.
        int boletos =
            _partidoService.Registrar(partido);

        MessageBox.Show(
            "Partido registrado correctamente.\n\n" +
            "Boletos generados: " + boletos,
            "Correcto",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        Limpiar();

        CargarLista();
    }

    // Mostrar partidos registrados.
    private void CargarLista()
    {
        List<Partido> partidos =
            _partidoService.Consultar();

        dgvDatos.Rows.Clear();

        foreach (Partido partido in partidos)
        {
            int fila = dgvDatos.Rows.Add(
                partido.NombreEstadio,

                partido.FechaHora.ToString(
                    "dd-MMM-yyyy HH:mm",
                    CultureInfo.GetCultureInfo("es-MX")),

                partido.EquipoLocal,

                partido.EquipoVisitante,

                partido.Estado
            );

            dgvDatos.Rows[fila].Tag = partido;
        }

        dgvDatos.ClearSelection();
    }

    // Limpiar campos.
    private void Limpiar()
    {
        campo1.SelectedIndex = -1;
        campo3.SelectedIndex = -1;
        campo4.SelectedIndex = -1;
        campo5.SelectedIndex = 0;

        campo2.MinDate = DateTime.Today;
        campo2.Value = DateTime.Now.AddDays(1);

        campo1.Focus();
    }

    // Controlar errores.
    private static void Ejecutar(Action operacion)
    {
        try
        {
            operacion();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}