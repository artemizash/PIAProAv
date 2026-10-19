using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmClientes : Form
{
    private readonly IClienteService _service;
    private int _idSeleccionado;

    public FrmClientes()
    {
        InitializeComponent();
    }

    public FrmClientes(IClienteService service) : this()
    {
        _service = service;
        btnNuevo.Click += (_, _) => Limpiar();
        btnGuardar.Click += (_, _) => Ejecutar(() => { _service.Registrar(LeerFormulario()); Exito("Cliente registrado."); });
        btnActualizar.Click += (_, _) => Ejecutar(() => { _service.Actualizar(LeerFormulario()); Exito("Cliente actualizado."); });
        btnEliminar.Click += (_, _) => Ejecutar(EliminarSeleccionado);
        btnBuscar.Click += (_, _) => Ejecutar(CargarLista);
        dgvDatos.CellClick += DgvDatos_CellClick;
        Load += (_, _) => Ejecutar(() => { CargarLista(); Limpiar(); });
    }

    private Cliente LeerFormulario() => new()
    {
        IdCliente = _idSeleccionado,
        NombreCompleto = txtNombre.Text,
        Rfc = txtRfc.Text,
        Domicilio = txtDomicilio.Text,
        TelefonoCasa = txtCasa.Text,
        TelefonoCelular = txtCelular.Text,
        Correo = txtCorreo.Text,
        FechaNacimiento = dtpNacimiento.Value.Date
    };

    private void CargarLista()
    {
        dgvDatos.DataSource = null;
        dgvDatos.DataSource = _service.Consultar(txtFiltro.Text);
        dgvDatos.ClearSelection();
    }

    private void DgvDatos_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || dgvDatos.Rows[e.RowIndex].DataBoundItem is not Cliente c) return;
        _idSeleccionado = c.IdCliente;
        txtNombre.Text = c.NombreCompleto;
        txtRfc.Text = c.Rfc;
        txtDomicilio.Text = c.Domicilio;
        txtCasa.Text = c.TelefonoCasa;
        txtCelular.Text = c.TelefonoCelular;
        txtCorreo.Text = c.Correo;
        dtpNacimiento.Value = c.FechaNacimiento;
    }

    private void EliminarSeleccionado()
    {
        if (_idSeleccionado <= 0) throw new ArgumentException("Seleccione un cliente en la tabla.");
        if (MessageBox.Show("¿Eliminar cliente seleccionado?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        _service.Eliminar(_idSeleccionado);
        Exito("Cliente eliminado.");
    }

    private void Exito(string mensaje)
    {
        MessageBox.Show(mensaje, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        CargarLista(); Limpiar();
    }

    private void Limpiar()
    {
        _idSeleccionado = 0;
        txtNombre.Clear(); txtRfc.Clear(); txtDomicilio.Clear(); txtCasa.Clear();
        txtCelular.Clear(); txtCorreo.Clear();
        dtpNacimiento.Value = DateTime.Today.AddYears(-18);
        dgvDatos.ClearSelection();
        txtNombre.Focus();
    }

    private static void Ejecutar(Action accion)
    {
        try { accion(); }
        catch (SqlException ex) when (ex.Number is 2627 or 2601)
        { MessageBox.Show("Ya existe ese RFC o correo.", "Duplicado"); }
        catch (SqlException ex) when (ex.Number == 547)
        { MessageBox.Show("No se puede eliminar: el cliente tiene operaciones relacionadas.", "Restricción"); }
        catch (Exception ex)
        { MessageBox.Show(ex.Message, "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
}
