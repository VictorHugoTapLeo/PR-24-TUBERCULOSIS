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
            string password = GenerarContraseña(8);

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
                lblError.Text = "Error al mandar la contraseña al correo";
            }

        }
        catch (Exception)
        {
            lblError.Text = "Complete los Campos";
            throw;
        }

    }
    public static string GenerarContraseña(int longitud)
    {
        const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();

        var contraseña = new string(Enumerable.Repeat(caracteresPermitidos, longitud)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return contraseña;
    }
}