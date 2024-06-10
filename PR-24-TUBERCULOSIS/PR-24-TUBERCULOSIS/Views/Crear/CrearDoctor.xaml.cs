namespace PR_24_TUBERCULOSIS.Views;

//using Microsoft.Web.WebView2.Core;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Tools;
using PR_24_TUBERCULOSIS.Views.Doctor;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public partial class CrearDoctor : ContentPage
{
    PersonalSalud personalSalud;
    PersonalImpl personalImpl;
    EnvioEmail2 mail;
    public CrearDoctor()
	{
		InitializeComponent();


	}
    private bool EsCorreoValido(string correo)
    {
        if (string.IsNullOrWhiteSpace(correo))
            return false;

        // Expresi�n regular para validar el formato del correo electr�nico
        string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(correo, patronCorreo);
    }


    private bool EsTextoValido(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return false;

        foreach (char c in texto)
        {
            if (!char.IsLetter(c))
                return false;
        }
        return true;
    }

    private bool EsNumeroValido(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
            return false;

        foreach (char c in numero)
        {
            if (!char.IsDigit(c))
                return false;
        }
        return true;
    }
    public bool CheckIsPhone(string phone)
    {
        Regex regex = new Regex("^(4[0-9]{6}|[67][0-9]{7})$");
        return regex.IsMatch(phone);
    }

    private async void btnRegistrar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(PrimerNombreEntry.Text) || !EsTextoValido(PrimerNombreEntry.Text))
        {
            await DisplayAlert("Error", "Por favor ingrese solo letras y no deje espacios vac�os en el nombre.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(PrimerApellidoEntry.Text) || !EsTextoValido(PrimerApellidoEntry.Text))
        {
            await DisplayAlert("Error", "Por favor ingrese solo letras y no deje espacios vac�os en el primer apellido.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(SegundoApellidoEntry.Text) || !EsTextoValido(SegundoApellidoEntry.Text))
        {
            await DisplayAlert("Error", "Por favor ingrese solo letras y no deje espacios vac�os en el segundo apellido.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(CIEntry.Text) || !EsNumeroValido(CIEntry.Text))
        {
            await DisplayAlert("Error", "Por favor ingrese solo n�meros y no deje espacios vac�os en el C.I.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(TelefonoEntry.Text) || !CheckIsPhone(TelefonoEntry.Text))
        {
            await DisplayAlert("Error", "Si el telefono empieza con 4, seguido 6 digitos.\n Si empieza con 7-6, seguido 7 digitos", "OK");
            return;
        }


        if (string.IsNullOrWhiteSpace(CorreoEntry.Text) || !EsCorreoValido(CorreoEntry.Text))
        {
            await DisplayAlert("Error", "Por favor ingrese un correo electr�nico v�lido.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(UsuarioEntry.Text) || !EsTextoValido(UsuarioEntry.Text))
        {
            await DisplayAlert("Error", "Por favor ingrese solo letras y no deje espacios vac�os el usuario.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(CodigoEntry.Text) || !EsTextoValido(CodigoEntry.Text))
        {
            await DisplayAlert("Error", "Por favor ingrese solo letras no deje espacios vac�os en el c�digo de doctor.", "OK");
            return;
        }

        string contra = GenerarContrase�a(8);
        string rol = "doctor";
        // Crear objeto PersonalSalud y realizar la inserci�n en la base de datos
        personalSalud = new PersonalSalud(PrimerNombreEntry.Text, SegundoNombreEntry.Text, PrimerApellidoEntry.Text, SegundoApellidoEntry.Text, CIEntry.Text, int.Parse(TelefonoEntry.Text), UsuarioEntry.Text, contra, CorreoEntry.Text, rol, CodigoEntry.Text);
        personalImpl = new PersonalImpl();
        personalImpl.Insert(personalSalud);

        // Enviar la contrase�a por correo electr�nico
        mail = new EnvioEmail2();
        mail.EnvioGmail(CorreoEntry.Text, UsuarioEntry.Text, contra);

        // Mostrar un mensaje de �xito o realizar otras acciones necesarias
        await DisplayAlert("Registro exitoso", "Se ha enviado la contrase�a por correo electr�nico.", "OK");

        // Limpiar los campos del formulario despu�s de registrar
        LimpiarCampos();

        await Navigation.PushAsync(new ViewDoctor());
    }



    private void LimpiarCampos()
    {
        PrimerNombreEntry.Text = "";
        SegundoNombreEntry.Text = "";
        PrimerApellidoEntry.Text = "";
        SegundoApellidoEntry.Text = "";
        CIEntry.Text = "";
        TelefonoEntry.Text = "";
        UsuarioEntry.Text = "";
        CodigoEntry.Text = "";
        CorreoEntry.Text = "";

    }

    public static string GenerarContrase�a(int longitud)
    {
        const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        var random = new Random();

        var contrase�a = new string(Enumerable.Repeat(caracteresPermitidos, longitud)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return contrase�a;
    }
    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        // Borrar el contenido de todas las casillas
        PrimerNombreEntry.Text = "";
        SegundoNombreEntry.Text = "";
        PrimerApellidoEntry.Text = "";
        SegundoApellidoEntry.Text = "";
        CIEntry.Text = "";
        TelefonoEntry.Text = "";
        UsuarioEntry.Text = "";
        CodigoEntry.Text = "";
        CorreoEntry.Text = "";
        await Navigation.PushAsync(new ViewDoctor());
    }
}

