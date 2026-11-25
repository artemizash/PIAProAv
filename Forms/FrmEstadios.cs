using Microsoft.Data.SqlClient;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmEstadios : Form
{
    private readonly IEstadioService _service = null!;

    // Usuario que está utilizando el sistema.
    private int _idUsuarioRegistro;

    // Imagen del mapa convertida a bytes.
    private byte[]? _mapa;

    public FrmEstadios()
    {
        InitializeComponent();

        btnRegresar.Click += (_, _) => Close();
    }

    // Constructor para recibir el servicio.
    public FrmEstadios(IEstadioService service) : this()
    {
        _service = service;

        // Habilitar los controles del formulario.
        campo1.Enabled = true;
        campo2.Enabled = true;
        campo3.Enabled = true;

        btnGuardar.Enabled = true;
        
        dgvDatos.Enabled = true;

        // Limitar la longitud de los campos.
        campo1.MaxLength = 100;
        campo3.MaxLength = 100;
        campo2.MaxLength = 10;

        // Permitir seleccionar una imagen.
        pictureBox1.Cursor = Cursors.Hand;
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        lblCampo4.Text = "Mapa (clic para cargar):";

        // Configurar la tabla.
        dgvDatos.AutoGenerateColumns = false;

        // Eventos de los controles.
        pictureBox1.Click += (_, _) => Ejecutar(SeleccionarMapa);

        btnGuardar.Click += (_, _) => Ejecutar(Guardar);

        dgvDatos.CellDoubleClick += MostrarMapaRegistrado;

        // Consultar estadios al abrir la ventana.
        Load += (_, _) => Ejecutar(CargarLista);

        FormClosed += (_, _) =>
        {
            pictureBox1.Image?.Dispose();
        };
    }

    // Recibe el ID del usuario autenticado.
    public void EstablecerUsuario(int idUsuario)
    {
        _idUsuarioRegistro = idUsuario;
    }

    // Seleccionar la imagen del estadio.
    private void SeleccionarMapa()
    {
        using OpenFileDialog archivo = new OpenFileDialog();

        archivo.Title = "Seleccionar mapa del estadio";

        archivo.Filter =
            "Imágenes (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

        if (archivo.ShowDialog() == DialogResult.OK)
        {
            byte[] datos = File.ReadAllBytes(archivo.FileName);

            // Comprobar que el archivo sea una imagen válida.
            using MemoryStream memoria = new MemoryStream(datos);
            using Image imagen = Image.FromStream(memoria);

            Image copia = new Bitmap(imagen);

            // Guardar la imagen en memoria.
            _mapa = datos;

            pictureBox1.Image?.Dispose();
            pictureBox1.Image = copia;
        }
    }

    // Registrar un estadio.
    private void Guardar()
    {
        if (!int.TryParse(campo2.Text, out int capacidad)
            || capacidad <= 0)
        {
            throw new ArgumentException(
                "Ingrese una capacidad válida.");
        }

        Estadio estadio = new Estadio();

        estadio.IdUsuarioRegistro = _idUsuarioRegistro;
        estadio.Nombre = campo1.Text;
        estadio.Ciudad = campo3.Text;
        estadio.CapacidadTotal = capacidad;
        estadio.Mapa = _mapa;

        DialogResult respuesta = MessageBox.Show(
            "¿Desea registrar este estadio?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
        {
            return;
        }

        // Enviar la información al servicio.
        _service.Registrar(estadio);

        MessageBox.Show(
            "Estadio registrado correctamente.",
            "Correcto",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        Limpiar();

        CargarLista();
    }

    // Consultar los estadios registrados.
    private void CargarLista()
    {
        List<Estadio> estadios = _service.Consultar();

        dgvDatos.Rows.Clear();

        foreach (Estadio estadio in estadios)
        {
            int fila = dgvDatos.Rows.Add(
                estadio.Nombre,
                estadio.Ciudad,
                estadio.CapacidadTotal,
                estadio.Mapa != null
                    ? "Doble clic para ver"
                    : "Sin mapa"
            );

            // Guardar el objeto asociado a la fila.
            dgvDatos.Rows[fila].Tag = estadio;
        }

        dgvDatos.ClearSelection();
    }

    // Mostrar el mapa de un estadio registrado.
    private void MostrarMapaRegistrado(
        object? sender,
        DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }

        if (dgvDatos.Rows[e.RowIndex].Tag is not Estadio estadio)
        {
            return;
        }

        if (estadio.Mapa == null || estadio.Mapa.Length == 0)
        {
            MessageBox.Show("Este estadio no tiene mapa.");
            return;
        }

        Ejecutar(() =>
        {
            using MemoryStream memoria =
                new MemoryStream(estadio.Mapa);

            using Image imagen = Image.FromStream(memoria);

            using Form ventana = new Form();

            ventana.Text = "Mapa - " + estadio.Nombre;
            ventana.Size = new Size(800, 600);
            ventana.StartPosition = FormStartPosition.CenterParent;

            using PictureBox visor = new PictureBox();

            visor.Dock = DockStyle.Fill;
            visor.SizeMode = PictureBoxSizeMode.Zoom;
            visor.Image = imagen;

            ventana.Controls.Add(visor);

            ventana.ShowDialog(this);

            visor.Image = null;
        });
    }

    // Limpiar los campos después de registrar.
    private void Limpiar()
    {
        campo1.Clear();
        campo2.Clear();
        campo3.Clear();

        _mapa = null;

        pictureBox1.Image?.Dispose();
        pictureBox1.Image = null;

        campo1.Focus();
    }

    // Controlar los errores durante las operaciones.
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
                "El estadio ya se encuentra registrado.",
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

    // Eventos originales utilizados por el Designer.

    private void lblCampo2_Click(object sender, EventArgs e)
    {
    }

    private void dgvDatos_CellContentClick(
        object sender, DataGridViewCellEventArgs e)
    {
    }

    private void lblCampo3_Click(object sender, EventArgs e)
    {
    }
}