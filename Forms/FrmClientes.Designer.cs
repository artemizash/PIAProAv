using System.Drawing;
using System.Windows.Forms;

namespace TemplateCSharp.Forms;

// Editar controles con: clic derecho en FrmClientes.cs > Ver diseñador.
partial class FrmClientes
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lbl_txtNombre = null!;
    private TextBox txtNombre = null!;
    private Label lbl_txtRfc = null!;
    private TextBox txtRfc = null!;
    private Label lbl_txtDomicilio = null!;
    private TextBox txtDomicilio = null!;
    private Label lbl_txtCorreo = null!;
    private TextBox txtCorreo = null!;
    private Label lbl_txtCasa = null!;
    private TextBox txtCasa = null!;
    private Label lbl_txtCelular = null!;
    private TextBox txtCelular = null!;
    private Label lbl_dtpNacimiento = null!;
    private DateTimePicker dtpNacimiento = null!;
    private Button btnNuevo = null!;
    private Button btnGuardar = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnBuscar = null!;
    private TextBox txtFiltro = null!;
    private DataGridView dgvDatos = null!;
    private DataGridViewTextBoxColumn col_IdCliente = null!;
    private DataGridViewTextBoxColumn col_NombreCompleto = null!;
    private DataGridViewTextBoxColumn col_Rfc = null!;
    private DataGridViewTextBoxColumn col_Correo = null!;
    private DataGridViewTextBoxColumn col_TelefonoCelular = null!;
    private DataGridViewTextBoxColumn col_FechaNacimiento = null!;
    private DataGridViewTextBoxColumn col_FechaRegistro = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lbl_txtNombre = new Label();
        txtNombre = new TextBox();
        lbl_txtRfc = new Label();
        txtRfc = new TextBox();
        lbl_txtDomicilio = new Label();
        txtDomicilio = new TextBox();
        lbl_txtCorreo = new Label();
        txtCorreo = new TextBox();
        lbl_txtCasa = new Label();
        txtCasa = new TextBox();
        lbl_txtCelular = new Label();
        txtCelular = new TextBox();
        lbl_dtpNacimiento = new Label();
        dtpNacimiento = new DateTimePicker();
        btnNuevo = new Button();
        btnGuardar = new Button();
        btnActualizar = new Button();
        btnEliminar = new Button();
        btnBuscar = new Button();
        txtFiltro = new TextBox();
        dgvDatos = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.DimGray;
        lblTitulo.Location = new Point(31, 19);
        lblTitulo.Margin = new Padding(4, 0, 4, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(675, 59);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "CLIENTES";
        // 
        // lbl_txtNombre
        // 
        lbl_txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtNombre.Location = new Point(31, 97);
        lbl_txtNombre.Margin = new Padding(4, 0, 4, 0);
        lbl_txtNombre.Name = "lbl_txtNombre";
        lbl_txtNombre.Size = new Size(185, 31);
        lbl_txtNombre.TabIndex = 0;
        lbl_txtNombre.Text = "Nombre completo:";
        lbl_txtNombre.TextAlign = ContentAlignment.TopRight;
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(225, 94);
        txtNombre.Margin = new Padding(4, 4, 4, 4);
        txtNombre.MaxLength = 150;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(436, 31);
        txtNombre.TabIndex = 0;
        // 
        // lbl_txtRfc
        // 
        lbl_txtRfc.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtRfc.Location = new Point(713, 97);
        lbl_txtRfc.Margin = new Padding(4, 0, 4, 0);
        lbl_txtRfc.Name = "lbl_txtRfc";
        lbl_txtRfc.Size = new Size(185, 31);
        lbl_txtRfc.TabIndex = 0;
        lbl_txtRfc.Text = "RFC:";
        lbl_txtRfc.TextAlign = ContentAlignment.TopRight;
        // 
        // txtRfc
        // 
        txtRfc.Location = new Point(906, 94);
        txtRfc.Margin = new Padding(4, 4, 4, 4);
        txtRfc.MaxLength = 13;
        txtRfc.Name = "txtRfc";
        txtRfc.Size = new Size(436, 31);
        txtRfc.TabIndex = 0;
        // 
        // lbl_txtDomicilio
        // 
        lbl_txtDomicilio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtDomicilio.Location = new Point(31, 161);
        lbl_txtDomicilio.Margin = new Padding(4, 0, 4, 0);
        lbl_txtDomicilio.Name = "lbl_txtDomicilio";
        lbl_txtDomicilio.Size = new Size(185, 31);
        lbl_txtDomicilio.TabIndex = 0;
        lbl_txtDomicilio.Text = "Domicilio:";
        lbl_txtDomicilio.TextAlign = ContentAlignment.TopRight;
        // 
        // txtDomicilio
        // 
        txtDomicilio.Location = new Point(225, 158);
        txtDomicilio.Margin = new Padding(4, 4, 4, 4);
        txtDomicilio.MaxLength = 255;
        txtDomicilio.Name = "txtDomicilio";
        txtDomicilio.Size = new Size(436, 31);
        txtDomicilio.TabIndex = 0;
        // 
        // lbl_txtCorreo
        // 
        lbl_txtCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtCorreo.Location = new Point(713, 161);
        lbl_txtCorreo.Margin = new Padding(4, 0, 4, 0);
        lbl_txtCorreo.Name = "lbl_txtCorreo";
        lbl_txtCorreo.Size = new Size(185, 31);
        lbl_txtCorreo.TabIndex = 0;
        lbl_txtCorreo.Text = "Correo electrónico:";
        lbl_txtCorreo.TextAlign = ContentAlignment.TopRight;
        // 
        // txtCorreo
        // 
        txtCorreo.Location = new Point(906, 158);
        txtCorreo.Margin = new Padding(4, 4, 4, 4);
        txtCorreo.MaxLength = 100;
        txtCorreo.Name = "txtCorreo";
        txtCorreo.Size = new Size(436, 31);
        txtCorreo.TabIndex = 0;
        // 
        // lbl_txtCasa
        // 
        lbl_txtCasa.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtCasa.Location = new Point(31, 221);
        lbl_txtCasa.Margin = new Padding(4, 0, 4, 0);
        lbl_txtCasa.Name = "lbl_txtCasa";
        lbl_txtCasa.Size = new Size(185, 31);
        lbl_txtCasa.TabIndex = 0;
        lbl_txtCasa.Text = "Teléfono casa:";
        lbl_txtCasa.TextAlign = ContentAlignment.TopRight;
        // 
        // txtCasa
        // 
        txtCasa.Location = new Point(225, 221);
        txtCasa.Margin = new Padding(4, 4, 4, 4);
        txtCasa.MaxLength = 15;
        txtCasa.Name = "txtCasa";
        txtCasa.Size = new Size(436, 31);
        txtCasa.TabIndex = 0;
        // 
        // lbl_txtCelular
        // 
        lbl_txtCelular.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtCelular.ForeColor = Color.Black;
        lbl_txtCelular.Location = new Point(713, 224);
        lbl_txtCelular.Margin = new Padding(4, 0, 4, 0);
        lbl_txtCelular.Name = "lbl_txtCelular";
        lbl_txtCelular.Size = new Size(185, 31);
        lbl_txtCelular.TabIndex = 0;
        lbl_txtCelular.Text = "Teléfono celular:";
        lbl_txtCelular.TextAlign = ContentAlignment.TopRight;
        // 
        // txtCelular
        // 
        txtCelular.Location = new Point(906, 221);
        txtCelular.Margin = new Padding(4, 4, 4, 4);
        txtCelular.MaxLength = 15;
        txtCelular.Name = "txtCelular";
        txtCelular.Size = new Size(436, 31);
        txtCelular.TabIndex = 0;
        // 
        // lbl_dtpNacimiento
        // 
        lbl_dtpNacimiento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_dtpNacimiento.Location = new Point(31, 278);
        lbl_dtpNacimiento.Margin = new Padding(4, 0, 4, 0);
        lbl_dtpNacimiento.Name = "lbl_dtpNacimiento";
        lbl_dtpNacimiento.Size = new Size(185, 32);
        lbl_dtpNacimiento.TabIndex = 0;
        lbl_dtpNacimiento.Text = "Nacimiento:";
        lbl_dtpNacimiento.TextAlign = ContentAlignment.TopRight;
        // 
        // dtpNacimiento
        // 
        dtpNacimiento.CustomFormat = "dd-MMM-yyyy";
        dtpNacimiento.Format = DateTimePickerFormat.Custom;
        dtpNacimiento.Location = new Point(225, 279);
        dtpNacimiento.Margin = new Padding(4, 4, 4, 4);
        dtpNacimiento.Name = "dtpNacimiento";
        dtpNacimiento.Size = new Size(436, 31);
        dtpNacimiento.TabIndex = 0;
        // 
        // btnNuevo
        // 
        btnNuevo.BackColor = Color.HotPink;
        btnNuevo.FlatStyle = FlatStyle.Flat;
        btnNuevo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnNuevo.ForeColor = Color.Transparent;
        btnNuevo.Location = new Point(31, 349);
        btnNuevo.Margin = new Padding(4, 4, 4, 4);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(188, 50);
        btnNuevo.TabIndex = 0;
        btnNuevo.Text = "Nuevo";
        btnNuevo.UseVisualStyleBackColor = false;
        // 
        // btnGuardar
        // 
        btnGuardar.BackColor = Color.MediumVioletRed;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnGuardar.ForeColor = Color.Transparent;
        btnGuardar.Location = new Point(235, 349);
        btnGuardar.Margin = new Padding(4, 4, 4, 4);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(188, 50);
        btnGuardar.TabIndex = 0;
        btnGuardar.Text = "Guardar";
        btnGuardar.UseVisualStyleBackColor = false;
        // 
        // btnActualizar
        // 
        btnActualizar.BackColor = Color.HotPink;
        btnActualizar.FlatStyle = FlatStyle.Flat;
        btnActualizar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnActualizar.ForeColor = Color.Transparent;
        btnActualizar.Location = new Point(439, 349);
        btnActualizar.Margin = new Padding(4, 4, 4, 4);
        btnActualizar.Name = "btnActualizar";
        btnActualizar.Size = new Size(188, 50);
        btnActualizar.TabIndex = 0;
        btnActualizar.Text = "Actualizar";
        btnActualizar.UseVisualStyleBackColor = false;
        // 
        // btnEliminar
        // 
        btnEliminar.BackColor = Color.HotPink;
        btnEliminar.FlatStyle = FlatStyle.Flat;
        btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnEliminar.ForeColor = Color.Transparent;
        btnEliminar.Location = new Point(642, 349);
        btnEliminar.Margin = new Padding(4, 4, 4, 4);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(188, 50);
        btnEliminar.TabIndex = 0;
        btnEliminar.Text = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = false;
        // 
        // btnBuscar
        // 
        btnBuscar.BackColor = Color.HotPink;
        btnBuscar.FlatStyle = FlatStyle.Flat;
        btnBuscar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnBuscar.ForeColor = Color.Transparent;
        btnBuscar.Location = new Point(846, 349);
        btnBuscar.Margin = new Padding(4, 4, 4, 4);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(188, 50);
        btnBuscar.TabIndex = 0;
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = false;
        // 
        // txtFiltro
        // 
        txtFiltro.Location = new Point(1072, 359);
        txtFiltro.Margin = new Padding(4, 4, 4, 4);
        txtFiltro.MaxLength = 150;
        txtFiltro.Name = "txtFiltro";
        txtFiltro.PlaceholderText = "Filtrar nombre o correo";
        txtFiltro.Size = new Size(294, 31);
        txtFiltro.TabIndex = 0;
        // 
        // dgvDatos
        // 
        dgvDatos.AllowUserToAddRows = false;
        dgvDatos.AllowUserToDeleteRows = false;
        dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDatos.BackgroundColor = Color.White;
        dgvDatos.ColumnHeadersHeight = 34;
        dgvDatos.Location = new Point(31, 430);
        dgvDatos.Margin = new Padding(4, 4, 4, 4);
        dgvDatos.MultiSelect = false;
        dgvDatos.Name = "dgvDatos";
        dgvDatos.ReadOnly = true;
        dgvDatos.RowHeadersWidth = 62;
        dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDatos.Size = new Size(1338, 431);
        dgvDatos.TabIndex = 0;
        // 
        // FrmClientes
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LavenderBlush;
        ClientSize = new Size(1400, 900);
        Controls.Add(lblTitulo);
        Controls.Add(lbl_txtNombre);
        Controls.Add(txtNombre);
        Controls.Add(lbl_txtRfc);
        Controls.Add(txtRfc);
        Controls.Add(lbl_txtDomicilio);
        Controls.Add(txtDomicilio);
        Controls.Add(lbl_txtCorreo);
        Controls.Add(txtCorreo);
        Controls.Add(lbl_txtCasa);
        Controls.Add(txtCasa);
        Controls.Add(lbl_txtCelular);
        Controls.Add(txtCelular);
        Controls.Add(lbl_dtpNacimiento);
        Controls.Add(dtpNacimiento);
        Controls.Add(btnNuevo);
        Controls.Add(btnGuardar);
        Controls.Add(btnActualizar);
        Controls.Add(btnEliminar);
        Controls.Add(btnBuscar);
        Controls.Add(txtFiltro);
        Controls.Add(dgvDatos);
        Margin = new Padding(4, 4, 4, 4);
        MinimumSize = new Size(1414, 936);
        Name = "FrmClientes";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Gestión de clientes";
        ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
