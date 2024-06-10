namespace PR_24_TUBERCULOSIS.Views.Kardex;
using Microsoft.Maui;
using MySql.Data.MySqlClient;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using System.Data;
using System.Xml.Linq;
public partial class CrearKardex : ContentPage
{
    KardexImpl implKardex;
    KardexModel t;
    public CrearKardex()
	{
		InitializeComponent();
        implKardex = new KardexImpl();
    }
    private async void OnRegistrarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(DocificacionMedicamentos.Text) || string.IsNullOrWhiteSpace(FrecuenciaCardiaca.Text) ||
            string.IsNullOrWhiteSpace(Cultivo.Text) || string.IsNullOrWhiteSpace(NumeroDosis.Text) ||
            string.IsNullOrWhiteSpace(Basiloscopia.Text) || string.IsNullOrWhiteSpace(Saturacion.Text) ||
            TipoTuberculosis.ToString == null || string.IsNullOrWhiteSpace(FrecuenciaRespiratoria.Text))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Complete Todos los Campos", "OK");
            return;
        }
        t = new KardexModel(TipoTuberculosis.SelectedItem?.ToString(), Saturacion.Text, FrecuenciaCardiaca.Text, FrecuenciaRespiratoria.Text, SessionManager.UserId,
            AtributosPaciente.UserId,DocificacionMedicamentos.Text, NumeroDosis.Text, Cultivo.Text, Basiloscopia.Text);
        implKardex = new KardexImpl();
        try
        {
            int n = implKardex.Insert(t);
            if (n > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Registro Insertado", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo registrar el peso", "OK");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        // Navegar hacia atrás
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}