using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmFacturas : Form
{
    public FrmFacturas()
    {
        InitializeComponent();
        btnRegresar.Click += (_, _) => Close();
    }

    private readonly IFacturaService _service = null!;
    public FrmFacturas(IFacturaService service) : this()
    {
        _service = service;
        campo1.Enabled = campo2.Enabled = campo4.Enabled = true;
        campo1.ReadOnly = campo4.ReadOnly = true;
        campo3.Enabled = false;
        btnConsultar.Enabled = btnGuardar.Enabled = true;
        btnConsultar.Text = "Buscar por folio";
        btnGuardar.Text = "Exportar PDF";
        btnConsultar.Click += (_, _) => Ejecutar(Lista);
        btnGuardar.Click += (_, _) => Ejecutar(Exportar);
        dgvDatos.SelectionChanged += (_, _) => {
            if (dgvDatos.SelectedRows.Count == 0 || dgvDatos.SelectedRows[0].DataBoundItem is not Factura f) return;
            campo1.Text = f.FolioFactura; campo4.Text = Dinero(f.Total);
            campo3.Items.Clear(); campo3.Items.Add(f.ReceptorNombre); campo3.SelectedIndex = 0;
        };
        Load += (_, _) => Ejecutar(Lista);
    }
    private void Lista()
    {
        Guid? folio = null;
        if (!string.IsNullOrWhiteSpace(campo2.Text))
        {
            if (!Guid.TryParse(campo2.Text.Trim(), out Guid f)) throw new ArgumentException("Ingrese un folio de compra válido.");
            folio = f;
        }
        Tabla(_service.Consultar(folio),
            (nameof(Factura.FolioFactura), "Folio factura", ""),
            (nameof(Factura.Folio), "Folio compra", ""),
            (nameof(Factura.ReceptorNombre), "Cliente", ""),
            (nameof(Factura.Total), "Total", "C2"),
            (nameof(Factura.Estado), "Estado", ""));
        campo1.Clear(); campo4.Clear(); campo3.Items.Clear();
    }
    private void Exportar()
    {
        if (dgvDatos.SelectedRows.Count != 1 || dgvDatos.SelectedRows[0].DataBoundItem is not Factura f)
            throw new ArgumentException("Seleccione una factura de la tabla.");
        var detalle = _service.Detalle(f.IdFactura);
        if (detalle.Count == 0) throw new ArgumentException("No hay detalle de la factura.");
        var r = detalle[0];
        List<string> lineas = new() {
            "FACTURA - COMPROBANTE ESCOLAR (NO CFDI)", "Folio factura: " + r.FolioFactura,
            "Folio compra: " + r.Folio, "Fecha: " + r.FechaEmision?.ToString("dd-MMM-yyyy HH:mm", MX),
            "Estado: " + r.Estado, "Emisor: " + r.EmisorNombre, "RFC: " + r.EmisorRfc,
            "Domicilio: " + r.EmisorDomicilio, "Receptor: " + r.ReceptorNombre, "RFC: " + r.ReceptorRfc,
            "Domicilio: " + r.ReceptorDomicilio, "Método de pago: " + r.MetodoPago, "DETALLE:" };
        foreach (var b in detalle)
        {
            lineas.Add(b.Partido + " | " + b.Estadio);
            lineas.Add("Zona: " + b.Zona + " | Fila: " + b.Fila + " | Asiento: " + b.Numero + " | Cantidad: 1 | Precio: " + Dinero(b.PrecioUnitario));
        }
        lineas.Add("Cantidad total: " + detalle.Count);
        lineas.Add("Subtotal: " + Dinero(r.Subtotal)); lineas.Add("IVA: " + Dinero(r.Iva)); lineas.Add("Total: " + Dinero(r.Total));
        using SaveFileDialog dialogo = new() { Filter = "PDF (*.pdf)|*.pdf", FileName = "Factura-" + r.FolioFactura + ".pdf" };
        if (dialogo.ShowDialog(this) == DialogResult.OK)
        {
            PdfEscolar.Guardar(dialogo.FileName, lineas);
            MessageBox.Show("PDF guardado correctamente.");
        }
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
    private static class PdfEscolar
    {
        // PDF de texto con fuente estándar, sin paquetes externos. Escapa caracteres Latin-1.
        private static string Esc(string s){System.Text.StringBuilder b=new();foreach(char ch in s){if(ch=='('||ch==')'||ch=='\\')b.Append('\\').Append(ch);else if(ch<32||ch>126)b.Append('\\').Append(Convert.ToString(ch<=255?ch:63,8).PadLeft(3,'0'));else b.Append(ch);}return b.ToString();}
        public static void Guardar(string ruta,IEnumerable<string> lineas)
        {
            List<string> texto=new();foreach(string linea in lineas){string s=linea.Replace("\r"," ").Replace("\n"," ");while(s.Length>88){int corte=s.LastIndexOf(' ',87);if(corte<=0)corte=88;texto.Add(s[..corte]);s=s[corte..].TrimStart();}texto.Add(s);}
            var paginas=texto.Chunk(45).ToArray();if(paginas.Length==0)paginas=new[]{new[]{""}};
            List<string> obj=new(){"<< /Type /Catalog /Pages 2 0 R >>","", "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>"};
            List<string> kids=new();foreach(var pagina in paginas){int id=obj.Count+1;kids.Add(id+" 0 R");obj.Add($"<< /Type /Page /Parent 2 0 R /MediaBox [0 0 612 792] /Resources << /Font << /F1 3 0 R >> >> /Contents {id+1} 0 R >>");System.Text.StringBuilder stream=new("BT /F1 10 Tf 15 TL 45 745 Td\n");foreach(string l in pagina)stream.Append('(').Append(Esc(l)).Append(") Tj T*\n");stream.Append("ET\n");string body=stream.ToString();obj.Add($"<< /Length {System.Text.Encoding.ASCII.GetByteCount(body)} >>\nstream\n{body}endstream");}
            obj[1]="<< /Type /Pages /Count "+kids.Count+" /Kids ["+string.Join(" ",kids)+"] >>";
            using FileStream f=File.Create(ruta);void W(string s){byte[] b=System.Text.Encoding.ASCII.GetBytes(s);f.Write(b,0,b.Length);}W("%PDF-1.4\n");List<long> offsets=new();for(int i=0;i<obj.Count;i++){offsets.Add(f.Position);W($"{i+1} 0 obj\n{obj[i]}\nendobj\n");}long xref=f.Position;W($"xref\n0 {obj.Count+1}\n0000000000 65535 f \n");foreach(long n in offsets)W(n.ToString("D10",System.Globalization.CultureInfo.InvariantCulture)+" 00000 n \n");W($"trailer\n<< /Size {obj.Count+1} /Root 1 0 R >>\nstartxref\n{xref}\n%%EOF\n");
        }
    }
}
