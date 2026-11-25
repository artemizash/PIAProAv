using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmEquipos : Form
{
    private readonly IEquipoService _service = null!;

    // Constructor para el Designer.
    public FrmEquipos()
    {
        InitializeComponent();

        btnRegresar.Click += (_, _) => Close();
    }

    // Constructor para recibir el servicio.
    public FrmEquipos(IEquipoService service) : this()
    {
        _service = service;

        // Habilitar controles.
        campo1.Enabled = true;
        campo2.Enabled = true;
        campo3.Enabled = true;

        btnGuardar.Enabled = true;

        dgvDatos.Enabled = true;

        // Limitar longitud de los campos.
        campo1.MaxLength = 100;
        campo2.MaxLength = 100;

        // Configurar ComboBox de estado.
        campo3.DropDownStyle =
            ComboBoxStyle.DropDownList;

        campo3.Items.Clear();

        campo3.Items.Add("Sí");
        campo3.Items.Add("No");

        // Seleccionar activo por defecto.
        campo3.SelectedIndex = 0;

        // Configurar tabla.
        dgvDatos.AutoGenerateColumns = false;
        dgvDatos.AllowUserToAddRows = false;

        // Registrar eventos.
        btnGuardar.Click += (_, _) =>
            Ejecutar(Guardar);

        // Consultar automaticamente al abrir.
        Load += (_, _) => Ejecutar(CargarLista);
    }

    // Registrar un equipo.
    private void Guardar()
    {
        if (campo3.SelectedIndex == -1)
        {
            throw new ArgumentException(
                "Seleccione el estado del equipo.");
        }

        Equipo equipo = new Equipo();

        equipo.Nombre = campo1.Text;

        equipo.Ciudad = campo2.Text;

        equipo.Activo = campo3.SelectedIndex == 0;

        // Confirmar el registro.
        DialogResult respuesta = MessageBox.Show(
            "¿Desea registrar este equipo?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
        {
            return;
        }

        // Registrar mediante el servicio.
        _service.Registrar(equipo);

        MessageBox.Show(
            "Equipo registrado correctamente.",
            "Correcto",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        Limpiar();

        CargarLista();
    }

    // Mostrar los equipos registrados.
    private void CargarLista()
    {
        List<Equipo> equipos =
            _service.Consultar();

        dgvDatos.Rows.Clear();

        foreach (Equipo equipo in equipos)
        {
            int fila = dgvDatos.Rows.Add(
                equipo.Nombre,
                equipo.Ciudad,
                equipo.Activo ? "Sí" : "No"
            );

            dgvDatos.Rows[fila].Tag = equipo;
        }

        dgvDatos.ClearSelection();
    }

    // Limpiar los campos de captura.
    private void Limpiar()
    {
        campo1.Clear();

        campo2.Clear();

        campo3.SelectedIndex = 0;

        campo1.Focus();
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
                "El equipo ya se encuentra registrado.",
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
    private void lblCampo3_Click(
        object sender,
        EventArgs e)
    {
    }
}