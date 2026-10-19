using System.Drawing;
using System.Windows.Forms;

namespace TemplateCSharp.Forms;

// Interfaz visual de FrmAcceso. Visual Studio puede editarla desde "Ver diseñador".
// Cuando cambies controles visualmente, Visual Studio actualizará este archivo.
partial class FrmAcceso
{
    private System.ComponentModel.IContainer? components = null;

    private Label lblTitulo = null!;
    private Label lblSubtitulo = null!;
    private Label lblCorreo = null!;
    private Label lblContrasena = null!;
    private TextBox txtCorreo = null!;
    private TextBox txtContrasena = null!;
    private Button btnEntrar = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblSubtitulo = new Label();
        lblCorreo = new Label();
        lblContrasena = new Label();
        txtCorreo = new TextBox();
        txtContrasena = new TextBox();
        btnEntrar = new Button();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.BackColor = Color.Transparent;
        lblTitulo.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.DimGray;
        lblTitulo.Location = new Point(50, 33);
        lblTitulo.Margin = new Padding(4, 0, 4, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(550, 57);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "SISTEMA DE BOLETOS";
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblSubtitulo
        // 
        lblSubtitulo.Font = new Font("Segoe UI", 10F);
        lblSubtitulo.ForeColor = Color.Gray;
        lblSubtitulo.Location = new Point(74, 92);
        lblSubtitulo.Margin = new Padding(4, 0, 4, 0);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Size = new Size(500, 33);
        lblSubtitulo.TabIndex = 1;
        lblSubtitulo.Text = "Acceso para personal autorizado";
        lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblCorreo
        // 
        lblCorreo.AutoSize = true;
        lblCorreo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCorreo.Location = new Point(81, 153);
        lblCorreo.Margin = new Padding(4, 0, 4, 0);
        lblCorreo.Name = "lblCorreo";
        lblCorreo.Size = new Size(169, 25);
        lblCorreo.TabIndex = 2;
        lblCorreo.Text = "Correo electrónico";
        // 
        // lblContrasena
        // 
        lblContrasena.AutoSize = true;
        lblContrasena.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblContrasena.Location = new Point(81, 247);
        lblContrasena.Margin = new Padding(4, 0, 4, 0);
        lblContrasena.Name = "lblContrasena";
        lblContrasena.Size = new Size(108, 25);
        lblContrasena.TabIndex = 3;
        lblContrasena.Text = "Contraseña";
        // 
        // txtCorreo
        // 
        txtCorreo.Location = new Point(81, 187);
        txtCorreo.Margin = new Padding(4, 3, 4, 3);
        txtCorreo.MaxLength = 100;
        txtCorreo.Name = "txtCorreo";
        txtCorreo.Size = new Size(487, 31);
        txtCorreo.TabIndex = 0;
        // 
        // txtContrasena
        // 
        txtContrasena.Location = new Point(81, 278);
        txtContrasena.Margin = new Padding(4, 3, 4, 3);
        txtContrasena.MaxLength = 255;
        txtContrasena.Name = "txtContrasena";
        txtContrasena.Size = new Size(487, 31);
        txtContrasena.TabIndex = 1;
        txtContrasena.UseSystemPasswordChar = true;
        // 
        // btnEntrar
        // 
        btnEntrar.BackColor = Color.HotPink;
        btnEntrar.FlatStyle = FlatStyle.Flat;
        btnEntrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnEntrar.ForeColor = Color.White;
        btnEntrar.Location = new Point(200, 353);
        btnEntrar.Margin = new Padding(4, 3, 4, 3);
        btnEntrar.Name = "btnEntrar";
        btnEntrar.Size = new Size(250, 57);
        btnEntrar.TabIndex = 2;
        btnEntrar.Text = "Iniciar sesión";
        btnEntrar.UseVisualStyleBackColor = false;
        btnEntrar.Click += btnEntrar_Click;
        // 
        // FrmAcceso
        // 
        AcceptButton = btnEntrar;
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.LavenderBlush;
        ClientSize = new Size(650, 463);
        Controls.Add(lblTitulo);
        Controls.Add(lblSubtitulo);
        Controls.Add(lblCorreo);
        Controls.Add(txtCorreo);
        Controls.Add(lblContrasena);
        Controls.Add(txtContrasena);
        Controls.Add(btnEntrar);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(4, 3, 4, 3);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmAcceso";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Sistema de boletos - Iniciar sesión";
        ResumeLayout(false);
        PerformLayout();
    }
}
