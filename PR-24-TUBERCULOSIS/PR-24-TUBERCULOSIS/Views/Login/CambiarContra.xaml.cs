namespace PR_24_TUBERCULOSIS.Views.Login;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Interface;
public partial class CambiarContra : ContentPage
{

    int idUsuario;
    PersonaImpl persona;
    public CambiarContra(int idUsuario) // Recibe el ID de usuario como par�metro
    {
        InitializeComponent();
        this.idUsuario = idUsuario;
        
    }

    private async void CambiarContrase�a_Clicked(object sender, EventArgs e)
    {
        try
        {
            persona = new PersonaImpl();

            if (ContrasenaNueva.Text == ConfirContra.Text)
            {
                int row = persona.updatePasswordChange(idUsuario, UusarioEntry.Text, ContrasenaNueva.Text, OldContra.Text);

                if (row > 0)
                {
                    // Cambio de contrase�a exitoso, redirige a otra p�gina
                    await Navigation.PushAsync(new Menu());
                }
                else
                {
                    lblError.Text = "La antigua contrase�a no es correcta. Por favor, int�ntelo de nuevo.";
                }
            }
            else
            {
                lblError.Text = "Las contrase�as no coinciden. Por favor, int�ntelo de nuevo.";
            }
        }
        catch (Exception ex)
        {
            // Maneja la excepci�n apropiadamente, como registrarla o mostrar un mensaje al usuario
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private async void CambiarContrase�a_Clicked_1(object sender, EventArgs e)
    {
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}