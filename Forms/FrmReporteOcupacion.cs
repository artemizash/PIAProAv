using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmReporteOcupacion : Form
{
    public FrmReporteOcupacion()
    {
        InitializeComponent();
        btnRegresar.Click += (_, _) => Close();
    }

    private readonly IReporteOcupacionService _service = null!;
    private readonly IPartidoService _partidos = null!;
    private readonly IZonaService _zonas = null!;
    private readonly CheckBox _solo = new() { Text = "Solo disponibles", AutoSize = true };
    public FrmReporteOcupacion(IReporteOcupacionService service, IPartidoService partidos, IZonaService zonas) : this()
    {
        _service = service; _partidos = partidos; _zonas = zonas;
        campo3.Visible = false; lblCampo3.Visible = false; _solo.Location = campo3.Location; Controls.Add(_solo); _solo.BringToFront();
        btnGuardar.Visible = false; btnConsultar.Enabled = true; btnConsultar.Text = "Aplicar filtros";
        btnConsultar.Click += (_, _) => Ejecutar(Lista);
        campo1.SelectionChangeCommitted += (_, _) => Ejecutar(CargarZonas);
        Load += (_, _) => Ejecutar(() => {
            var lista = _partidos.Consultar().Select(p => new { Id = p.IdPartido, Texto = p.NombrePartido + " | " + p.NombreEstadio + " | " + p.FechaHora.ToString("dd-MMM-yyyy HH:mm", MX) }).ToList();
            lista.Insert(0, new { Id = 0, Texto = "Todos" }); Combo(campo1, lista, "Texto", "Id"); campo1.DropDownWidth = 700;
            CargarZonas(); Lista();
        });
    }
    private void CargarZonas()
    {
        int? partido = Id(campo1);
        int? estadio = _partidos.Consultar().FirstOrDefault(p => p.IdPartido == partido)?.IdEstadio;
        var zonas = _zonas.Consultar(estadio); zonas.Insert(0, new Zona { Nombre = "Todas" });
        Combo(campo2, zonas, "Nombre", "IdZona");
    }
    private void Lista()
    {
        int? partido = Id(campo1);
        var datos = _service.Consultar(partido, Id(campo2), _solo.Checked);
        Tabla(datos,
            (nameof(ReporteOcupacion.Partido), "Partido", ""),
            (nameof(ReporteOcupacion.Zona), "Zona", ""),
            (nameof(ReporteOcupacion.PrecioBase), "Precio base", "C2"),
            (nameof(ReporteOcupacion.AsientosTotales), "Asientos totales", "N0"),
            (nameof(ReporteOcupacion.Vendidos), "Vendidos", "N0"),
            (nameof(ReporteOcupacion.Disponibles), "Disponibles", "N0"),
            (nameof(ReporteOcupacion.Porcentaje), "Ocupación (%)", "N2"));
        lblDescripcion.Text = "Vendidos en resultados: " + datos.Sum(r => r.Vendidos) + (partido.HasValue ? " | Vendidos del partido: " + _service.Consultar(partido, null, false).Sum(r => r.Vendidos) : "");
    }
    private void lblTitulo_Click(object sender, EventArgs e) { }

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
