namespace TemplateCSharp.Forms;

// Diseño visual del primer avance. La lógica SQL se implementará después.
// No crea registros todavía ni sustituye los repositorios del proyecto.
public partial class FrmHistorialClientes : Form
{
    public FrmHistorialClientes()
    {
        InitializeComponent();
        btnRegresar.Click += (_, _) => Close();
    }
}
