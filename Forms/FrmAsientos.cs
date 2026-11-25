using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmAsientos : Form
{
    private readonly IAsientoService _asientoService = null!;

    private readonly IZonaService _zonaService = null!;

    private readonly IEstadioService _estadioService = null!;

    // Constructor para el Designer.
    public FrmAsientos()
    {
        InitializeComponent();

        btnRegresar.Click += (_, _) => Close();
    }

    // Constructor para recibir los servicios.
    public FrmAsientos(
        IAsientoService asientoService,
        IZonaService zonaService,
        IEstadioService estadioService) : this()
    {
        _asientoService = asientoService;
        _zonaService = zonaService;
        _estadioService = estadioService;

        // Habilitar los controles.
        campo1.Enabled = true;
        campo2.Enabled = true;
        campo3.Enabled = true;
        campo4.Enabled = true;

        btnGuardar.Enabled = true;

        dgvDatos.Enabled = true;

        // Configurar los campos.
        campo1.DropDownStyle = ComboBoxStyle.DropDownList;
        campo2.DropDownStyle = ComboBoxStyle.DropDownList;

        campo3.MaxLength = 5;
        campo4.MaxLength = 21;

        campo4.PlaceholderText = "Ejemplo: 1 o 1-10";

        dgvDatos.AutoGenerateColumns = false;

        // Cambiar las zonas al seleccionar un estadio.
        campo1.SelectionChangeCommitted += (_, _) =>
            Ejecutar(() =>
            {
                CargarZonas();
                CargarLista();
            });

        // Consultar los asientos de la zona seleccionada.
        campo2.SelectionChangeCommitted += (_, _) =>
            Ejecutar(CargarLista);

        // Registrar asientos.
        btnGuardar.Click += (_, _) =>
            Ejecutar(Guardar);

        // Cargar la informacion al abrir.
        Load += (_, _) => Ejecutar(() =>
        {
            CargarEstadios();
            CargarZonas();
            CargarLista();
        });
    }

    // Llenar el ComboBox de estadios.
    private void CargarEstadios()
    {
        List<Estadio> estadios =
            _estadioService.Consultar();

        campo1.DisplayMember = "Nombre";
        campo1.ValueMember = "IdEstadio";
        campo1.DataSource = estadios;

        campo1.SelectedIndex = -1;
    }

    // Llenar el ComboBox de zonas.
    private void CargarZonas()
    {
        campo2.DataSource = null;

        if (campo1.SelectedItem is not Estadio estadio)
        {
            return;
        }

        List<Zona> zonas =
            _zonaService.Consultar(estadio.IdEstadio);

        // Mostrar solamente zonas activas.
        zonas = zonas.Where(z => z.Activa).ToList();

        campo2.DisplayMember = "Nombre";
        campo2.ValueMember = "IdZona";
        campo2.DataSource = zonas;

        campo2.SelectedIndex = -1;
    }

    // Registrar uno o varios asientos.
    private void Guardar()
    {
        if (campo1.SelectedItem is not Estadio)
        {
            throw new ArgumentException(
                "Seleccione un estadio.");
        }

        if (campo2.SelectedItem is not Zona zona)
        {
            throw new ArgumentException(
                "Seleccione una zona.");
        }

        // Separar el numero inicial y final.
        string[] numeros = campo4.Text.Trim().Split('-');

        int inicio;
        int fin;

        if (numeros.Length == 1)
        {
            // Registrar un solo asiento.
            if (!int.TryParse(numeros[0], out inicio))
            {
                throw new ArgumentException(
                    "Ingrese un numero valido.");
            }

            fin = inicio;
        }
        else if (numeros.Length == 2)
        {
            // Registrar un rango.
            if (!int.TryParse(numeros[0], out inicio)
                || !int.TryParse(numeros[1], out fin))
            {
                throw new ArgumentException(
                    "Ingrese un rango valido. Ejemplo: 1-10.");
            }
        }
        else
        {
            throw new ArgumentException(
                "Ingrese un numero o rango valido.");
        }

        if (inicio <= 0 || fin < inicio)
        {
            throw new ArgumentException(
                "El rango de asientos no es valido.");
        }

        long cantidad = (long)fin - inicio + 1;

        // Confirmar el registro.
        DialogResult respuesta = MessageBox.Show(
            "¿Desea registrar " + cantidad + " asiento(s)?",
            "Confirmacion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
        {
            return;
        }

        // Enviar los datos al servicio.
        _asientoService.Registrar(
            zona.IdZona,
            campo3.Text,
            inicio,
            fin);

        MessageBox.Show(
            "Asientos registrados correctamente.",
            "Correcto",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        Limpiar();

        CargarLista();
    }

    // Mostrar los asientos registrados.
    private void CargarLista()
    {
        int? idEstadio = null;
        int? idZona = null;

        if (campo1.SelectedItem is Estadio estadio)
        {
            idEstadio = estadio.IdEstadio;
        }

        if (campo2.SelectedItem is Zona zona)
        {
            idZona = zona.IdZona;
        }

        List<Asiento> asientos =
            _asientoService.Consultar(
                idEstadio,
                idZona);

        dgvDatos.Rows.Clear();

        foreach (Asiento asiento in asientos)
        {
            int fila = dgvDatos.Rows.Add(
                asiento.NombreEstadio,
                asiento.NombreZona,
                asiento.Fila,
                asiento.Numero
            );

            dgvDatos.Rows[fila].Tag = asiento;
        }

        dgvDatos.ClearSelection();
    }

    // Limpiar los campos de captura.
    private void Limpiar()
    {
        campo3.Clear();
        campo4.Clear();

        campo3.Focus();
    }

    // Controlar errores.
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
                "Uno o varios asientos ya existen.",
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

    // Evento original utilizado por el Designer.
    private void lblCampo1_Click(
        object sender,
        EventArgs e)
    {
    }
}