using Microsoft.Maui.Controls;
using PR_24_TUBERCULOSIS.Views;
using System;

namespace PR_24_TUBERCULOSIS
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            
        }

        private bool CamposEstanLlenos()
        {
            if (string.IsNullOrWhiteSpace(UsuarioEntry.Text) || string.IsNullOrWhiteSpace(Contrase�aEntry.Text))
            {
                return false;
            }

            return true;
        }

        private async void IniciarSesion_Clicked(object sender, EventArgs e)
        {
            if (CamposEstanLlenos())
            {
               
                await Navigation.PushAsync(new LoginPage()); 
            }
            else
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos", "Aceptar");
            }
        }


        private void OlvidasteContrase�a_Tapped(object sender, EventArgs e)
        {
            
            DisplayAlert("Recuperar Contrase�a", "Funci�n no implementada", "Aceptar");
        }
    }
}
