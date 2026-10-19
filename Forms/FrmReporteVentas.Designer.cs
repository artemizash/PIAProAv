using System.Drawing;
using System.Windows.Forms;

namespace TemplateCSharp.Forms;

// Editar controles con: clic derecho en FrmReporteVentas.cs > Ver diseñador.
partial class FrmReporteVentas
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lblDescripcion = null!;
    private Label lblCampo1 = null!;
    private DateTimePicker campo1 = null!;
    private Label lblCampo2 = null!;
    private DateTimePicker campo2 = null!;
    private Label lblCampo3 = null!;
    private ComboBox campo3 = null!;
    private Label lblCampo4 = null!;
    private ComboBox campo4 = null!;
    private Button btnGuardar = null!;
    private Button btnConsultar = null!;
    private Button btnRegresar = null!;
    private DataGridView dgvDatos = null!;
    private DataGridViewTextBoxColumn colCampo1 = null!;
    private DataGridViewTextBoxColumn colCampo2 = null!;
    private DataGridViewTextBoxColumn colCampo3 = null!;
    private DataGridViewTextBoxColumn colCampo4 = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblDescripcion = new Label();
        lblCampo1 = new Label();
        campo1 = new DateTimePicker();
        lblCampo2 = new Label();
        campo2 = new DateTimePicker();
        lblCampo3 = new Label();
        campo3 = new ComboBox();
        lblCampo4 = new Label();
        campo4 = new ComboBox();
        btnGuardar = new Button();
        btnConsultar = new Button();
        btnRegresar = new Button();
        dgvDatos = new DataGridView();
        colCampo1 = new DataGridViewTextBoxColumn();
        colCampo2 = new DataGridViewTextBoxColumn();
        colCampo3 = new DataGridViewTextBoxColumn();
        colCampo4 = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.DimGray;
        lblTitulo.Location = new Point(32, 29);
        lblTitulo.Margin = new Padding(4, 0, 4, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(1138, 59);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "REPORTE DE VENTAS";
        // 
        // lblDescripcion
        // 
        lblDescripcion.ForeColor = Color.Gray;
        lblDescripcion.Location = new Point(35, 100);
        lblDescripcion.Margin = new Padding(4, 0, 4, 0);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(1106, 38);
        lblDescripcion.TabIndex = 0;
        lblDescripcion.Text = "Consultar ventas por periodo y partido.";
        // 
        // lblCampo1
        // 
        lblCampo1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo1.Location = new Point(35, 218);
        lblCampo1.Margin = new Padding(4, 0, 4, 0);
        lblCampo1.Name = "lblCampo1";
        lblCampo1.Size = new Size(181, 31);
        lblCampo1.TabIndex = 0;
        lblCampo1.Text = "Fecha inicio:";
        lblCampo1.TextAlign = ContentAlignment.TopRight;
        // 
        // campo1
        // 
        campo1.CustomFormat = "dd-MMM-yyyy HH:mm";
        campo1.Enabled = false;
        campo1.Format = DateTimePickerFormat.Custom;
        campo1.Location = new Point(220, 211);
        campo1.Margin = new Padding(4, 4, 4, 4);
        campo1.Name = "campo1";
        campo1.Size = new Size(355, 31);
        campo1.TabIndex = 0;
        // 
        // lblCampo2
        // 
        lblCampo2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo2.Location = new Point(619, 218);
        lblCampo2.Margin = new Padding(4, 0, 4, 0);
        lblCampo2.Name = "lblCampo2";
        lblCampo2.Size = new Size(181, 31);
        lblCampo2.TabIndex = 0;
        lblCampo2.Text = "Fecha fin:";
        lblCampo2.TextAlign = ContentAlignment.TopRight;
        // 
        // campo2
        // 
        campo2.CustomFormat = "dd-MMM-yyyy HH:mm";
        campo2.Enabled = false;
        campo2.Format = DateTimePickerFormat.Custom;
        campo2.Location = new Point(804, 211);
        campo2.Margin = new Padding(4, 4, 4, 4);
        campo2.Name = "campo2";
        campo2.Size = new Size(355, 31);
        campo2.TabIndex = 0;
        // 
        // lblCampo3
        // 
        lblCampo3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo3.Location = new Point(35, 289);
        lblCampo3.Margin = new Padding(4, 0, 4, 0);
        lblCampo3.Name = "lblCampo3";
        lblCampo3.Size = new Size(181, 31);
        lblCampo3.TabIndex = 0;
        lblCampo3.Text = "Estadio:";
        lblCampo3.TextAlign = ContentAlignment.TopRight;
        // 
        // campo3
        // 
        campo3.DropDownStyle = ComboBoxStyle.DropDownList;
        campo3.Enabled = false;
        campo3.Location = new Point(220, 282);
        campo3.Margin = new Padding(4, 4, 4, 4);
        campo3.Name = "campo3";
        campo3.Size = new Size(355, 33);
        campo3.TabIndex = 0;
        // 
        // lblCampo4
        // 
        lblCampo4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo4.Location = new Point(619, 289);
        lblCampo4.Margin = new Padding(4, 0, 4, 0);
        lblCampo4.Name = "lblCampo4";
        lblCampo4.Size = new Size(181, 31);
        lblCampo4.TabIndex = 0;
        lblCampo4.Text = "Partido:";
        lblCampo4.TextAlign = ContentAlignment.TopRight;
        // 
        // campo4
        // 
        campo4.DropDownStyle = ComboBoxStyle.DropDownList;
        campo4.Enabled = false;
        campo4.Location = new Point(804, 282);
        campo4.Margin = new Padding(4, 4, 4, 4);
        campo4.Name = "campo4";
        campo4.Size = new Size(355, 33);
        campo4.TabIndex = 0;
        // 
        // btnGuardar
        // 
        btnGuardar.BackColor = Color.HotPink;
        btnGuardar.Enabled = false;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnGuardar.ForeColor = Color.Transparent;
        btnGuardar.Location = new Point(35, 460);
        btnGuardar.Margin = new Padding(4, 4, 4, 4);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(294, 54);
        btnGuardar.TabIndex = 0;
        btnGuardar.Text = "Guardar ";
        btnGuardar.UseVisualStyleBackColor = false;
        // 
        // btnConsultar
        // 
        btnConsultar.BackColor = Color.HotPink;
        btnConsultar.Enabled = false;
        btnConsultar.FlatStyle = FlatStyle.Flat;
        btnConsultar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnConsultar.ForeColor = Color.Transparent;
        btnConsultar.Location = new Point(349, 460);
        btnConsultar.Margin = new Padding(4, 4, 4, 4);
        btnConsultar.Name = "btnConsultar";
        btnConsultar.Size = new Size(294, 54);
        btnConsultar.TabIndex = 0;
        btnConsultar.Text = "Consultar ";
        btnConsultar.UseVisualStyleBackColor = false;
        // 
        // btnRegresar
        // 
        btnRegresar.BackColor = Color.HotPink;
        btnRegresar.FlatStyle = FlatStyle.Flat;
        btnRegresar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnRegresar.ForeColor = Color.Transparent;
        btnRegresar.Location = new Point(991, 460);
        btnRegresar.Margin = new Padding(4, 4, 4, 4);
        btnRegresar.Name = "btnRegresar";
        btnRegresar.Size = new Size(175, 54);
        btnRegresar.TabIndex = 0;
        btnRegresar.Text = "Regresar";
        btnRegresar.UseVisualStyleBackColor = false;
        // 
        // dgvDatos
        // 
        dgvDatos.AllowUserToAddRows = false;
        dgvDatos.AllowUserToDeleteRows = false;
        dgvDatos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvDatos.BackgroundColor = Color.White;
        dgvDatos.ColumnHeadersHeight = 34;
        dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colCampo1, colCampo2, colCampo3, colCampo4 });
        dgvDatos.Enabled = false;
        dgvDatos.Location = new Point(35, 544);
        dgvDatos.Margin = new Padding(4, 4, 4, 4);
        dgvDatos.MultiSelect = false;
        dgvDatos.Name = "dgvDatos";
        dgvDatos.ReadOnly = true;
        dgvDatos.RowHeadersWidth = 62;
        dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDatos.Size = new Size(1131, 225);
        dgvDatos.TabIndex = 0;
        // 
        // colCampo1
        // 
        colCampo1.HeaderText = "Fecha inicio";
        colCampo1.MinimumWidth = 8;
        colCampo1.Name = "colCampo1";
        colCampo1.ReadOnly = true;
        // 
        // colCampo2
        // 
        colCampo2.HeaderText = "Fecha fin";
        colCampo2.MinimumWidth = 8;
        colCampo2.Name = "colCampo2";
        colCampo2.ReadOnly = true;
        // 
        // colCampo3
        // 
        colCampo3.HeaderText = "Estadio";
        colCampo3.MinimumWidth = 8;
        colCampo3.Name = "colCampo3";
        colCampo3.ReadOnly = true;
        // 
        // colCampo4
        // 
        colCampo4.HeaderText = "Partido";
        colCampo4.MinimumWidth = 8;
        colCampo4.Name = "colCampo4";
        colCampo4.ReadOnly = true;
        // 
        // FrmReporteVentas
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LavenderBlush;
        ClientSize = new Size(1212, 819);
        Controls.Add(lblTitulo);
        Controls.Add(lblDescripcion);
        Controls.Add(lblCampo1);
        Controls.Add(campo1);
        Controls.Add(lblCampo2);
        Controls.Add(campo2);
        Controls.Add(lblCampo3);
        Controls.Add(campo3);
        Controls.Add(lblCampo4);
        Controls.Add(campo4);
        Controls.Add(btnGuardar);
        Controls.Add(btnConsultar);
        Controls.Add(btnRegresar);
        Controls.Add(dgvDatos);
        Margin = new Padding(4, 4, 4, 4);
        MinimumSize = new Size(1227, 855);
        Name = "FrmReporteVentas";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Reporte de ventas";
        ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
        ResumeLayout(false);
    }
}
