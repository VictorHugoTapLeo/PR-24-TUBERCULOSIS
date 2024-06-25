namespace PR_24_TUBERCULOSIS.Views.ParteMovil;
using MySql.Data.MySqlClient;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using QRCoder;
using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
public partial class QrGenerador : ContentPage
{
	public QrGenerador()
	{
		InitializeComponent();
        // Llama al método para generar el QR cuando la página se carga
        GenerarQr_Clicked(null, EventArgs.Empty);
        NombrePacienteLabel.Text = ("Usuario: " + SessionManager.name + " " + SessionManager.Lastname);
    }
    private async void GenerarQr_Clicked(object sender, EventArgs e)
    {
        try
        {
            var baseImpl = new BaseImpl(); // Crear una instancia de la clase BaseImpl

            using (var conn = new MySqlConnection(baseImpl.connectionString))
            {
                await conn.OpenAsync();

                // Actualiza la consulta SQL para usar parámetros
                string sql = @"SELECT persona.primerNombre, persona.primerApellido, persona.carnetIdentidad, paciente.fechaNacimiento, persona.numeroCelular, paciente.numAuxiliar1,
                                          (SELECT tipoTuberculosis FROM tuberculosis.cardex WHERE Persona_idPersona = @idPersona AND (SELECT MIN(idCardex))LIMIT 1) AS 'Tipo Tuberculosis',
                                          (SELECT fechaCreacion FROM tuberculosis.cardex WHERE Persona_idPersona = @idPersona AND (SELECT MIN(idCardex))LIMIT 1) AS 'Fecha Inicio',
                                          (SELECT CONCAT(primerNombre,' ',primerApellido) FROM tuberculosis.persona WHERE idPersona = 
			                       (SELECT diagnosticadoPor FROM tuberculosis.cardex WHERE idPersona = Persona_idPersona LIMIT 1)) AS 'Diagnosticado Por'
                                   FROM tuberculosis.persona
                                   INNER JOIN tuberculosis.paciente ON persona.idPersona = paciente.idPaciente
                                   WHERE persona.idPersona = @idPersona";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    // Ajusta el ID de persona según sea necesario
                    cmd.Parameters.AddWithValue("@idPersona", ObtenerIdPersona());
                    

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            string primerNombre = reader.GetString("primerNombre");
                            string primerApellido = reader.GetString("primerApellido");
                            string carnetIdentidad = reader.GetString("carnetIdentidad");
                            string fechaNacimiento = reader.GetDateTime("fechaNacimiento").ToString("yyyy-MM-dd");
                            int numeroCelular = reader.GetInt32("numeroCelular");
                            int numAuxiliar1 = reader.GetInt32("numAuxiliar1");

                            // Nuevos campos de la tabla cardex
                            string tipoTuberculosis = reader.GetString("Tipo Tuberculosis");
                            string fechaInicio = reader.GetDateTime("Fecha Inicio").ToString("yyyy-MM-dd");
                            string diagnosticadoPor = reader.GetString("Diagnosticado Por");

                            // Construir el texto a codificar en el QR
                            string qrText = $"Nombre: {primerNombre} {primerApellido}\n" +
                                            $"Carnet de Identidad: {carnetIdentidad}\n" +
                                            $"Fecha de Nacimiento: {fechaNacimiento}\n" +
                                            $"Numero de Celular: {numeroCelular}\n" +
                                            $"Numero Auxiliar 1: {numAuxiliar1}\n" +
                                            $"Tipo de Tuberculosis: {tipoTuberculosis}\n" +
                                            $"Fecha de Inicio: {fechaInicio}\n" +
                                            $"Diagnosticado Por: {diagnosticadoPor}";

                            // Generar el código QR
                            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.L);
                            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
                            byte[] qrCodeBytes = qrCode.GetGraphic(20);
                            QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));
                        }
                        else
                        {
                            await DisplayAlert("Error", "No se encontraron datos para generar el código QR.", "OK");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al generar el código QR: {ex.Message}", "OK");
        }
    }

    private int ObtenerIdPersona()
    {
        //return 15;
        //este es para id Sesion solo crea qr de pacientes
        return SessionManager.UserId;
    }

    private async void Volver_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new Menu());
    }
}

