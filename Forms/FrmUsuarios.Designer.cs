using System.Drawing;
using System.Windows.Forms;

namespace TemplateCSharp.Forms;

// Editar controles con: clic derecho en FrmUsuarios.cs > Ver diseñador.
partial class FrmUsuarios
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lbl_txtNombre = null!;
    private TextBox txtNombre = null!;
    private Label lbl_txtCorreo = null!;
    private TextBox txtCorreo = null!;
    private Label lbl_txtNomina = null!;
    private TextBox txtNomina = null!;
    private Label lbl_cmbRol = null!;
    private ComboBox cmbRol = null!;
    private Label lbl_dtpNacimiento = null!;
    private DateTimePicker dtpNacimiento = null!;
    private Label lbl_txtContrasena = null!;
    private TextBox txtContrasena = null!;
    private Button btnNuevo = null!;
    private Button btnGuardar = null!;
    private Button btnActualizar = null!;
    private Button btnEliminar = null!;
    private Button btnBuscar = null!;
    private TextBox txtFiltro = null!;
    private DataGridView dgvDatos = null!;
    private DataGridViewTextBoxColumn col_IdUsuario = null!;
    private DataGridViewTextBoxColumn col_NombreCompleto = null!;
    private DataGridViewTextBoxColumn col_Correo = null!;
    private DataGridViewTextBoxColumn col_NumeroNomina = null!;
    private DataGridViewTextBoxColumn col_RolNombre = null!;
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
        lbl_txtCorreo = new Label();
        txtCorreo = new TextBox();
        lbl_txtNomina = new Label();
        txtNomina = new TextBox();
        lbl_txtContrasena = new Label();
        txtContrasena = new TextBox();
        lbl_cmbRol = new Label();
        cmbRol = new ComboBox();
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
        lblTitulo.Location = new Point(32, 18);
        lblTitulo.Margin = new Padding(4, 0, 4, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(662, 59);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "USUARIOS";
        // 
        // lbl_txtNombre
        // 
        lbl_txtNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtNombre.Location = new Point(31, 94);
        lbl_txtNombre.Margin = new Padding(4, 0, 4, 0);
        lbl_txtNombre.Name = "lbl_txtNombre";
        lbl_txtNombre.Size = new Size(175, 32);
        lbl_txtNombre.TabIndex = 0;
        lbl_txtNombre.Text = "Nombre completo:";
        lbl_txtNombre.TextAlign = ContentAlignment.TopRight;
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(225, 91);
        txtNombre.Margin = new Padding(4, 4, 4, 4);
        txtNombre.MaxLength = 150;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(436, 31);
        txtNombre.TabIndex = 0;
        // 
        // lbl_txtCorreo
        // 
        lbl_txtCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtCorreo.Location = new Point(712, 94);
        lbl_txtCorreo.Margin = new Padding(4, 0, 4, 0);
        lbl_txtCorreo.Name = "lbl_txtCorreo";
        lbl_txtCorreo.Size = new Size(175, 32);
        lbl_txtCorreo.TabIndex = 0;
        lbl_txtCorreo.Text = "Correo electrónico:";
        lbl_txtCorreo.TextAlign = ContentAlignment.TopRight;
        // 
        // txtCorreo
        // 
        txtCorreo.Location = new Point(906, 91);
        txtCorreo.Margin = new Padding(4, 4, 4, 4);
        txtCorreo.MaxLength = 100;
        txtCorreo.Name = "txtCorreo";
        txtCorreo.Size = new Size(436, 31);
        txtCorreo.TabIndex = 0;
        // 
        // lbl_txtNomina
        // 
        lbl_txtNomina.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtNomina.Location = new Point(31, 162);
        lbl_txtNomina.Margin = new Padding(4, 0, 4, 0);
        lbl_txtNomina.Name = "lbl_txtNomina";
        lbl_txtNomina.Size = new Size(175, 32);
        lbl_txtNomina.TabIndex = 0;
        lbl_txtNomina.Text = "Número de nómina:";
        lbl_txtNomina.TextAlign = ContentAlignment.TopRight;
        // 
        // txtNomina
        // 
        txtNomina.Location = new Point(225, 156);
        txtNomina.Margin = new Padding(4, 4, 4, 4);
        txtNomina.MaxLength = 20;
        txtNomina.Name = "txtNomina";
        txtNomina.Size = new Size(436, 31);
        txtNomina.TabIndex = 0;
        // 
        // lbl_txtContrasena
        // 
        lbl_txtContrasena.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_txtContrasena.Location = new Point(712, 224);
        lbl_txtContrasena.Margin = new Padding(4, 0, 4, 0);
        lbl_txtContrasena.Name = "lbl_txtContrasena";
        lbl_txtContrasena.Size = new Size(175, 32);
        lbl_txtContrasena.TabIndex = 0;
        lbl_txtContrasena.Text = "Contraseña nueva:";
        lbl_txtContrasena.TextAlign = ContentAlignment.TopRight;
        // 
        // txtContrasena
        // 
        txtContrasena.Location = new Point(906, 221);
        txtContrasena.Margin = new Padding(4, 4, 4, 4);
        txtContrasena.MaxLength = 255;
        txtContrasena.Name = "txtContrasena";
        txtContrasena.Size = new Size(436, 31);
        txtContrasena.TabIndex = 0;
        txtContrasena.UseSystemPasswordChar = true;
        // 
        // lbl_cmbRol
        // 
        lbl_cmbRol.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_cmbRol.Location = new Point(712, 159);
        lbl_cmbRol.Margin = new Padding(4, 0, 4, 0);
        lbl_cmbRol.Name = "lbl_cmbRol";
        lbl_cmbRol.Size = new Size(175, 31);
        lbl_cmbRol.TabIndex = 0;
        lbl_cmbRol.Text = "Rol:";
        lbl_cmbRol.TextAlign = ContentAlignment.TopRight;
        // 
        // cmbRol
        // 
        cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbRol.Location = new Point(906, 156);
        cmbRol.Margin = new Padding(4, 4, 4, 4);
        cmbRol.Name = "cmbRol";
        cmbRol.Size = new Size(436, 33);
        cmbRol.TabIndex = 0;
        // 
        // lbl_dtpNacimiento
        // 
        lbl_dtpNacimiento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lbl_dtpNacimiento.Location = new Point(32, 228);
        lbl_dtpNacimiento.Margin = new Padding(4, 0, 4, 0);
        lbl_dtpNacimiento.Name = "lbl_dtpNacimiento";
        lbl_dtpNacimiento.Size = new Size(175, 31);
        lbl_dtpNacimiento.TabIndex = 0;
        lbl_dtpNacimiento.Text = "Nacimiento:";
        lbl_dtpNacimiento.TextAlign = ContentAlignment.TopRight;
        // 
        // dtpNacimiento
        // 
        dtpNacimiento.CustomFormat = "dd-MMM-yyyy";
        dtpNacimiento.Format = DateTimePickerFormat.Custom;
        dtpNacimiento.Location = new Point(225, 221);
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
        btnNuevo.Location = new Point(31, 306);
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
        btnGuardar.ForeColor = Color.White;
        btnGuardar.Location = new Point(235, 306);
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
        btnActualizar.Location = new Point(439, 306);
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
        btnEliminar.Location = new Point(642, 306);
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
        btnBuscar.Location = new Point(846, 306);
        btnBuscar.Margin = new Padding(4, 4, 4, 4);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(188, 50);
        btnBuscar.TabIndex = 0;
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = false;
        // 
        // txtFiltro
        // 
        txtFiltro.Location = new Point(1072, 315);
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
        dgvDatos.Location = new Point(31, 388);
        dgvDatos.Margin = new Padding(4, 4, 4, 4);
        dgvDatos.MultiSelect = false;
        dgvDatos.Name = "dgvDatos";
        dgvDatos.ReadOnly = true;
        dgvDatos.RowHeadersWidth = 62;
        dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDatos.Size = new Size(1338, 458);
        dgvDatos.TabIndex = 0;
        // 
        // FrmUsuarios
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LavenderBlush;
        ClientSize = new Size(1400, 881);
        Controls.Add(lblTitulo);
        Controls.Add(lbl_txtNombre);
        Controls.Add(txtNombre);
        Controls.Add(lbl_txtCorreo);
        Controls.Add(txtCorreo);
        Controls.Add(lbl_txtNomina);
        Controls.Add(txtNomina);
        Controls.Add(lbl_cmbRol);
        Controls.Add(cmbRol);
        Controls.Add(lbl_dtpNacimiento);
        Controls.Add(dtpNacimiento);
        Controls.Add(lbl_txtContrasena);
        Controls.Add(txtContrasena);
        Controls.Add(btnNuevo);
        Controls.Add(btnGuardar);
        Controls.Add(btnActualizar);
        Controls.Add(btnEliminar);
        Controls.Add(btnBuscar);
        Controls.Add(txtFiltro);
        Controls.Add(dgvDatos);
        Margin = new Padding(4, 4, 4, 4);
        MinimumSize = new Size(1414, 916);
        Name = "FrmUsuarios";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Gestión de usuarios";
        ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
