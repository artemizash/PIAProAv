using System.Drawing;
using System.Windows.Forms;

namespace TemplateCSharp.Forms;

// Editar controles con: clic derecho en FrmPrincipal.cs > Ver diseñador.
partial class FrmPrincipal
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Button btnUsuarios = null!;
    private Button btnClientes = null!;
    private Button btnCambiarUsuario = null!;
    private Button btnMiCuenta = null!;
    private Button btnEstadios = null!;
    private Button btnZonas = null!;
    private Button btnAsientos = null!;
    private Button btnEquipos = null!;
    private Button btnPartidos = null!;
    private Button btnVentas = null!;
    private Button btnCancelaciones = null!;
    private Button btnFacturas = null!;
    private Button btnReporteVentas = null!;
    private Button btnReporteOcupacion = null!;
    private Button btnHistorial = null!;
    private MenuStrip menuPrincipal = null!;
    private ToolStripMenuItem menuModulos = null!;
    private ToolStripMenuItem menuUsuarios = null!;
    private ToolStripMenuItem menuClientes = null!;
    private ToolStripMenuItem menuCambiarUsuario = null!;
    private ToolStripMenuItem menuMiCuenta = null!;
    private ToolStripMenuItem menuSalir = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        btnUsuarios = new Button();
        btnClientes = new Button();
        btnCambiarUsuario = new Button();
        btnMiCuenta = new Button();
        btnEstadios = new Button();
        btnZonas = new Button();
        btnAsientos = new Button();
        btnEquipos = new Button();
        btnPartidos = new Button();
        btnVentas = new Button();
        btnCancelaciones = new Button();
        btnFacturas = new Button();
        btnReporteVentas = new Button();
        btnReporteOcupacion = new Button();
        btnHistorial = new Button();
        menuPrincipal = new MenuStrip();
        menuModulos = new ToolStripMenuItem();
        menuUsuarios = new ToolStripMenuItem();
        menuClientes = new ToolStripMenuItem();
        menuMiCuenta = new ToolStripMenuItem();
        menuCambiarUsuario = new ToolStripMenuItem();
        menuSalir = new ToolStripMenuItem();
        menuPrincipal.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.DimGray;
        lblTitulo.Location = new Point(27, 25);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(805, 36);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "GESTIÓN DE BOLETOS PARA PARTIDOS";
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // btnUsuarios
        // 
        btnUsuarios.BackColor = Color.MediumVioletRed;
        btnUsuarios.FlatStyle = FlatStyle.Flat;
        btnUsuarios.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnUsuarios.ForeColor = Color.White;
        btnUsuarios.Location = new Point(27, 113);
        btnUsuarios.Margin = new Padding(3, 2, 3, 2);
        btnUsuarios.Name = "btnUsuarios";
        btnUsuarios.Size = new Size(188, 39);
        btnUsuarios.TabIndex = 0;
        btnUsuarios.Text = "Usuarios";
        btnUsuarios.UseVisualStyleBackColor = false;
        // 
        // btnClientes
        // 
        btnClientes.BackColor = Color.MediumVioletRed;
        btnClientes.FlatStyle = FlatStyle.Flat;
        btnClientes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnClientes.ForeColor = Color.White;
        btnClientes.Location = new Point(231, 113);
        btnClientes.Margin = new Padding(3, 2, 3, 2);
        btnClientes.Name = "btnClientes";
        btnClientes.Size = new Size(188, 39);
        btnClientes.TabIndex = 0;
        btnClientes.Text = "Clientes";
        btnClientes.UseVisualStyleBackColor = false;
        // 
        // btnCambiarUsuario
        // 
        btnCambiarUsuario.BackColor = Color.MediumVioletRed;
        btnCambiarUsuario.FlatStyle = FlatStyle.Flat;
        btnCambiarUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnCambiarUsuario.ForeColor = Color.White;
        btnCambiarUsuario.Location = new Point(435, 113);
        btnCambiarUsuario.Margin = new Padding(3, 2, 3, 2);
        btnCambiarUsuario.Name = "btnCambiarUsuario";
        btnCambiarUsuario.Size = new Size(188, 39);
        btnCambiarUsuario.TabIndex = 0;
        btnCambiarUsuario.Text = "Cambiar usuario";
        btnCambiarUsuario.UseVisualStyleBackColor = false;
        // 
        // btnMiCuenta
        // 
        btnMiCuenta.BackColor = Color.MediumVioletRed;
        btnMiCuenta.FlatStyle = FlatStyle.Flat;
        btnMiCuenta.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnMiCuenta.ForeColor = Color.White;
        btnMiCuenta.Location = new Point(640, 113);
        btnMiCuenta.Margin = new Padding(3, 2, 3, 2);
        btnMiCuenta.Name = "btnMiCuenta";
        btnMiCuenta.Size = new Size(188, 39);
        btnMiCuenta.TabIndex = 0;
        btnMiCuenta.Text = "Mi cuenta";
        btnMiCuenta.UseVisualStyleBackColor = false;
        // 
        // btnEstadios
        // 
        btnEstadios.BackColor = Color.HotPink;
        btnEstadios.FlatStyle = FlatStyle.Flat;
        btnEstadios.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEstadios.ForeColor = Color.Transparent;
        btnEstadios.Location = new Point(27, 169);
        btnEstadios.Margin = new Padding(3, 2, 3, 2);
        btnEstadios.Name = "btnEstadios";
        btnEstadios.Size = new Size(188, 39);
        btnEstadios.TabIndex = 0;
        btnEstadios.Text = "Estadios";
        btnEstadios.UseVisualStyleBackColor = false;
        // 
        // btnZonas
        // 
        btnZonas.BackColor = Color.HotPink;
        btnZonas.FlatStyle = FlatStyle.Flat;
        btnZonas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnZonas.ForeColor = Color.Transparent;
        btnZonas.Location = new Point(231, 169);
        btnZonas.Margin = new Padding(3, 2, 3, 2);
        btnZonas.Name = "btnZonas";
        btnZonas.Size = new Size(188, 39);
        btnZonas.TabIndex = 0;
        btnZonas.Text = "Zonas";
        btnZonas.UseVisualStyleBackColor = false;
        // 
        // btnAsientos
        // 
        btnAsientos.BackColor = Color.HotPink;
        btnAsientos.FlatStyle = FlatStyle.Flat;
        btnAsientos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnAsientos.ForeColor = Color.Transparent;
        btnAsientos.Location = new Point(435, 169);
        btnAsientos.Margin = new Padding(3, 2, 3, 2);
        btnAsientos.Name = "btnAsientos";
        btnAsientos.Size = new Size(188, 39);
        btnAsientos.TabIndex = 0;
        btnAsientos.Text = "Asientos";
        btnAsientos.UseVisualStyleBackColor = false;
        // 
        // btnEquipos
        // 
        btnEquipos.BackColor = Color.HotPink;
        btnEquipos.FlatStyle = FlatStyle.Flat;
        btnEquipos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEquipos.ForeColor = Color.Transparent;
        btnEquipos.Location = new Point(640, 169);
        btnEquipos.Margin = new Padding(3, 2, 3, 2);
        btnEquipos.Name = "btnEquipos";
        btnEquipos.Size = new Size(188, 39);
        btnEquipos.TabIndex = 0;
        btnEquipos.Text = "Equipos";
        btnEquipos.UseVisualStyleBackColor = false;
        // 
        // btnPartidos
        // 
        btnPartidos.BackColor = Color.HotPink;
        btnPartidos.FlatStyle = FlatStyle.Flat;
        btnPartidos.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnPartidos.ForeColor = Color.Transparent;
        btnPartidos.Location = new Point(27, 225);
        btnPartidos.Margin = new Padding(3, 2, 3, 2);
        btnPartidos.Name = "btnPartidos";
        btnPartidos.Size = new Size(188, 39);
        btnPartidos.TabIndex = 0;
        btnPartidos.Text = "Partidos";
        btnPartidos.UseVisualStyleBackColor = false;
        // 
        // btnVentas
        // 
        btnVentas.BackColor = Color.HotPink;
        btnVentas.FlatStyle = FlatStyle.Flat;
        btnVentas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnVentas.ForeColor = Color.Transparent;
        btnVentas.Location = new Point(231, 225);
        btnVentas.Margin = new Padding(3, 2, 3, 2);
        btnVentas.Name = "btnVentas";
        btnVentas.Size = new Size(188, 39);
        btnVentas.TabIndex = 0;
        btnVentas.Text = "Venta de boletos";
        btnVentas.UseVisualStyleBackColor = false;
        // 
        // btnCancelaciones
        // 
        btnCancelaciones.BackColor = Color.HotPink;
        btnCancelaciones.FlatStyle = FlatStyle.Flat;
        btnCancelaciones.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnCancelaciones.ForeColor = Color.Transparent;
        btnCancelaciones.Location = new Point(435, 225);
        btnCancelaciones.Margin = new Padding(3, 2, 3, 2);
        btnCancelaciones.Name = "btnCancelaciones";
        btnCancelaciones.Size = new Size(188, 39);
        btnCancelaciones.TabIndex = 0;
        btnCancelaciones.Text = "Cancelaciones";
        btnCancelaciones.UseVisualStyleBackColor = false;
        // 
        // btnFacturas
        // 
        btnFacturas.BackColor = Color.HotPink;
        btnFacturas.FlatStyle = FlatStyle.Flat;
        btnFacturas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnFacturas.ForeColor = Color.Transparent;
        btnFacturas.Location = new Point(640, 225);
        btnFacturas.Margin = new Padding(3, 2, 3, 2);
        btnFacturas.Name = "btnFacturas";
        btnFacturas.Size = new Size(188, 39);
        btnFacturas.TabIndex = 0;
        btnFacturas.Text = "Facturas";
        btnFacturas.UseVisualStyleBackColor = false;
        // 
        // btnReporteVentas
        // 
        btnReporteVentas.BackColor = Color.HotPink;
        btnReporteVentas.FlatStyle = FlatStyle.Flat;
        btnReporteVentas.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnReporteVentas.ForeColor = Color.Transparent;
        btnReporteVentas.Location = new Point(27, 281);
        btnReporteVentas.Margin = new Padding(3, 2, 3, 2);
        btnReporteVentas.Name = "btnReporteVentas";
        btnReporteVentas.Size = new Size(188, 39);
        btnReporteVentas.TabIndex = 0;
        btnReporteVentas.Text = "Reporte de ventas";
        btnReporteVentas.UseVisualStyleBackColor = false;
        // 
        // btnReporteOcupacion
        // 
        btnReporteOcupacion.BackColor = Color.HotPink;
        btnReporteOcupacion.FlatStyle = FlatStyle.Flat;
        btnReporteOcupacion.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnReporteOcupacion.ForeColor = Color.Transparent;
        btnReporteOcupacion.Location = new Point(231, 281);
        btnReporteOcupacion.Margin = new Padding(3, 2, 3, 2);
        btnReporteOcupacion.Name = "btnReporteOcupacion";
        btnReporteOcupacion.Size = new Size(188, 39);
        btnReporteOcupacion.TabIndex = 0;
        btnReporteOcupacion.Text = "Disponibilidad";
        btnReporteOcupacion.UseVisualStyleBackColor = false;
        // 
        // btnHistorial
        // 
        btnHistorial.BackColor = Color.HotPink;
        btnHistorial.FlatStyle = FlatStyle.Flat;
        btnHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnHistorial.ForeColor = Color.Transparent;
        btnHistorial.Location = new Point(435, 281);
        btnHistorial.Margin = new Padding(3, 2, 3, 2);
        btnHistorial.Name = "btnHistorial";
        btnHistorial.Size = new Size(188, 39);
        btnHistorial.TabIndex = 0;
        btnHistorial.Text = "Historial de clientes";
        btnHistorial.UseVisualStyleBackColor = false;
        // 
        // menuPrincipal
        // 
        menuPrincipal.ImageScalingSize = new Size(24, 24);
        menuPrincipal.Items.AddRange(new ToolStripItem[] { menuModulos, menuSalir });
        menuPrincipal.Location = new Point(0, 0);
        menuPrincipal.Name = "menuPrincipal";
        menuPrincipal.Padding = new Padding(6, 1, 0, 1);
        menuPrincipal.Size = new Size(858, 24);
        menuPrincipal.TabIndex = 1;
        // 
        // menuModulos
        // 
        menuModulos.DropDownItems.AddRange(new ToolStripItem[] { menuUsuarios, menuClientes, menuMiCuenta, menuCambiarUsuario });
        menuModulos.Name = "menuModulos";
        menuModulos.Size = new Size(66, 22);
        menuModulos.Text = "Módulos";
        // 
        // menuUsuarios
        // 
        menuUsuarios.Name = "menuUsuarios";
        menuUsuarios.Size = new Size(161, 22);
        menuUsuarios.Text = "Usuarios";
        // 
        // menuClientes
        // 
        menuClientes.Name = "menuClientes";
        menuClientes.Size = new Size(161, 22);
        menuClientes.Text = "Clientes";
        // 
        // menuMiCuenta
        // 
        menuMiCuenta.Name = "menuMiCuenta";
        menuMiCuenta.Size = new Size(161, 22);
        menuMiCuenta.Text = "Mi cuenta";
        // 
        // menuCambiarUsuario
        // 
        menuCambiarUsuario.Name = "menuCambiarUsuario";
        menuCambiarUsuario.Size = new Size(161, 22);
        menuCambiarUsuario.Text = "Cambiar usuario";
        // 
        // menuSalir
        // 
        menuSalir.Name = "menuSalir";
        menuSalir.Size = new Size(41, 22);
        menuSalir.Text = "Salir";
        // 
        // FrmPrincipal
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LavenderBlush;
        ClientSize = new Size(858, 469);
        Controls.Add(lblTitulo);
        Controls.Add(btnUsuarios);
        Controls.Add(btnClientes);
        Controls.Add(btnCambiarUsuario);
        Controls.Add(btnMiCuenta);
        Controls.Add(btnEstadios);
        Controls.Add(btnZonas);
        Controls.Add(btnAsientos);
        Controls.Add(btnEquipos);
        Controls.Add(btnPartidos);
        Controls.Add(btnVentas);
        Controls.Add(btnCancelaciones);
        Controls.Add(btnFacturas);
        Controls.Add(btnReporteVentas);
        Controls.Add(btnReporteOcupacion);
        Controls.Add(btnHistorial);
        Controls.Add(menuPrincipal);
        MainMenuStrip = menuPrincipal;
        Margin = new Padding(3, 2, 3, 2);
        MinimumSize = new Size(873, 506);
        Name = "FrmPrincipal";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Sistema de boletos ";
        menuPrincipal.ResumeLayout(false);
        menuPrincipal.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
