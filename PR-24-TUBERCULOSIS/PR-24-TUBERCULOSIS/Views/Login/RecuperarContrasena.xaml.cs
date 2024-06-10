namespace PR_24_TUBERCULOSIS.Views.Login;
using PR_24_TUBERCULOSIS.Implementacion;
using Microsoft.Maui.ApplicationModel.Communication;
using PR_24_TUBERCULOSIS.Tools;

public partial class RecuperarContrasena : ContentPage
{
    EnvioEmail mail;
    PersonaImpl personalSalud;
    public RecuperarContrasena()
    {
        InitializeComponent();
    }
    private async void Recuperar_Contrasena_Clicked(object sender, EventArgs e)
    {
        try
        {

            mail = new EnvioEmail();
            personalSalud = new PersonaImpl();
            string password = GenerarContrase�a(8);

            if (mail.EnvioGmail(CorreoEntry.Text, UsuarioEntry.Text, password))
            {
                int row = personalSalud.UpdateRecoverPassword(UsuarioEntry.Text, password);
                if (row > 0)
                {

                    await Navigation.PushAsync(new LoginPage());

                }
            }
            else
            {
                lblError.Text = "Error al mandar la contrase�a al correo";
            }

        }
        catch (Exception)
        {
            lblError.Text = "Complete los Campos";
            throw;
        }

    }
    public static string GenerarContrase�a(int longitud)
    {
        const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();

        var contrase�a = new string(Enumerable.Repeat(caracteresPermitidos, longitud)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return contrase�a;
    }
}