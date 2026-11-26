using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmReporteVentas : Form
{
    public FrmReporteVentas()
    {
        InitializeComponent();
        btnRegresar.Click += (_, _) => Close();
    }

    private readonly IReporteVentasService _service = null!;
    private readonly IEstadioService _estadios = null!;
    private readonly IPartidoService _partidos = null!;
    public FrmReporteVentas(IReporteVentasService service, IEstadioService estadios, IPartidoService partidos) : this()
    {
        _service = service; _estadios = estadios; _partidos = partidos;
        campo1.Enabled = campo2.Enabled = true;
        campo1.Format = campo2.Format = DateTimePickerFormat.Custom;
        campo1.CustomFormat = campo2.CustomFormat = "dd-MMM-yyyy";
        campo1.Value = DateTime.Today.AddDays(-30); campo2.Value = DateTime.Today;
        btnGuardar.Visible = false; btnConsultar.Enabled = true; btnConsultar.Text = "Aplicar filtros";
        btnConsultar.Click += (_, _) => Ejecutar(Lista);
        campo3.SelectionChangeCommitted += (_, _) => Ejecutar(CargarPartidos);
        Load += (_, _) => Ejecutar(() => {
            var estadios = _estadios.Consultar(); estadios.Insert(0, new Estadio { Nombre = "Todos" });
            Combo(campo3, estadios, "Nombre", "IdEstadio"); CargarPartidos(); Lista();
        });
    }
    private void CargarPartidos()
    {
        int? estadio = Id(campo3);
        var opciones = _partidos.Consultar().Where(p => !estadio.HasValue || p.IdEstadio == estadio.Value)
            .Select(p => new { Id = p.IdPartido, Texto = p.NombrePartido + " | " + p.NombreEstadio + " | " + p.FechaHora.ToString("dd-MMM-yyyy HH:mm", MX) }).ToList();
        opciones.Insert(0, new { Id = 0, Texto = "Todos" });
        Combo(campo4, opciones, "Texto", "Id"); campo4.DropDownWidth = 700;
    }
    private void Lista()
    {
        var datos = _service.Consultar(campo1.Value.Date, campo2.Value.Date, Id(campo3), Id(campo4));
        Tabla(datos,
            (nameof(ReporteVenta.Folio), "Folio", ""),
            (nameof(ReporteVenta.FechaVenta), "Fecha de venta", "dd-MMM-yyyy HH:mm"),
            (nameof(ReporteVenta.Estadio), "Estadio", ""),
            (nameof(ReporteVenta.Partido), "Partido", ""),
            (nameof(ReporteVenta.FechaPartido), "Fecha partido", "dd-MMM-yyyy HH:mm"),
            (nameof(ReporteVenta.Zona), "Zona", ""),
            (nameof(ReporteVenta.Cantidad), "Boletos", "N0"),
            (nameof(ReporteVenta.Subtotal), "Subtotal", "C2"),
            (nameof(ReporteVenta.Total), "Total", "C2"),
            (nameof(ReporteVenta.MetodoPago), "Método de pago", ""));
        lblDescripcion.Text = "Ingreso total: " + Dinero(datos.Sum(r => r.Total)) + " | Boletos vendidos: " + datos.Sum(r => r.Cantidad);
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
