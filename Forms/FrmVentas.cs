using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using TemplateCSharp.Interfaces.Services;
using TemplateCSharp.Models;

namespace TemplateCSharp.Forms;

public partial class FrmVentas : Form
{
    private readonly IVentaService _ventaService = null!;
    private readonly IClienteService _clienteService = null!;
    private readonly IPartidoService _partidoService = null!;
    private readonly SesionActual _sesion = null!;
    private readonly IServiceProvider _provider = null!;

    private bool _cargando;

    private static readonly CultureInfo Cultura =
        CultureInfo.GetCultureInfo("es-MX");

    // Constructor para el Designer.
    public FrmVentas()
    {
        InitializeComponent();

        btnRegresar.Click += (_, _) => Close();
    }

    // Constructor para recibir los servicios.
    public FrmVentas(
        IVentaService ventaService,
        IClienteService clienteService,
        IPartidoService partidoService,
        SesionActual sesion,
        IServiceProvider provider) : this()
    {
        _ventaService = ventaService;
        _clienteService = clienteService;
        _partidoService = partidoService;
        _sesion = sesion;
        _provider = provider;

        // Habilitar controles.
        campo1.Enabled = true;
        campo2.Enabled = true;
        campo3.Enabled = true;
        campo4.Enabled = true;
        campo5.Enabled = true;
        campo6.Enabled = true;

        btnGuardar.Enabled = true;
        btnConsultar.Enabled = true;
        dgvDatos.Enabled = true;

        // Cambiar textos.
        btnGuardar.Text = "Comprar";
        btnConsultar.Text = "Buscar boletos";

        lblCampo4.Text = "Asientos:";
        lblDescripcion.Text =
            "Selecciona de uno a cuatro boletos usando Ctrl.";

        // Los asientos y el total no se escriben manualmente.
        campo4.ReadOnly = true;
        campo6.ReadOnly = true;

        // Configurar ComboBox.
        campo1.DropDownStyle = ComboBoxStyle.DropDownList;
        campo2.DropDownStyle = ComboBoxStyle.DropDownList;
        campo3.DropDownStyle = ComboBoxStyle.DropDownList;
        campo5.DropDownStyle = ComboBoxStyle.DropDownList;

        campo5.Items.Clear();
        campo5.Items.Add("Efectivo");
        campo5.Items.Add("Crédito");
        campo5.Items.Add("Débito");
        campo5.SelectedIndex = 0;

        // Configurar DataGridView.
        dgvDatos.AutoGenerateColumns = false;
        dgvDatos.AllowUserToAddRows = false;
        dgvDatos.AllowUserToDeleteRows = false;
        dgvDatos.ReadOnly = true;
        dgvDatos.MultiSelect = true;

        dgvDatos.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        colCampo1.HeaderText = "Zona";
        colCampo2.HeaderText = "Fila";
        colCampo3.HeaderText = "Asiento";
        colCampo4.HeaderText = "Precio unitario";
        colCampo5.HeaderText = "IVA";
        colCampo6.HeaderText = "Total";

        // Agregar botones de búsqueda.
        AgregarBotonesBusqueda();

        // Eventos.
        campo2.SelectionChangeCommitted += (_, _) =>
            Ejecutar(CargarZonas);

        campo3.SelectionChangeCommitted += (_, _) =>
            Ejecutar(CargarBoletos);

        btnConsultar.Click += (_, _) =>
            Ejecutar(CargarZonas);

        btnGuardar.Click += (_, _) =>
            Ejecutar(Comprar);

        dgvDatos.SelectionChanged += (_, _) =>
        {
            if (!_cargando)
                ActualizarTotal();
        };

        Load += (_, _) => Ejecutar(() =>
        {
            CargarClientes();
            CargarPartidos();
            ActualizarTotal();
        });
    }

    // Agregar botones sin modificar el Designer.
    private void AgregarBotonesBusqueda()
    {
        FlowLayoutPanel panel = new FlowLayoutPanel
        {
            Location = new Point(
                lblDescripcion.Left,
                lblDescripcion.Bottom + 8),

            Size = new Size(1100, 55),
            WrapContents = false
        };

        Button buscarCliente = new Button
        {
            Text = "Buscar cliente",
            Width = 220,
            Height = 42,
            BackColor = Color.Plum
        };

        Button buscarPartido = new Button
        {
            Text = "Buscar partido",
            Width = 220,
            Height = 42,
            BackColor = Color.Plum
        };

        Button nuevoCliente = new Button
        {
            Text = "Nuevo cliente",
            Width = 220,
            Height = 42,
            BackColor = Color.Plum
        };

        buscarCliente.Click += (_, _) =>
            Ejecutar(BuscarCliente);

        buscarPartido.Click += (_, _) =>
            Ejecutar(BuscarPartido);

        nuevoCliente.Click += (_, _) =>
            Ejecutar(NuevoCliente);

        panel.Controls.Add(buscarCliente);
        panel.Controls.Add(buscarPartido);
        panel.Controls.Add(nuevoCliente);

        Controls.Add(panel);

        panel.BringToFront();
    }

    // Consultar clientes.
    private void CargarClientes(string filtro = "")
    {
        List<Cliente> clientes =
            _clienteService.Consultar(filtro);

        campo1.DataSource = null;

        campo1.DisplayMember = "Texto";
        campo1.ValueMember = "Id";

        campo1.DataSource = clientes.Select(c => new
        {
            Id = c.IdCliente,

            Texto = c.NombreCompleto +
                " - " + c.Correo
        }).ToList();

        campo1.SelectedIndex = -1;
    }

    // Buscar cliente por apellido o correo.
    private void BuscarCliente()
    {
        string filtro =
            Microsoft.VisualBasic.Interaction.InputBox(
                "Escribe el apellido o correo del cliente.",
                "Buscar cliente",
                "");

        CargarClientes(filtro.Trim());

        if (campo1.Items.Count == 0)
        {
            MessageBox.Show(
                "No se encontraron clientes.");

            return;
        }

        campo1.DroppedDown = true;
    }

    // Registrar cliente utilizando el formulario existente.
    private void NuevoCliente()
    {
        using FrmClientes form =
            _provider.GetRequiredService<FrmClientes>();

        form.ShowDialog(this);

        CargarClientes();
    }

    // Consultar partidos disponibles.
    private void CargarPartidos(string? filtro = null)
    {
        List<Partido> partidos =
            _partidoService.Consultar(true, filtro);

        campo2.DataSource = null;

        campo2.DisplayMember = "Texto";
        campo2.ValueMember = "Id";

        campo2.DataSource = partidos.Select(p => new
        {
            Id = p.IdPartido,

            Texto = p.NombrePartido +
                " | " + p.NombreEstadio +
                " | " + p.FechaHora.ToString(
                    "dd-MMM-yyyy HH:mm", Cultura)

        }).ToList();

        campo2.SelectedIndex = -1;
        campo2.DropDownWidth = 700;

        campo3.DataSource = null;

        LimpiarTabla();
    }

    // Buscar por estadio, equipo o fecha.
    private void BuscarPartido()
    {
        string filtro =
            Microsoft.VisualBasic.Interaction.InputBox(
                "Escribe un equipo, estadio o fecha AAAA-MM-DD.",
                "Buscar partido",
                "");

        CargarPartidos(filtro.Trim());

        if (campo2.Items.Count == 0)
        {
            MessageBox.Show(
                "No se encontraron partidos disponibles.");

            return;
        }

        campo2.DroppedDown = true;
    }

    // Consultar las zonas que tienen boletos disponibles.
    private void CargarZonas()
    {
        campo3.DataSource = null;

        LimpiarTabla();

        if (campo2.SelectedValue is not int idPartido)
        {
            return;
        }

        List<Boleto> boletos =
            _ventaService.ConsultarDisponibles(idPartido);

        List<Zona> zonas = boletos
            .GroupBy(b => b.IdZona)
            .Select(g => new Zona
            {
                IdZona = g.Key,
                Nombre = g.First().NombreZona
            })
            .ToList();

        // Permitir consultar todas las zonas.
        zonas.Insert(0, new Zona
        {
            IdZona = 0,
            Nombre = "Todas"
        });

        campo3.DisplayMember = "Nombre";
        campo3.ValueMember = "IdZona";
        campo3.DataSource = zonas;

        campo3.SelectedIndex = 0;

        MostrarBoletos(boletos);
    }

    // Consultar los boletos de una zona.
    private void CargarBoletos()
    {
        if (campo2.SelectedValue is not int idPartido)
        {
            LimpiarTabla();

            return;
        }

        int? idZona = null;

        if (campo3.SelectedValue is int zona && zona > 0)
        {
            idZona = zona;
        }

        List<Boleto> boletos =
            _ventaService.ConsultarDisponibles(
                idPartido,
                idZona);

        MostrarBoletos(boletos);
    }

    // Mostrar los boletos en la tabla.
    private void MostrarBoletos(List<Boleto> boletos)
    {
        _cargando = true;

        try
        {
            dgvDatos.Rows.Clear();

            foreach (Boleto boleto in boletos)
            {
                decimal iva = Math.Round(
                    boleto.PrecioUnitario * 0.16m,
                    2,
                    MidpointRounding.AwayFromZero);

                decimal total =
                    boleto.PrecioUnitario + iva;

                int fila = dgvDatos.Rows.Add(
                    boleto.NombreZona,
                    boleto.Fila,
                    boleto.NumeroAsiento,
                    boleto.PrecioUnitario.ToString(
                        "C2", Cultura),
                    iva.ToString("C2", Cultura),
                    total.ToString("C2", Cultura)
                );

                // Guardar el objeto completo en la fila.
                dgvDatos.Rows[fila].Tag = boleto;
            }

            dgvDatos.ClearSelection();
        }
        finally
        {
            _cargando = false;
        }

        ActualizarTotal();
    }

    // Obtener los boletos seleccionados.
    private List<Boleto> ObtenerSeleccionados()
    {
        return dgvDatos.SelectedRows
            .Cast<DataGridViewRow>()
            .Select(fila => fila.Tag)
            .OfType<Boleto>()
            .OrderBy(b => b.NombreZona)
            .ThenBy(b => b.Fila)
            .ThenBy(b => b.NumeroAsiento)
            .ToList();
    }

    // Calcular el subtotal, IVA y total.
    private void ActualizarTotal()
    {
        List<Boleto> seleccionados =
            ObtenerSeleccionados();

        decimal subtotal =
            seleccionados.Sum(b => b.PrecioUnitario);

        decimal iva = Math.Round(
            subtotal * 0.16m,
            2,
            MidpointRounding.AwayFromZero);

        decimal total = subtotal + iva;

        campo4.Text = string.Join(
            ", ",
            seleccionados.Select(
                b => b.NombreAsiento));

        campo6.Text = total.ToString("C2", Cultura);

        if (seleccionados.Count > 4)
        {
            lblDescripcion.Text =
                "No puedes comprar más de cuatro boletos.";

            lblDescripcion.ForeColor = Color.Red;
        }
        else
        {
            lblDescripcion.Text =
                "Boletos: " + seleccionados.Count + "/4" +
                " | Subtotal: " +
                subtotal.ToString("C2", Cultura) +
                " | IVA: " +
                iva.ToString("C2", Cultura);

            lblDescripcion.ForeColor = Color.Black;
        }
    }

    // Realizar la compra.
    private void Comprar()
    {
        if (campo1.SelectedValue is not int idCliente)
        {
            throw new ArgumentException(
                "Seleccione un cliente.");
        }

        if (campo2.SelectedValue is not int idPartido)
        {
            throw new ArgumentException(
                "Seleccione un partido.");
        }

        List<Boleto> seleccionados =
            ObtenerSeleccionados();

        if (seleccionados.Count < 1 ||
            seleccionados.Count > 4)
        {
            throw new ArgumentException(
                "Seleccione de uno a cuatro boletos.");
        }

        if (seleccionados.Any(
            b => b.IdPartido != idPartido))
        {
            throw new ArgumentException(
                "Todos los boletos deben ser del mismo partido.");
        }

        string metodoPago = campo5.SelectedIndex switch
        {
            0 => "efectivo",
            1 => "credito",
            2 => "debito",
            _ => ""
        };

        if (metodoPago == "")
        {
            throw new ArgumentException(
                "Seleccione un método de pago.");
        }

        decimal subtotal =
            seleccionados.Sum(b => b.PrecioUnitario);

        decimal iva = Math.Round(
            subtotal * 0.16m,
            2,
            MidpointRounding.AwayFromZero);

        decimal total = subtotal + iva;

        // Confirmar la compra.
        DialogResult respuesta = MessageBox.Show(
            "¿Desea realizar la compra?\n\n" +
            "Cantidad: " + seleccionados.Count +
            "\nSubtotal: " +
            subtotal.ToString("C2", Cultura) +
            "\nIVA: " +
            iva.ToString("C2", Cultura) +
            "\nTotal: " +
            total.ToString("C2", Cultura),
            "Confirmar compra",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (respuesta != DialogResult.Yes)
        {
            return;
        }

        // Validar tarjeta cuando corresponda.
        if (metodoPago == "credito" ||
            metodoPago == "debito")
        {
            if (!MostrarPagoSimulado())
            {
                return;
            }
        }

        Venta venta = new Venta
        {
            IdCliente = idCliente,

            IdUsuario = _sesion.IdUsuario,

            MetodoPago = metodoPago
        };

        List<int> ids = seleccionados
            .Select(b => b.IdBoleto)
            .ToList();

        // Registrar la compra.
        Venta resultado =
            _ventaService.Registrar(venta, ids);

        MessageBox.Show(
            "Compra realizada correctamente.\n\n" +
            "Folio: " + resultado.Folio +
            "\nBoletos: " + seleccionados.Count +
            "\nSubtotal: " +
            resultado.Subtotal.ToString("C2", Cultura) +
            "\nIVA: " +
            resultado.Iva.ToString("C2", Cultura) +
            "\nTotal: " +
            resultado.Total.ToString("C2", Cultura),
            "Venta exitosa",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        // Recargar para retirar boletos vendidos.
        CargarZonas();
    }

    // Simular pago con tarjeta.
    private bool MostrarPagoSimulado()
    {
        using Form ventana = new Form
        {
            Text = "Pago simulado",
            StartPosition = FormStartPosition.CenterParent,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            ClientSize = new Size(450, 430),
            MaximizeBox = false,
            MinimizeBox = false,
            BackColor = Color.LavenderBlush
        };

        FlowLayoutPanel panel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(20),
            AutoScroll = true
        };

        Label aviso = new Label
        {
            Text = "Simulación: utiliza datos ficticios.",
            AutoSize = true
        };

        TextBox titular = new TextBox
        {
            Width = 380,
            MaxLength = 100
        };

        TextBox tarjeta = new TextBox
        {
            Width = 380,
            MaxLength = 19
        };

        DateTimePicker vencimiento = new DateTimePicker
        {
            Width = 380,
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "MM/yyyy",
            ShowUpDown = true,
            Value = DateTime.Today.AddYears(1)
        };

        TextBox ccv = new TextBox
        {
            Width = 380,
            MaxLength = 4,
            UseSystemPasswordChar = true
        };

        Button aceptar = new Button
        {
            Text = "Validar pago",
            Width = 180,
            Height = 38
        };

        Button cancelar = new Button
        {
            Text = "Cancelar",
            Width = 180,
            Height = 38,
            DialogResult = DialogResult.Cancel
        };

        panel.Controls.Add(aviso);

        panel.Controls.Add(new Label
        {
            Text = "Nombre del titular:",
            AutoSize = true
        });

        panel.Controls.Add(titular);

        panel.Controls.Add(new Label
        {
            Text = "Número de tarjeta:",
            AutoSize = true
        });

        panel.Controls.Add(tarjeta);

        panel.Controls.Add(new Label
        {
            Text = "Vencimiento:",
            AutoSize = true
        });

        panel.Controls.Add(vencimiento);

        panel.Controls.Add(new Label
        {
            Text = "CCV:",
            AutoSize = true
        });

        panel.Controls.Add(ccv);

        panel.Controls.Add(aceptar);
        panel.Controls.Add(cancelar);

        ventana.Controls.Add(panel);

        ventana.CancelButton = cancelar;
        ventana.AcceptButton = aceptar;

        aceptar.Click += (_, _) =>
        {
            string numero =
                tarjeta.Text.Replace(" ", "")
                            .Replace("-", "");

            if (string.IsNullOrWhiteSpace(titular.Text))
            {
                MessageBox.Show(
                    "Ingrese el nombre del titular.");

                return;
            }

            if (!Regex.IsMatch(numero, @"^[0-9]{16}$"))
            {
                MessageBox.Show(
                    "La tarjeta debe tener 16 dígitos.");

                return;
            }

            DateTime ultimoDia = new DateTime(
                vencimiento.Value.Year,
                vencimiento.Value.Month,
                DateTime.DaysInMonth(
                    vencimiento.Value.Year,
                    vencimiento.Value.Month));

            if (ultimoDia < DateTime.Today)
            {
                MessageBox.Show(
                    "La tarjeta está vencida.");

                return;
            }

            if (!Regex.IsMatch(ccv.Text, @"^[0-9]{3,4}$"))
            {
                MessageBox.Show(
                    "El CCV debe contener 3 o 4 dígitos.");

                return;
            }

            ventana.DialogResult = DialogResult.OK;
            ventana.Close();
        };

        return ventana.ShowDialog(this) ==
            DialogResult.OK;
    }

    // Limpiar tabla y totales.
    private void LimpiarTabla()
    {
        _cargando = true;

        try
        {
            dgvDatos.Rows.Clear();
        }
        finally
        {
            _cargando = false;
        }

        ActualizarTotal();
    }

    // Controlar errores.
    private static void Ejecutar(Action operacion)
    {
        try
        {
            operacion();
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
}