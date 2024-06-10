namespace PR_24_TUBERCULOSIS.Views.Kardex;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using System.Data;
using System.IO.Pipelines;
using System.Xml.Linq;
public partial class DetallesKardex : ContentPage
{
    KardexImpl kardex;
    public DetallesKardex()
    {
        InitializeComponent();
        kardex = new KardexImpl();
        DataTable dt = kardex.Kardex(AtributosPaciente.UserId, AtributosPaciente.CardexId);
        if (dt.Rows.Count > 0)
        {
            txtTipoTuberculosis.Text = dt.Rows[0][0].ToString();
            txtSaturacion.Text = dt.Rows[0][1].ToString();
            txtFrecuenciaCardiaca.Text = dt.Rows[0][2].ToString();
            txtfrecuenciaRespiratoria.Text = dt.Rows[0][3].ToString();
            txtDiagnosticadoPor.Text = dt.Rows[0][4].ToString();
            txtFechaRegistro.Text = dt.Rows[0][5].ToString();
            txtPaciente.Text = AtributosPaciente.Name+" "+AtributosPaciente.LastName;
            txtDocificacionMedicamentos.Text = dt.Rows[0][6].ToString();
            txtNumeroDosis.Text = dt.Rows[0][7].ToString();
            txtCultivo.Text = dt.Rows[0][8].ToString();
            txtBasiloscopia.Text = dt.Rows[0][9].ToString();
        }

    }
    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ViewKardex());
    }
}