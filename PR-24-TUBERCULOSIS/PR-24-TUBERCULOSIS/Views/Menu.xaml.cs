using Microsoft.Maui.Controls;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Tools;
using PR_24_TUBERCULOSIS.Views;
using PR_24_TUBERCULOSIS.Views.Doctor;
using PR_24_TUBERCULOSIS.Views.Listas;
using PR_24_TUBERCULOSIS.Views.Login;
using PR_24_TUBERCULOSIS.Views.Paciente;
using PR_24_TUBERCULOSIS.Views.ParteMovil;
using PR_24_TUBERCULOSIS.Views.Registrar;
using System;

namespace PR_24_TUBERCULOSIS
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();

            if (SessionManager.rol == "administrador")
            {
                RegistrarDoctor.IsVisible = true;
                ListaDoctores.IsVisible = true;
                RegistrarPaciente.IsVisible = true;
                ListaPacientes.IsVisible = true;
                ListaPacientesPreRegistro.IsVisible = true;
                GeneradorQr.IsVisible = false;
            }


            if (SessionManager.rol == "doctor")
            {
                RegistrarDoctor.IsVisible = false;
                ListaDoctores.IsVisible = false;
                RegistrarPaciente.IsVisible = true;
                ListaPacientes.IsVisible = true;
                ListaPacientesPreRegistro.IsVisible = true;
                GeneradorQr.IsVisible = false;
            }
            else if (SessionManager.rol == "paciente")
            {
                RegistrarDoctor.IsVisible = false;
                ListaDoctores.IsVisible = false;
                RegistrarPaciente.IsVisible = false;
                ListaPacientes.IsVisible = false;
                ListaPacientesPreRegistro.IsVisible = false;
                GeneradorQr.IsVisible = true;
            }

        }

        private async void RegistrarPacientes_Clicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new CrearPaciente());
        }
        private async void Seguimiento_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new RegistroSeguimientoPeso() }));
        }
        private async void SeguimientoList_Clicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new ListaSeguimientoPeso());
        }
        private async void RegistrarDoctor_Clicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new CrearDoctor());
        }
        private async void ListaPacientes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPacientes() }));
        }
        private async void ListaPacientesPreRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPreRegistro() }));
        }
        private async void ListaDoctores_Clicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new ViewDoctor());
        }
        private async void ListaKardexPaciente_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaKardexPaciente() }));
        }
        private async void Actividades_Clicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new MenuActividades());
        }
        private async void CambiarContraseña_Clicked(object sender, EventArgs e)
        {
            // Aquí puedes navegar a la página de recuperación de contraseña
            await Navigation.PushAsync(new CambiarContra(SessionManager.UserId));
        }
        private async void Personal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VistaPersonal());
        }
        private async void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            // Limpiar los datos de SessionManager
            SessionManager.UserId = 0;
            SessionManager.rol = null;

            // Animación de desvanecimiento al salir de la página actual
            await AnimVentanas.FadeOut(this, 250);
            await Navigation.PopToRootAsync();

            // Animación de desvanecimiento al entrar en la página de inicio de sesión
            await AnimVentanas.FadeIn(new LoginPage(), 250);
        }

        private async void GeneradorQr_Clicked(object sender, EventArgs e)
        {
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new QrGenerador());
        }
    }
}
