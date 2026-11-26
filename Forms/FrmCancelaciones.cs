using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmCancelaciones : Form
{
    public FrmCancelaciones()
    {
        InitializeComponent();
        btnRegresar.Click += (_, _) => Close();
    }

    private readonly ICancelacionService _service = null!;
    private readonly SesionActual _sesion = null!;
    public FrmCancelaciones(ICancelacionService service, SesionActual sesion) : this()
    {
        _service = service; _sesion = sesion;
        campo1.Enabled = campo2.Enabled = true;
        campo1.MaxLength = 36; campo2.MaxLength = 255;
        campo3.Items.Clear(); campo3.Items.Add(sesion.Nombre); campo3.SelectedIndex = 0; campo3.Enabled = false;
        btnConsultar.Enabled = btnGuardar.Enabled = true;
        btnConsultar.Text = "Buscar venta"; btnGuardar.Text = "Cancelar venta";
        btnConsultar.Click += (_, _) => Ejecutar(Buscar);
        Load += (_, _) => Ejecutar(Lista);
    }
    private Guid Folio() => Guid.TryParse(campo1.Text.Trim(), out Guid f) ? f : throw new ArgumentException("Ingrese un folio válido.");
    private void Buscar()
    {
        var datos = _service.Buscar(Folio());
        Tabla(datos,
            (nameof(VentaConsulta.Cliente), "Cliente", ""),
            (nameof(VentaConsulta.Partido), "Partido", ""),
            (nameof(VentaConsulta.Estadio), "Estadio", ""),
            (nameof(VentaConsulta.Zona), "Zona", ""),
            (nameof(VentaConsulta.Fila), "Fila", ""),
            (nameof(VentaConsulta.Numero), "Asiento", "N0"),
            (nameof(VentaConsulta.PrecioUnitario), "Precio", "C2"),
            (nameof(VentaConsulta.EstadoVenta), "Estado", ""),
            (nameof(VentaConsulta.TotalVenta), "Total compra", "C2"));
        if (datos.Count == 0) MessageBox.Show("No se encontró la compra.");
    }
    private void Lista() => Tabla(_service.Consultar(),
            (nameof(Cancelacion.Folio), "Folio", ""),
            (nameof(Cancelacion.Motivo), "Motivo", ""),
            (nameof(Cancelacion.Administrador), "Administrador", ""),
            (nameof(Cancelacion.FechaCancelacion), "Fecha y hora", "dd-MMM-yyyy HH:mm"));
    // Evento ya conectado en el Designer.
    private void btnGuardar_Click(object sender, EventArgs e) => Ejecutar(() =>
    {
        Guid folio = Folio();
        string motivo = campo2.Text.Trim();
        if (motivo.Length == 0) throw new ArgumentException("Ingrese el motivo.");
        var venta = _service.Buscar(folio);
        if (venta.Count == 0 || venta[0].EstadoVenta != "completada") throw new ArgumentException("No existe una venta vigente.");
        if (MessageBox.Show("¿Cancelar la compra y liberar sus boletos?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        _service.Registrar(folio, _sesion.IdUsuario, motivo);
        MessageBox.Show("Compra cancelada y factura invalidada.");
        campo1.Clear(); campo2.Clear(); Lista();
    });
    private void lblCampo1_Click(object sender, EventArgs e) { }

    private static readonly System.Globalization.CultureInfo MX = System.Globalization.CultureInfo.GetCultureInfo("es-MX");
    private static void Ejecutar(Action accion)
    {
        try { accion(); }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
    }
    private void Tabla<T>(List<T> datos, params (string Propiedad, string Titulo, string Formato)[] columnas)
    {
        dgvDatos.DataSource = null;
        dgvDatos.Columns.Clear();
        dgvDatos.AutoGenerateColumns = false;
        dgvDatos.Enabled = true;
        dgvDatos.ReadOnly = true;
        dgvDatos.AllowUserToAddRows = false;
        dgvDatos.MultiSelect = false;
        dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        foreach (var col in columnas)
        {
            DataGridViewTextBoxColumn c = new() { DataPropertyName = col.Propiedad, HeaderText = col.Titulo, AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells };
            c.DefaultCellStyle.Format = col.Formato;
            c.DefaultCellStyle.FormatProvider = MX;
            dgvDatos.Columns.Add(c);
        }
        dgvDatos.DataSource = datos;
        dgvDatos.ClearSelection();
        dgvDatos.CurrentCell = null;
    }
    private static string Dinero(decimal valor) => valor.ToString("C2", MX);

}
