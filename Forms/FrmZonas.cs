using System.Globalization;
using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmZonas : Form
{
    private readonly IZonaService _zonaService = null!;

    private readonly IEstadioService _estadioService = null!;

    // Constructor para el Designer
    public FrmZonas()
    {
        InitializeComponent();

        btnRegresar.Click += (_, _) => Close();
    }

    // Constructor que recibe los servicios
    public FrmZonas(
        IZonaService zonaService,
        IEstadioService estadioService) : this()
    {
        _zonaService = zonaService;
        _estadioService = estadioService;

        // Habilitar los campos
        campo1.Enabled = true;
        campo2.Enabled = true;
        campo3.Enabled = true;
        campo4.Enabled = true;

        btnGuardar.Enabled = true;

        dgvDatos.Enabled = true;

        // Configurar el ComboBox
        campo1.DropDownStyle =
            ComboBoxStyle.DropDownList;

        // Limitar los campos
        campo2.MaxLength = 50;
        campo3.MaxLength = 15;
        campo4.MaxLength = 10;

        // Configurar la tabla
        dgvDatos.AutoGenerateColumns = false;

        // Eventos
        btnGuardar.Click +=
            (_, _) => Ejecutar(Guardar);

        campo1.SelectionChangeCommitted +=
            (_, _) => Ejecutar(CargarLista);

        // Cargar información al abrir
        Load += (_, _) => Ejecutar(() =>
        {
            CargarEstadios();
            CargarLista();
        });
    }

    // Mostrar los estadios en el ComboBox
    private void CargarEstadios()
    {
        List<Estadio> estadios =
            _estadioService.Consultar();

        campo1.DisplayMember = "Nombre";

        campo1.ValueMember = "IdEstadio";

        campo1.DataSource = estadios;

        campo1.SelectedIndex = -1;
    }

    // Registrar una zona
    private void Guardar()
    {
        // Validar estadio
        if (campo1.SelectedItem is not Estadio estadio)
        {
            throw new ArgumentException(
                "Seleccione un estadio.");
        }

        // Validar precio
        if (!decimal.TryParse(
            campo3.Text,
            NumberStyles.AllowDecimalPoint,
            CultureInfo.GetCultureInfo("es-MX"),
            out decimal precio) || precio <= 0)
        {
            throw new ArgumentException(
                "Ingrese un precio válido.");
        }

        // Validar cupo
        if (!int.TryParse(campo4.Text, out int cupo)
            || cupo <= 0)
        {
            throw new ArgumentException(
                "Ingrese un cupo válido.");
        }

        Zona zona = new Zona();

        zona.IdEstadio = estadio.IdEstadio;
        zona.Nombre = campo2.Text;
        zona.PrecioBase = precio;
        zona.Cupo = cupo;

        // Confirmar registro
        DialogResult respuesta = MessageBox.Show(
            "¿Desea registrar esta zona?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
        {
            return;
        }

        // Registrar en la base de datos
        _zonaService.Registrar(zona);

        MessageBox.Show(
            "Zona registrada correctamente.",
            "Correcto",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        Limpiar();

        CargarLista();
    }

    // Consultar las zonas registradas
    private void CargarLista()
    {
        int? idEstadio = null;

        if (campo1.SelectedItem is Estadio estadio)
        {
            idEstadio = estadio.IdEstadio;
        }

        List<Zona> zonas =
            _zonaService.Consultar(idEstadio);

        dgvDatos.Rows.Clear();

        foreach (Zona zona in zonas)
        {
            int fila = dgvDatos.Rows.Add(
                zona.NombreEstadio,
                zona.Nombre,
                zona.PrecioBase.ToString(
                    "C2",
                    CultureInfo.GetCultureInfo("es-MX")),
                zona.Cupo
            );

            dgvDatos.Rows[fila].Tag = zona;
        }

        dgvDatos.ClearSelection();
    }

    // Limpiar los campos
    private void Limpiar()
    {
        campo2.Clear();
        campo3.Clear();
        campo4.Clear();

        campo2.Focus();
    }

    // Controlar errores
    private static void Ejecutar(Action operacion)
    {
        try
        {
            operacion();
        }
        catch (SqlException ex)
            when (ex.Number is 2627 or 2601)
        {
            MessageBox.Show(
                "Esta zona ya existe en el estadio.",
                "Duplicado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
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