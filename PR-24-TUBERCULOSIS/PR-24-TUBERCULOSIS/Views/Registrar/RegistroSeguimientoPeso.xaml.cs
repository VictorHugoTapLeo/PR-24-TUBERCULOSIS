using Microsoft.Maui;
using MySql.Data.MySqlClient;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Views.Listas;
using System.Data;
using System.Xml.Linq;

namespace PR_24_TUBERCULOSIS.Views.Registrar;

public partial class RegistroSeguimientoPeso : ContentView
{
    SeguimientoPesoImpl implSeguimiento;
    SeguimientoPeso t;
    public RegistroSeguimientoPeso()
	{
        InitializeComponent();
        implSeguimiento = new SeguimientoPesoImpl();
    }

    private async void OnRegistrarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtPeso.Text))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Complete Todos los Campos", "OK");
            return;
        }
        t = new SeguimientoPeso(byte.Parse(txtPeso.Text),AtributosPaciente.UserId);
        implSeguimiento = new SeguimientoPesoImpl();
        try
        {
            int n = implSeguimiento.Insert(t);
            if (n > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Éxito", "Registro Insertado", "OK");
                var navigation = Application.Current.MainPage.Navigation;
                await navigation.PushAsync(new ListaSeguimientoPeso());
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