namespace TemplateCSharp.Forms;

// Diseño visual del primer avance. La lógica SQL se implementará después.
// No crea registros todavía ni sustituye los repositorios del proyecto.
public partial class FrmEquipos : Form
{
    public FrmEquipos()
    {
        InitializeComponent();
        btnRegresar.Click += (_, _) => Close();
    }

    private void lblCampo3_Click(object sender, EventArgs e)
    {

    }
}
