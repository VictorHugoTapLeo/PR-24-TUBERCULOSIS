namespace PR_24_TUBERCULOSIS.Views;
using PR_24_TUBERCULOSIS.Implementacion;
using Microsoft.Maui.Controls;
using System.Data;
using PR_24_TUBERCULOSIS;
using PR_24_TUBERCULOSIS.Views.Login;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Views;
using System;


public partial class LoginPage : ContentPage
{
    PersonaImpl persona;
    
	public LoginPage()
	{
		InitializeComponent();
        UsuarioEntry.Text = string.Empty;
        ContrasenaEntry.Text = string.Empty;
	}



    //private async void Ingresar_Clicked(object sender, EventArgs e)
    //{

    //    await Navigation.PushAsync(new VistaPersonal());
    //}

    private async void Ingresar_Clicked_1(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(UsuarioEntry.Text) && !string.IsNullOrEmpty(ContrasenaEntry.Text))
        {
            lblError.Text = "Ingrese un usuario";
            return;
        }

        if (!string.IsNullOrEmpty(UsuarioEntry.Text) && string.IsNullOrEmpty(ContrasenaEntry.Text))
        {
            lblError.Text = "Ingrese una contraseña";
            return;
        }

        if (string.IsNullOrEmpty(UsuarioEntry.Text) && string.IsNullOrEmpty(ContrasenaEntry.Text))
        {
            lblError.Text = "Llene los campos";
            return;
        }


        persona = new PersonaImpl();
            DataTable dt = persona.Login(UsuarioEntry.Text, ContrasenaEntry.Text);

            if (dt.Rows.Count > 0)
            {
            //ConfirmUser(dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString());
            SessionManager.UserId = int.Parse(dt.Rows[0][0].ToString());
            SessionManager.rol = dt.Rows[0][3].ToString();
            SessionManager.primerInicioSesion = Convert.ToByte(dt.Rows[0][4]);
            SessionManager.name = dt.Rows[0][5].ToString();
            SessionManager.Lastname = dt.Rows[0][6].ToString();

            if (SessionManager.rol == "preregistrado")
            {
                lblError.Text = "Complete su Pre Registro antes de Ingresar";
                return;
            }

            if (SessionManager.primerInicioSesion == 1)
            {
              await Navigation.PushAsync(new Menu());
            }
            else
            {
                await Navigation.PushAsync(new CambiarContra(SessionManager.UserId));
            }
            }
            else
            {
                lblError.Text = "Usuario o Contraseña Incorrecta";
            }
        }
    
            private async void OlvidasteContrasena_Clicked(object sender, EventArgs e)
            {
                // Aquí puedes navegar a la página de recuperación de contraseña
                await Navigation.PushAsync(new RecuperarContrasena());
            }
}

