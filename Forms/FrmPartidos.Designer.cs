using System.Drawing;
using System.Windows.Forms;

namespace TemplateCSharp.Forms;

// Editar controles con: clic derecho en FrmPartidos.cs > Ver diseñador.
partial class FrmPartidos
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lblDescripcion = null!;
    private Label lblCampo1 = null!;
    private ComboBox campo1 = null!;
    private Label lblCampo2 = null!;
    private DateTimePicker campo2 = null!;
    private Label lblCampo3 = null!;
    private ComboBox campo3 = null!;
    private Label lblCampo4 = null!;
    private ComboBox campo4 = null!;
    private Label lblCampo5 = null!;
    private ComboBox campo5 = null!;
    private Button btnGuardar = null!;
    private Button btnRegresar = null!;
    private DataGridView dgvDatos = null!;
    private DataGridViewTextBoxColumn colCampo1 = null!;
    private DataGridViewTextBoxColumn colCampo2 = null!;
    private DataGridViewTextBoxColumn colCampo3 = null!;
    private DataGridViewTextBoxColumn colCampo4 = null!;
    private DataGridViewTextBoxColumn colCampo5 = null!;

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
        campo1 = new ComboBox();
        lblCampo2 = new Label();
        campo2 = new DateTimePicker();
        lblCampo3 = new Label();
        campo3 = new ComboBox();
        lblCampo4 = new Label();
        campo4 = new ComboBox();
        lblCampo5 = new Label();
        campo5 = new ComboBox();
        btnGuardar = new Button();
        btnRegresar = new Button();
        dgvDatos = new DataGridView();
        colCampo1 = new DataGridViewTextBoxColumn();
        colCampo2 = new DataGridViewTextBoxColumn();
        colCampo3 = new DataGridViewTextBoxColumn();
        colCampo4 = new DataGridViewTextBoxColumn();
        colCampo5 = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.DimGray;
        lblTitulo.Location = new Point(26, 23);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(910, 47);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "PARTIDOS";
        // 
        // lblDescripcion
        // 
        lblDescripcion.ForeColor = Color.Gray;
        lblDescripcion.Location = new Point(28, 80);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(885, 30);
        lblDescripcion.TabIndex = 0;
        lblDescripcion.Text = "Programar partidos y seleccionar equipos.";
        // 
        // lblCampo1
        // 
        lblCampo1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo1.Location = new Point(28, 173);
        lblCampo1.Name = "lblCampo1";
        lblCampo1.Size = new Size(145, 25);
        lblCampo1.TabIndex = 0;
        lblCampo1.Text = "Estadio:";
        lblCampo1.TextAlign = ContentAlignment.TopRight;
        // 
        // campo1
        // 
        campo1.DropDownStyle = ComboBoxStyle.DropDownList;
        campo1.Enabled = false;
        campo1.Location = new Point(176, 169);
        campo1.Name = "campo1";
        campo1.Size = new Size(285, 28);
        campo1.TabIndex = 0;
        // 
        // lblCampo2
        // 
        lblCampo2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo2.Location = new Point(492, 173);
        lblCampo2.Name = "lblCampo2";
        lblCampo2.Size = new Size(145, 25);
        lblCampo2.TabIndex = 0;
        lblCampo2.Text = "Fecha y hora:";
        lblCampo2.TextAlign = ContentAlignment.TopRight;
        // 
        // campo2
        // 
        campo2.CustomFormat = "dd-MMM-yyyy HH:mm";
        campo2.Enabled = false;
        campo2.Format = DateTimePickerFormat.Custom;
        campo2.Location = new Point(643, 169);
        campo2.Name = "campo2";
        campo2.Size = new Size(285, 27);
        campo2.TabIndex = 0;
        // 
        // lblCampo3
        // 
        lblCampo3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo3.Location = new Point(28, 228);
        lblCampo3.Name = "lblCampo3";
        lblCampo3.Size = new Size(145, 25);
        lblCampo3.TabIndex = 0;
        lblCampo3.Text = "Equipo local:";
        lblCampo3.TextAlign = ContentAlignment.TopRight;
        // 
        // campo3
        // 
        campo3.DropDownStyle = ComboBoxStyle.DropDownList;
        campo3.Enabled = false;
        campo3.Location = new Point(176, 226);
        campo3.Name = "campo3";
        campo3.Size = new Size(285, 28);
        campo3.TabIndex = 0;
        // 
        // lblCampo4
        // 
        lblCampo4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo4.Location = new Point(495, 228);
        lblCampo4.Name = "lblCampo4";
        lblCampo4.Size = new Size(145, 25);
        lblCampo4.TabIndex = 0;
        lblCampo4.Text = "Equipo visitante:";
        lblCampo4.TextAlign = ContentAlignment.TopRight;
        // 
        // campo4
        // 
        campo4.DropDownStyle = ComboBoxStyle.DropDownList;
        campo4.Enabled = false;
        campo4.Location = new Point(643, 226);
        campo4.Name = "campo4";
        campo4.Size = new Size(285, 28);
        campo4.TabIndex = 0;
        // 
        // lblCampo5
        // 
        lblCampo5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo5.Location = new Point(28, 286);
        lblCampo5.Name = "lblCampo5";
        lblCampo5.Size = new Size(145, 25);
        lblCampo5.TabIndex = 0;
        lblCampo5.Text = "Estado:";
        lblCampo5.TextAlign = ContentAlignment.TopRight;
        // 
        // campo5
        // 
        campo5.DropDownStyle = ComboBoxStyle.DropDownList;
        campo5.Enabled = false;
        campo5.Location = new Point(176, 283);
        campo5.Name = "campo5";
        campo5.Size = new Size(285, 28);
        campo5.TabIndex = 0;
        // 
        // btnGuardar
        // 
        btnGuardar.BackColor = Color.HotPink;
        btnGuardar.Enabled = false;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnGuardar.ForeColor = Color.Transparent;
        btnGuardar.Location = new Point(28, 368);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(235, 43);
        btnGuardar.TabIndex = 0;
        btnGuardar.Text = "Guardar ";
        btnGuardar.UseVisualStyleBackColor = false;
        // 
        // btnRegresar
        // 
        btnRegresar.BackColor = Color.HotPink;
        btnRegresar.FlatStyle = FlatStyle.Flat;
        btnRegresar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnRegresar.ForeColor = Color.Transparent;
        btnRegresar.Location = new Point(793, 368);
        btnRegresar.Name = "btnRegresar";
        btnRegresar.Size = new Size(140, 43);
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
        dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colCampo1, colCampo2, colCampo3, colCampo4, colCampo5 });
        dgvDatos.Enabled = false;
        dgvDatos.Location = new Point(28, 435);
        dgvDatos.MultiSelect = false;
        dgvDatos.Name = "dgvDatos";
        dgvDatos.ReadOnly = true;
        dgvDatos.RowHeadersWidth = 62;
        dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDatos.Size = new Size(905, 180);
        dgvDatos.TabIndex = 0;
        // 
        // colCampo1
        // 
        colCampo1.HeaderText = "Estadio";
        colCampo1.MinimumWidth = 8;
        colCampo1.Name = "colCampo1";
        colCampo1.ReadOnly = true;
        // 
        // colCampo2
        // 
        colCampo2.HeaderText = "Fecha y hora";
        colCampo2.MinimumWidth = 8;
        colCampo2.Name = "colCampo2";
        colCampo2.ReadOnly = true;
        // 
        // colCampo3
        // 
        colCampo3.HeaderText = "Equipo local";
        colCampo3.MinimumWidth = 8;
        colCampo3.Name = "colCampo3";
        colCampo3.ReadOnly = true;
        // 
        // colCampo4
        // 
        colCampo4.HeaderText = "Equipo visitante";
        colCampo4.MinimumWidth = 8;
        colCampo4.Name = "colCampo4";
        colCampo4.ReadOnly = true;
        // 
        // colCampo5
        // 
        colCampo5.HeaderText = "Estado";
        colCampo5.MinimumWidth = 8;
        colCampo5.Name = "colCampo5";
        colCampo5.ReadOnly = true;
        // 
        // FrmPartidos
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LavenderBlush;
        ClientSize = new Size(970, 655);
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
        Controls.Add(lblCampo5);
        Controls.Add(campo5);
        Controls.Add(btnGuardar);
        Controls.Add(btnRegresar);
        Controls.Add(dgvDatos);
        MinimumSize = new Size(985, 693);
        Name = "FrmPartidos";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Partidos ";
        ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
        ResumeLayout(false);
    }
}
