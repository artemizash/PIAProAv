using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmHistorialClientes : Form
{
    public FrmHistorialClientes()
    {
        InitializeComponent();
        btnRegresar.Click += (_, _) => Close();
    }

    private readonly IHistorialClientesService _service = null!;
    private readonly IClienteService _clientes = null!;
    private readonly CheckBox _orden = new() { Text = "Ordenar por fecha de partido", AutoSize = true };
    public FrmHistorialClientes(IHistorialClientesService service, IClienteService clientes) : this()
    {
        _service = service; _clientes = clientes;
        campo2.Enabled = campo3.Enabled = true;
        campo2.ShowCheckBox = campo3.ShowCheckBox = true;
        campo2.Checked = campo3.Checked = false;
        campo2.Format = campo3.Format = DateTimePickerFormat.Custom;
        campo2.CustomFormat = campo3.CustomFormat = "dd-MMM-yyyy";
        _orden.Location = new Point(campo3.Left, campo3.Bottom + 8); Controls.Add(_orden); _orden.BringToFront();
        btnGuardar.Enabled = btnConsultar.Enabled = true; btnGuardar.Text = "Buscar cliente"; btnConsultar.Text = "Consultar historial";
        btnGuardar.Click += (_, _) => Ejecutar(Buscar);
        btnConsultar.Click += (_, _) => Ejecutar(Lista);
        campo1.SelectionChangeCommitted += (_, _) => Ejecutar(Lista);
        lblDescripcion.Cursor = Cursors.Hand; lblDescripcion.Click += (_, _) => Ejecutar(VerCliente);
        Load += (_, _) => Ejecutar(() => CargarClientes(""));
    }
    private void CargarClientes(string filtro)
    {
        var datos = _clientes.Consultar(filtro).Select(c => new { Id = c.IdCliente, Texto = c.NombreCompleto + " | " + c.Correo }).ToList();
        Combo(campo1, datos, "Texto", "Id", false); campo1.DropDownWidth = 700;
        Tabla(new List<HistorialCompra>(), (nameof(HistorialCompra.Folio), "Folio", ""));
        lblDescripcion.Text = "Seleccione un cliente para consultar su historial.";
    }
    private void Buscar()
    {
        string filtro = Microsoft.VisualBasic.Interaction.InputBox("Escribe apellidos o correo.", "Buscar cliente", "");
        CargarClientes(filtro.Trim());
        if (campo1.Items.Count == 0) MessageBox.Show("No se encontraron clientes."); else campo1.DroppedDown = true;
    }
    private Cliente ClienteActual()
    {
        int id = Id(campo1) ?? throw new ArgumentException("Seleccione un cliente.");
        return _clientes.Consultar().FirstOrDefault(c => c.IdCliente == id) ?? throw new ArgumentException("Cliente no encontrado.");
    }
    private void VerCliente()
    {
        var c = ClienteActual();
        MessageBox.Show(c.NombreCompleto + "\nRFC: " + c.Rfc + "\nDomicilio: " + c.Domicilio + "\nCorreo: " + c.Correo + "\nCasa: " + c.TelefonoCasa + "\nCelular: " + c.TelefonoCelular + "\nNacimiento: " + c.FechaNacimiento.ToString("dd-MMM-yyyy", MX), "Datos del cliente");
    }
    private void Lista()
    {
        var c = ClienteActual();
        lblDescripcion.Text = c.NombreCompleto + " | " + c.Correo + " | RFC: " + c.Rfc + " (clic para ver datos)";
        var datos = _service.Consultar(c.IdCliente, campo2.Checked ? campo2.Value.Date : null, campo3.Checked ? campo3.Value.Date : null, _orden.Checked);
        Tabla(datos,
            (nameof(HistorialCompra.Folio), "Folio", ""),
            (nameof(HistorialCompra.FechaVenta), "Fecha compra", "dd-MMM-yyyy HH:mm"),
            (nameof(HistorialCompra.Partido), "Partido", ""),
            (nameof(HistorialCompra.Estadio), "Estadio", ""),
            (nameof(HistorialCompra.Zona), "Zona", ""),
            (nameof(HistorialCompra.FechaPartido), "Fecha partido", "dd-MMM-yyyy HH:mm"),
            (nameof(HistorialCompra.Cantidad), "Boletos", "N0"),
            (nameof(HistorialCompra.Subtotal), "Subtotal", "C2"),
            (nameof(HistorialCompra.Total), "Total", "C2"),
            (nameof(HistorialCompra.MetodoPago), "Método de pago", ""),
            (nameof(HistorialCompra.FolioFactura), "Factura", ""),
            (nameof(HistorialCompra.EstadoVenta), "Estado", ""));
    }

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

    private static void Combo(ComboBox c, object datos, string texto, string id, bool seleccionar = true)
    {
        c.Enabled = true; c.DropDownStyle = ComboBoxStyle.DropDownList;
        c.DataSource = null; c.DisplayMember = texto; c.ValueMember = id; c.DataSource = datos;
        if (!seleccionar) c.SelectedIndex = -1;
    }
    private static int? Id(ComboBox c) => c.SelectedValue is int n && n > 0 ? n : null;

}
