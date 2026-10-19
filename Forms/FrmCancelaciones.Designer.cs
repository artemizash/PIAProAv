using System.Drawing;
using System.Windows.Forms;

namespace TemplateCSharp.Forms;

// Editar controles con: clic derecho en FrmCancelaciones.cs > Ver diseñador.
partial class FrmCancelaciones
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lblDescripcion = null!;
    private Label lblCampo1 = null!;
    private TextBox campo1 = null!;
    private Label lblCampo2 = null!;
    private TextBox campo2 = null!;
    private Label lblCampo3 = null!;
    private ComboBox campo3 = null!;
    private Button btnGuardar = null!;
    private Button btnConsultar = null!;
    private Button btnRegresar = null!;
    private DataGridView dgvDatos = null!;
    private DataGridViewTextBoxColumn colCampo1 = null!;
    private DataGridViewTextBoxColumn colCampo2 = null!;
    private DataGridViewTextBoxColumn colCampo3 = null!;

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
        campo1 = new TextBox();
        lblCampo2 = new Label();
        campo2 = new TextBox();
        lblCampo3 = new Label();
        campo3 = new ComboBox();
        btnGuardar = new Button();
        btnConsultar = new Button();
        btnRegresar = new Button();
        dgvDatos = new DataGridView();
        colCampo1 = new DataGridViewTextBoxColumn();
        colCampo2 = new DataGridViewTextBoxColumn();
        colCampo3 = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Font = new Font("Segoe UI", 21F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.DimGray;
        lblTitulo.Location = new Point(33, 28);
        lblTitulo.Margin = new Padding(4, 0, 4, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(1137, 58);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "CANCELACIONES";
        // 
        // lblDescripcion
        // 
        lblDescripcion.ForeColor = Color.Gray;
        lblDescripcion.Location = new Point(34, 100);
        lblDescripcion.Margin = new Padding(4, 0, 4, 0);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(1106, 37);
        lblDescripcion.TabIndex = 0;
        lblDescripcion.Text = "Registrar cancelaciones autorizadas por administradores.";
        // 
        // lblCampo1
        // 
        lblCampo1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo1.Location = new Point(34, 212);
        lblCampo1.Margin = new Padding(4, 0, 4, 0);
        lblCampo1.Name = "lblCampo1";
        lblCampo1.Size = new Size(181, 32);
        lblCampo1.TabIndex = 0;
        lblCampo1.Text = "Folio de compra:";
        lblCampo1.TextAlign = ContentAlignment.TopRight;
        lblCampo1.Click += lblCampo1_Click;
        // 
        // campo1
        // 
        campo1.Enabled = false;
        campo1.Location = new Point(220, 212);
        campo1.Margin = new Padding(4, 3, 4, 3);
        campo1.MaxLength = 200;
        campo1.Name = "campo1";
        campo1.Size = new Size(355, 31);
        campo1.TabIndex = 0;
        // 
        // lblCampo2
        // 
        lblCampo2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo2.Location = new Point(615, 211);
        lblCampo2.Margin = new Padding(4, 0, 4, 0);
        lblCampo2.Name = "lblCampo2";
        lblCampo2.Size = new Size(181, 32);
        lblCampo2.TabIndex = 0;
        lblCampo2.Text = "Motivo:";
        lblCampo2.TextAlign = ContentAlignment.TopRight;
        // 
        // campo2
        // 
        campo2.Enabled = false;
        campo2.Location = new Point(804, 212);
        campo2.Margin = new Padding(4, 3, 4, 3);
        campo2.MaxLength = 200;
        campo2.Name = "campo2";
        campo2.Size = new Size(355, 31);
        campo2.TabIndex = 0;
        // 
        // lblCampo3
        // 
        lblCampo3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo3.Location = new Point(34, 283);
        lblCampo3.Margin = new Padding(4, 0, 4, 0);
        lblCampo3.Name = "lblCampo3";
        lblCampo3.Size = new Size(181, 32);
        lblCampo3.TabIndex = 0;
        lblCampo3.Text = "Administrador:";
        lblCampo3.TextAlign = ContentAlignment.TopRight;
        // 
        // campo3
        // 
        campo3.DropDownStyle = ComboBoxStyle.DropDownList;
        campo3.Enabled = false;
        campo3.Location = new Point(220, 283);
        campo3.Margin = new Padding(4, 3, 4, 3);
        campo3.Name = "campo3";
        campo3.Size = new Size(355, 33);
        campo3.TabIndex = 0;
        // 
        // btnGuardar
        // 
        btnGuardar.BackColor = Color.HotPink;
        btnGuardar.Enabled = false;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnGuardar.ForeColor = Color.Transparent;
        btnGuardar.Location = new Point(34, 460);
        btnGuardar.Margin = new Padding(4, 3, 4, 3);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(294, 53);
        btnGuardar.TabIndex = 0;
        btnGuardar.Text = "Guardar ";
        btnGuardar.UseVisualStyleBackColor = false;
        btnGuardar.Click += btnGuardar_Click;
        // 
        // btnConsultar
        // 
        btnConsultar.BackColor = Color.HotPink;
        btnConsultar.Enabled = false;
        btnConsultar.FlatStyle = FlatStyle.Flat;
        btnConsultar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnConsultar.ForeColor = Color.Transparent;
        btnConsultar.Location = new Point(349, 460);
        btnConsultar.Margin = new Padding(4, 3, 4, 3);
        btnConsultar.Name = "btnConsultar";
        btnConsultar.Size = new Size(294, 53);
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
        btnRegresar.Margin = new Padding(4, 3, 4, 3);
        btnRegresar.Name = "btnRegresar";
        btnRegresar.Size = new Size(174, 53);
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
        dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colCampo1, colCampo2, colCampo3 });
        dgvDatos.Enabled = false;
        dgvDatos.Location = new Point(34, 543);
        dgvDatos.Margin = new Padding(4, 3, 4, 3);
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
        colCampo1.HeaderText = "Folio de compra";
        colCampo1.MinimumWidth = 8;
        colCampo1.Name = "colCampo1";
        colCampo1.ReadOnly = true;
        // 
        // colCampo2
        // 
        colCampo2.HeaderText = "Motivo";
        colCampo2.MinimumWidth = 8;
        colCampo2.Name = "colCampo2";
        colCampo2.ReadOnly = true;
        // 
        // colCampo3
        // 
        colCampo3.HeaderText = "Administrador";
        colCampo3.MinimumWidth = 8;
        colCampo3.Name = "colCampo3";
        colCampo3.ReadOnly = true;
        // 
        // FrmCancelaciones
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LavenderBlush;
        ClientSize = new Size(1213, 820);
        Controls.Add(lblTitulo);
        Controls.Add(lblDescripcion);
        Controls.Add(lblCampo1);
        Controls.Add(campo1);
        Controls.Add(lblCampo2);
        Controls.Add(campo2);
        Controls.Add(lblCampo3);
        Controls.Add(campo3);
        Controls.Add(btnGuardar);
        Controls.Add(btnConsultar);
        Controls.Add(btnRegresar);
        Controls.Add(dgvDatos);
        Margin = new Padding(4, 3, 4, 3);
        MinimumSize = new Size(1226, 848);
        Name = "FrmCancelaciones";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Cancelaciones - Diseño del avance 1";
        ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
