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
            string password = GenerarContraseņa(8);

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
                lblError.Text = "Error al mandar la contraseņa al correo";
            }

        }
        catch (Exception)
        {
            lblError.Text = "Complete los Campos";
            throw;
        }

    }
    public static string GenerarContraseņa(int longitud)
    {
        const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();

        var contraseņa = new string(Enumerable.Repeat(caracteresPermitidos, longitud)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return contraseņa;
    }
}