namespace PR_24_TUBERCULOSIS.Views;
using Microsoft.Maui.Controls;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Tools;
using PR_24_TUBERCULOSIS.Views;
using PR_24_TUBERCULOSIS.Views.Doctor;
using PR_24_TUBERCULOSIS.Views.Kardex;
using PR_24_TUBERCULOSIS.Views.Listas;
using PR_24_TUBERCULOSIS.Views.Login;
using PR_24_TUBERCULOSIS.Views.Paciente;
using PR_24_TUBERCULOSIS.Views.Registrar;
using System;

public partial class MenuActividades : ContentPage
{
	public MenuActividades()
	{
		InitializeComponent();
        
        lblActividades.Text = ("Actividades " + AtributosPaciente.Name + " " + AtributosPaciente.LastName);
    }
    private async void Peso_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new RegistroSeguimientoPeso() }));
    }
    private async void RegistroPeso_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new ListaSeguimientoPeso());
    }
    private async void Egreso_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new ControlEgreso(2));
    }
    private async void Volver_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new ViewKardex());
    }

    private async void Transferencia_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new Transferencia.Transferencia());
    }

    private async void Tratamiento_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new ControlTratamiento());
    }

    private async void ListaTratamiento_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new ListaControlTratmiento());
    }
}