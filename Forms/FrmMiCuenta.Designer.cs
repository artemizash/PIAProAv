using System.Drawing;
using System.Windows.Forms;

namespace TemplateCSharp.Forms;

// Edita estos controles con clic derecho en FrmMiCuenta.cs > Ver diseñador.
partial class FrmMiCuenta
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lblInstruccion = null!;
    private Label lblNombre = null!;
    private Label lblNombreValor = null!;
    private Label lblCorreo = null!;
    private Label lblCorreoValor = null!;
    private Label lblRol = null!;
    private Label lblRolValor = null!;
    private Label lblActual = null!;
    private TextBox txtActual = null!;
    private Label lblNueva = null!;
    private TextBox txtNueva = null!;
    private Label lblConfirmar = null!;
    private TextBox txtConfirmar = null!;
    private Label lblReglas = null!;
    private Button btnGuardar = null!;
    private Button btnCerrar = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblInstruccion = new Label();
        lblNombre = new Label();
        lblNombreValor = new Label();
        lblCorreo = new Label();
        lblCorreoValor = new Label();
        lblRol = new Label();
        lblRolValor = new Label();
        lblActual = new Label();
        txtActual = new TextBox();
        lblNueva = new Label();
        txtNueva = new TextBox();
        lblConfirmar = new Label();
        txtConfirmar = new TextBox();
        lblReglas = new Label();
        btnGuardar = new Button();
        btnCerrar = new Button();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.DimGray;
        lblTitulo.Location = new Point(40, 28);
        lblTitulo.Margin = new Padding(4, 0, 4, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(650, 54);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "MI CUENTA";
        // 
        // lblInstruccion
        // 
        lblInstruccion.ForeColor = Color.Gray;
        lblInstruccion.Location = new Point(42, 90);
        lblInstruccion.Margin = new Padding(4, 0, 4, 0);
        lblInstruccion.Name = "lblInstruccion";
        lblInstruccion.Size = new Size(662, 50);
        lblInstruccion.TabIndex = 1;
        lblInstruccion.Text = "Consulta tus datos y cambia tu contraseña cuando lo necesites.";
        // 
        // lblNombre
        // 
        lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNombre.Location = new Point(42, 161);
        lblNombre.Margin = new Padding(4, 0, 4, 0);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(181, 32);
        lblNombre.TabIndex = 2;
        lblNombre.Text = "Nombre completo:";
        // 
        // lblNombreValor
        // 
        lblNombreValor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblNombreValor.Location = new Point(238, 161);
        lblNombreValor.Margin = new Padding(4, 0, 4, 0);
        lblNombreValor.Name = "lblNombreValor";
        lblNombreValor.Size = new Size(462, 32);
        lblNombreValor.TabIndex = 3;
        lblNombreValor.Text = "Nombre del empleado";
        // 
        // lblCorreo
        // 
        lblCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCorreo.Location = new Point(42, 206);
        lblCorreo.Margin = new Padding(4, 0, 4, 0);
        lblCorreo.Name = "lblCorreo";
        lblCorreo.Size = new Size(181, 32);
        lblCorreo.TabIndex = 4;
        lblCorreo.Text = "Correo:";
        // 
        // lblCorreoValor
        // 
        lblCorreoValor.Location = new Point(238, 206);
        lblCorreoValor.Margin = new Padding(4, 0, 4, 0);
        lblCorreoValor.Name = "lblCorreoValor";
        lblCorreoValor.Size = new Size(462, 32);
        lblCorreoValor.TabIndex = 5;
        lblCorreoValor.Text = "correo@ejemplo.com";
        // 
        // lblRol
        // 
        lblRol.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblRol.Location = new Point(42, 251);
        lblRol.Margin = new Padding(4, 0, 4, 0);
        lblRol.Name = "lblRol";
        lblRol.Size = new Size(181, 32);
        lblRol.TabIndex = 6;
        lblRol.Text = "Rol:";
        // 
        // lblRolValor
        // 
        lblRolValor.Location = new Point(238, 251);
        lblRolValor.Margin = new Padding(4, 0, 4, 0);
        lblRolValor.Name = "lblRolValor";
        lblRolValor.Size = new Size(462, 32);
        lblRolValor.TabIndex = 7;
        lblRolValor.Text = "Operativo";
        // 
        // lblActual
        // 
        lblActual.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblActual.Location = new Point(42, 324);
        lblActual.Margin = new Padding(4, 0, 4, 0);
        lblActual.Name = "lblActual";
        lblActual.Size = new Size(200, 34);
        lblActual.TabIndex = 8;
        lblActual.Text = "Contraseña actual:";
        lblActual.TextAlign = ContentAlignment.TopRight;
        // 
        // txtActual
        // 
        txtActual.Location = new Point(260, 324);
        txtActual.Margin = new Padding(4, 4, 4, 4);
        txtActual.MaxLength = 255;
        txtActual.Name = "txtActual";
        txtActual.Size = new Size(422, 31);
        txtActual.TabIndex = 0;
        txtActual.UseSystemPasswordChar = true;
        // 
        // lblNueva
        // 
        lblNueva.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblNueva.Location = new Point(42, 381);
        lblNueva.Margin = new Padding(4, 0, 4, 0);
        lblNueva.Name = "lblNueva";
        lblNueva.Size = new Size(200, 34);
        lblNueva.TabIndex = 9;
        lblNueva.Text = "Nueva contraseña:";
        lblNueva.TextAlign = ContentAlignment.TopRight;
        // 
        // txtNueva
        // 
        txtNueva.Location = new Point(260, 381);
        txtNueva.Margin = new Padding(4, 4, 4, 4);
        txtNueva.MaxLength = 255;
        txtNueva.Name = "txtNueva";
        txtNueva.Size = new Size(422, 31);
        txtNueva.TabIndex = 1;
        txtNueva.UseSystemPasswordChar = true;
        // 
        // lblConfirmar
        // 
        lblConfirmar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblConfirmar.Location = new Point(42, 439);
        lblConfirmar.Margin = new Padding(4, 0, 4, 0);
        lblConfirmar.Name = "lblConfirmar";
        lblConfirmar.Size = new Size(212, 34);
        lblConfirmar.TabIndex = 10;
        lblConfirmar.Text = "Confirmar contraseña:";
        lblConfirmar.TextAlign = ContentAlignment.TopRight;
        // 
        // txtConfirmar
        // 
        txtConfirmar.Location = new Point(260, 439);
        txtConfirmar.Margin = new Padding(4, 4, 4, 4);
        txtConfirmar.MaxLength = 255;
        txtConfirmar.Name = "txtConfirmar";
        txtConfirmar.Size = new Size(422, 31);
        txtConfirmar.TabIndex = 2;
        txtConfirmar.UseSystemPasswordChar = true;
        // 
        // lblReglas
        // 
        lblReglas.ForeColor = Color.DimGray;
        lblReglas.Location = new Point(42, 500);
        lblReglas.Margin = new Padding(4, 0, 4, 0);
        lblReglas.Name = "lblReglas";
        lblReglas.Size = new Size(660, 52);
        lblReglas.TabIndex = 11;
        lblReglas.Text = "Mínimo 8 caracteres, una mayúscula, una minúscula y un símbolo.\nNo se permiten las últimas tres contraseñas.";
        // 
        // btnGuardar
        // 
        btnGuardar.BackColor = Color.MediumVioletRed;
        btnGuardar.FlatStyle = FlatStyle.Flat;
        btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnGuardar.ForeColor = Color.Transparent;
        btnGuardar.Location = new Point(160, 585);
        btnGuardar.Margin = new Padding(4, 4, 4, 4);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(238, 58);
        btnGuardar.TabIndex = 3;
        btnGuardar.Text = "Guardar contraseña";
        btnGuardar.UseVisualStyleBackColor = false;
        btnGuardar.Click += btnGuardar_Click;
        // 
        // btnCerrar
        // 
        btnCerrar.BackColor = Color.HotPink;
        btnCerrar.FlatStyle = FlatStyle.Flat;
        btnCerrar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnCerrar.ForeColor = Color.Transparent;
        btnCerrar.Location = new Point(415, 585);
        btnCerrar.Margin = new Padding(4, 4, 4, 4);
        btnCerrar.Name = "btnCerrar";
        btnCerrar.Size = new Size(181, 58);
        btnCerrar.TabIndex = 4;
        btnCerrar.Text = "Cerrar";
        btnCerrar.UseVisualStyleBackColor = false;
        btnCerrar.Click += btnCerrar_Click;
        // 
        // FrmMiCuenta
        // 
        AcceptButton = btnGuardar;
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LavenderBlush;
        ClientSize = new Size(750, 688);
        Controls.Add(lblTitulo);
        Controls.Add(lblInstruccion);
        Controls.Add(lblNombre);
        Controls.Add(lblNombreValor);
        Controls.Add(lblCorreo);
        Controls.Add(lblCorreoValor);
        Controls.Add(lblRol);
        Controls.Add(lblRolValor);
        Controls.Add(lblActual);
        Controls.Add(txtActual);
        Controls.Add(lblNueva);
        Controls.Add(txtNueva);
        Controls.Add(lblConfirmar);
        Controls.Add(txtConfirmar);
        Controls.Add(lblReglas);
        Controls.Add(btnGuardar);
        Controls.Add(btnCerrar);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(4, 4, 4, 4);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmMiCuenta";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Mi cuenta - Sistema de boletos";
        ResumeLayout(false);
        PerformLayout();
    }
}
