namespace PR_24_TUBERCULOSIS.Views.Login;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Interface;
public partial class CambiarContra : ContentPage
{

    int idUsuario;
    PersonaImpl persona;
    public CambiarContra(int idUsuario) // Recibe el ID de usuario como parámetro
    {
        InitializeComponent();
        this.idUsuario = idUsuario;
        
    }

    private async void CambiarContraseña_Clicked(object sender, EventArgs e)
    {
        try
        {
            persona = new PersonaImpl();

            if (ContrasenaNueva.Text == ConfirContra.Text)
            {
                int row = persona.updatePasswordChange(idUsuario, UusarioEntry.Text, ContrasenaNueva.Text, OldContra.Text);

                if (row > 0)
                {
                    // Cambio de contraseña exitoso, redirige a otra página
                    await Navigation.PushAsync(new Menu());
                }
                else
                {
                    lblError.Text = "La antigua contraseña no es correcta. Por favor, inténtelo de nuevo.";
                }
            }
            else
            {
                lblError.Text = "Las contraseñas no coinciden. Por favor, inténtelo de nuevo.";
            }
        }
        catch (Exception ex)
        {
            // Maneja la excepción apropiadamente, como registrarla o mostrar un mensaje al usuario
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private async void CambiarContraseña_Clicked_1(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}