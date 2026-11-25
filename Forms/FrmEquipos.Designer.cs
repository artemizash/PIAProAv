using System.Drawing;
using System.Windows.Forms;

namespace TemplateCSharp.Forms;

// Editar controles con: clic derecho en FrmEquipos.cs > Ver diseñador.
partial class FrmEquipos
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
        lblTitulo.Location = new Point(22, 17);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(797, 35);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "EQUIPOS";
        // 
        // lblDescripcion
        // 
        lblDescripcion.ForeColor = Color.Gray;
        lblDescripcion.Location = new Point(24, 60);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(774, 23);
        lblDescripcion.TabIndex = 0;
        lblDescripcion.Text = "Catálogo de equipos participantes.";
        // 
        // lblCampo1
        // 
        lblCampo1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo1.Location = new Point(24, 128);
        lblCampo1.Name = "lblCampo1";
        lblCampo1.Size = new Size(127, 19);
        lblCampo1.TabIndex = 0;
        lblCampo1.Text = "Nombre:";
        lblCampo1.TextAlign = ContentAlignment.TopRight;
        // 
        // campo1
        // 
        campo1.Enabled = false;
        campo1.Location = new Point(154, 127);
        campo1.Margin = new Padding(3, 2, 3, 2);
        campo1.MaxLength = 200;
        campo1.Name = "campo1";
        campo1.Size = new Size(250, 23);
        campo1.TabIndex = 0;
        // 
        // lblCampo2
        // 
        lblCampo2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo2.Location = new Point(430, 128);
        lblCampo2.Name = "lblCampo2";
        lblCampo2.Size = new Size(127, 19);
        lblCampo2.TabIndex = 0;
        lblCampo2.Text = "Ciudad:";
        lblCampo2.TextAlign = ContentAlignment.TopRight;
        // 
        // campo2
        // 
        campo2.Enabled = false;
        campo2.Location = new Point(563, 127);
        campo2.Margin = new Padding(3, 2, 3, 2);
        campo2.MaxLength = 200;
        campo2.Name = "campo2";
        campo2.Size = new Size(250, 23);
        campo2.TabIndex = 0;
        // 
        // lblCampo3
        // 
        lblCampo3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCampo3.Location = new Point(24, 169);
        lblCampo3.Name = "lblCampo3";
        lblCampo3.Size = new Size(127, 19);
        lblCampo3.TabIndex = 0;
        lblCampo3.Text = "Activo:";
        lblCampo3.TextAlign = ContentAlignment.TopRight;
        lblCampo3.Click += lblCampo3_Click;
        // 
        // campo3
        // 
        campo3.DropDownStyle = ComboBoxStyle.DropDownList;
        campo3.Enabled = false;
        campo3.Location = new Point(154, 169);
        campo3.Margin = new Padding(3, 2, 3, 2);
        campo3.Name = "campo3";
        campo3.Size = new Size(250, 23);
        campo3.TabIndex = 0;
        // 
        // btnGuardar
        // 
        btnGuardar.BackColor = Color.HotPink;
        btnGuardar.Enabled = false;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnGuardar.ForeColor = Color.Transparent;
        btnGuardar.Location = new Point(24, 276);
        btnGuardar.Margin = new Padding(3, 2, 3, 2);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(206, 32);
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
        btnRegresar.Location = new Point(694, 276);
        btnRegresar.Margin = new Padding(3, 2, 3, 2);
        btnRegresar.Name = "btnRegresar";
        btnRegresar.Size = new Size(122, 32);
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
        dgvDatos.Location = new Point(24, 326);
        dgvDatos.Margin = new Padding(3, 2, 3, 2);
        dgvDatos.MultiSelect = false;
        dgvDatos.Name = "dgvDatos";
        dgvDatos.ReadOnly = true;
        dgvDatos.RowHeadersWidth = 62;
        dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvDatos.Size = new Size(792, 135);
        dgvDatos.TabIndex = 0;
        // 
        // colCampo1
        // 
        colCampo1.HeaderText = "Nombre";
        colCampo1.MinimumWidth = 8;
        colCampo1.Name = "colCampo1";
        colCampo1.ReadOnly = true;
        // 
        // colCampo2
        // 
        colCampo2.HeaderText = "Ciudad";
        colCampo2.MinimumWidth = 8;
        colCampo2.Name = "colCampo2";
        colCampo2.ReadOnly = true;
        // 
        // colCampo3
        // 
        colCampo3.HeaderText = "Activo";
        colCampo3.MinimumWidth = 8;
        colCampo3.Name = "colCampo3";
        colCampo3.ReadOnly = true;
        // 
        // FrmEquipos
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LavenderBlush;
        ClientSize = new Size(848, 491);
        Controls.Add(lblTitulo);
        Controls.Add(lblDescripcion);
        Controls.Add(lblCampo1);
        Controls.Add(campo1);
        Controls.Add(lblCampo2);
        Controls.Add(campo2);
        Controls.Add(lblCampo3);
        Controls.Add(campo3);
        Controls.Add(btnGuardar);
        Controls.Add(btnRegresar);
        Controls.Add(dgvDatos);
        Margin = new Padding(3, 2, 3, 2);
        MinimumSize = new Size(864, 529);
        Name = "FrmEquipos";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Equipos";
        ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }
}
