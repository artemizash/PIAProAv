using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;


public partial class FrmUsuarios : Form
{
    private readonly IUsuarioService _service;
    private int _idSeleccionado;

    
    public FrmUsuarios()
    {
        InitializeComponent();
    }

    
    public FrmUsuarios(IUsuarioService service) : this()
    {
        _service = service; // Dependency Injection por interfaz.
        btnNuevo.Click += (_, _) => Limpiar();
        btnGuardar.Click += (_, _) => Ejecutar(() => { _service.Registrar(LeerFormulario(), txtContrasena.Text); Exito("Usuario guardado."); });
        btnActualizar.Click += (_, _) => Ejecutar(() => { _service.Actualizar(LeerFormulario(),
            string.IsNullOrWhiteSpace(txtContrasena.Text) ? null : txtContrasena.Text); Exito("Usuario actualizado."); });
        btnEliminar.Click += (_, _) => Ejecutar(EliminarSeleccionado);
        btnBuscar.Click += (_, _) => Ejecutar(CargarLista);
        dgvDatos.CellClick += DgvDatos_CellClick;
        Load += (_, _) => Ejecutar(() =>
        {
            cmbRol.DataSource = _service.ConsultarRoles();
            cmbRol.DisplayMember = nameof(Rol.Nombre);
            cmbRol.ValueMember = nameof(Rol.IdRol);
            CargarLista();
            Limpiar();
        });
    }

    
    private Usuario LeerFormulario() => new()
    {
        IdUsuario = _idSeleccionado,
        IdRol = (int)(cmbRol.SelectedValue ?? 0),
        NombreCompleto = txtNombre.Text,
        Correo = txtCorreo.Text,
        NumeroNomina = txtNomina.Text,
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
        if (e.RowIndex < 0 || dgvDatos.Rows[e.RowIndex].DataBoundItem is not Usuario u) return;
        _idSeleccionado = u.IdUsuario;
        txtNombre.Text = u.NombreCompleto;
        txtCorreo.Text = u.Correo;
        txtNomina.Text = u.NumeroNomina;
        cmbRol.SelectedValue = u.IdRol;
        dtpNacimiento.Value = u.FechaNacimiento;
        txtContrasena.Clear(); // Nunca se muestra un hash ni la contraseña anterior.
    }

    private void EliminarSeleccionado()
    {
        if (_idSeleccionado <= 0) throw new ArgumentException("Seleccione un usuario en la tabla.");
        if (MessageBox.Show("¿Eliminar usuario seleccionado?", "Confirmación",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        _service.Eliminar(_idSeleccionado);
        Exito("Usuario eliminado.");
    }

    private void Exito(string mensaje)
    {
        MessageBox.Show(mensaje, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        CargarLista();
        Limpiar();
    }

    private void Limpiar()
    {
        _idSeleccionado = 0;
        txtNombre.Clear(); txtCorreo.Clear(); txtNomina.Clear(); txtContrasena.Clear();
        if (cmbRol.Items.Count > 0) cmbRol.SelectedIndex = 0;
        dtpNacimiento.Value = DateTime.Today.AddYears(-18);
        dgvDatos.ClearSelection();
        txtNombre.Focus();
    }

    
    private static void Ejecutar(Action operacion)
    {
        try { operacion(); }
        catch (SqlException ex) when (ex.Number is 2627 or 2601)
        { MessageBox.Show("Ya existe un correo o número de nómina igual.", "Duplicado"); }
        catch (SqlException ex) when (ex.Number == 547)
        { MessageBox.Show("No se puede eliminar: hay registros relacionados.", "Restricción"); }
        catch (Exception ex)
        { MessageBox.Show(ex.Message, "No se completó la operación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
}
