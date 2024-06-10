using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using PR_24_TUBERCULOSIS.Views;
using PR_24_TUBERCULOSIS.Views.Paciente;
using PR_24_TUBERCULOSIS.Tools;
namespace PR_24_TUBERCULOSIS.Views;

public partial class CrearPaciente : ContentPage
{
    EnvioEmail2 mail;
    private readonly Dictionary<string, int> GeneroMap = new Dictionary<string, int>
        {
            { "Hombre", 0 },
            { "Mujer", 1 }
        };
    public CrearPaciente()
	{
		InitializeComponent();
	}

    private async void CancelarButton_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new ContentPage { Content = new ListaPaciente() });
    }

    private bool CamposSonValidos(out string campoInvalido)
    {
        // Inicializa el campo inválido como vacío
        campoInvalido = string.Empty;

        // Validar campos de texto

        if (!EsTextoValido(PrimerApellidoEntry.Text))
        {
            campoInvalido = "Primer Apellido";
            return false;
        }
        if (!EsTextoValido(SegundoApellidoEntry.Text))
        {
            campoInvalido = "Segundo Apellido";
            return false;
        }


        if (!EsNumeroCelularValido(numeroCelularEntry.Text))
        {
            campoInvalido = "Número Celular (debe tener 8 dígitos)";
            return false;
        }

        if (!EsNumeroValido(NumAux1Entry.Text))
        {
            campoInvalido = "Número Auxiliar 1";
            return false;
        }
        
        if (!EsNumeroValido(NumAux2Entry.Text))
        {
            campoInvalido = "Número Auxiliar 2";
            return false;
        }
        if (GeneroPicker.SelectedIndex == -1)
        {
            campoInvalido = "Género";
            return false;
        }

        return true;
    }

    private bool EsTextoValido(string texto)
    {
        // Solo permite letras y no debe estar vacío
        return !string.IsNullOrWhiteSpace(texto) && Regex.IsMatch(texto, @"^[a-zA-Z]+$");
    }

    private bool EsNumeroValido(string numero)
    {
        // Debe ser un número entero y no debe estar vacío
        return !string.IsNullOrWhiteSpace(numero) && Regex.IsMatch(numero, @"^\d+$");
    }

    private bool EsNumeroCelularValido(string numeroCelular)
    {
        // El número de celular debe tener exactamente 8 dígitos
        return !string.IsNullOrWhiteSpace(numeroCelular) && Regex.IsMatch(numeroCelular, @"^\d{8}$");
    }

    private bool EsSexoValido(string sexo)
    {
        // El sexo debe ser '1' para masculino o '0' para femenino
        return sexo == "1" || sexo == "0";
    }

    private async Task InsertarDatosAsync()
    {
        string contra = GenerarContraseña(8);
        try
        {
            string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";

            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                using (var transaction = await conn.BeginTransactionAsync())
                {
                    string sqlInsertPersona = @"INSERT INTO persona (primerNombre,segundoNombre, primerApellido,segundoApellido, carnetIdentidad, numeroCelular, usuario, contra, correo, rol) 
                                            VALUES (@primerNombre,@segundoNombre,  @primerApellido,@segundoApellido,@carnetIdentidad, @numeroCelular, @usuario, @contra, @correo, @rol)";
                    var cmdInsertPersona = new MySqlCommand(sqlInsertPersona, conn, transaction);

                    cmdInsertPersona.Parameters.AddWithValue("@primerNombre", PrimerNombreEntry.Text);
                    cmdInsertPersona.Parameters.AddWithValue("@segundoNombre", SegundoNombreEntry.Text);
                    cmdInsertPersona.Parameters.AddWithValue("@primerApellido", PrimerApellidoEntry.Text);
                    cmdInsertPersona.Parameters.AddWithValue("@segundoApellido", SegundoApellidoEntry.Text);
                    cmdInsertPersona.Parameters.AddWithValue("@carnetIdentidad", CarnetIdentidadEntry.Text);
                    cmdInsertPersona.Parameters.AddWithValue("@numeroCelular", numeroCelularEntry.Text);
                    cmdInsertPersona.Parameters.AddWithValue("@usuario", UsuarioEntry.Text);
                    cmdInsertPersona.Parameters.AddWithValue("@contra", contra);
                    cmdInsertPersona.Parameters.AddWithValue("@correo", CorreoEntry.Text);
                    cmdInsertPersona.Parameters.AddWithValue("@rol", "preregistrado");

                    await cmdInsertPersona.ExecuteNonQueryAsync();

                    long idPersona = cmdInsertPersona.LastInsertedId;

                    string sqlInsertPaciente = @"INSERT INTO paciente (idPaciente, latitud, longitud,condicion, fechaNacimiento, ultimaActualizacion, numAuxiliar1, numAuxiliar2,pesoInicial, sexo, direccion) 
                                            VALUES (@idPaciente, @latitud, @longitud,@condicion, @fechaNacimiento, @ultimaActualizacion, @numAuxiliar1, @numAuxiliar2,@pesoInicial, @sexo, @direccion)";
                    var cmdInsertPaciente = new MySqlCommand(sqlInsertPaciente, conn, transaction);

                    cmdInsertPaciente.Parameters.AddWithValue("@idPaciente", idPersona);
                    cmdInsertPaciente.Parameters.AddWithValue("@latitud", double.Parse(LatitudEntry.Text));
                    cmdInsertPaciente.Parameters.AddWithValue("@longitud", double.Parse(LongitudEntry.Text));
                    cmdInsertPaciente.Parameters.AddWithValue("@condicion", CondicionPicker.SelectedItem);
                    cmdInsertPaciente.Parameters.AddWithValue("@fechaNacimiento", FechaNacimientoPicker.Date);
                    cmdInsertPaciente.Parameters.AddWithValue("@ultimaActualizacion", UltimaActualizacionPicker.Date);
                    cmdInsertPaciente.Parameters.AddWithValue("@numAuxiliar1", int.Parse(NumAux1Entry.Text));
                    cmdInsertPaciente.Parameters.AddWithValue("@numAuxiliar2", int.Parse(NumAux2Entry.Text));
                    cmdInsertPaciente.Parameters.AddWithValue("@pesoInicial", "1");
                    string selectedGenero = (string)GeneroPicker.SelectedItem;
                    int sexoValue = GeneroMap[selectedGenero];
                    cmdInsertPaciente.Parameters.AddWithValue("@sexo", sexoValue);
                    cmdInsertPaciente.Parameters.AddWithValue("@direccion", DireccionEntry.Text);

                    await cmdInsertPaciente.ExecuteNonQueryAsync();

                    await transaction.CommitAsync();
                }
            }
            // Enviar la contraseña por correo electrónico
            mail = new EnvioEmail2();
            mail.EnvioGmail(CorreoEntry.Text, UsuarioEntry.Text, contra);

            // Mostrar un mensaje de éxito o realizar otras acciones necesarias
            await DisplayAlert("Registro exitoso", "Se ha enviado la contraseña por correo electrónico.", "OK");

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al registrar el paciente: {ex.Message}", "OK");
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string campoInvalido;
        if (CamposSonValidos(out campoInvalido))
        {
            await InsertarDatosAsync();
            await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPreRegistro() }));
        }
        else
        {
            await DisplayAlert("Error", $"Por favor, complete el campo '{campoInvalido}' correctamente.", "OK");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPacientes() }));
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