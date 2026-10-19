namespace TemplateCSharp.Forms;

// Diseño visual del primer avance. La lógica SQL se implementará después.
// No crea registros todavía ni sustituye los repositorios del proyecto.
public partial class FrmReporteOcupacion : Form
{
    public FrmReporteOcupacion()
    {
        InitializeComponent();
        btnRegresar.Click += (_, _) => Close();
    }

    private void lblTitulo_Click(object sender, EventArgs e)
    {

    }
}
