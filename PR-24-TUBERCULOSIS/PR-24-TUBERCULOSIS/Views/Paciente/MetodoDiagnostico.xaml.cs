namespace PR_24_TUBERCULOSIS.Views.Paciente;
using System;
using System.Data;
using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;	
public partial class MetodoDiagnostico : ContentPage
{
    private int pacienteId;
    private int pesoInicial;
    public MetodoDiagnostico(int idPaciente)
	{
		InitializeComponent();
        pacienteId = idPaciente;
        CargarDatosPaciente(pacienteId);
    }
    private async void CargarDatosPaciente(int idPaciente)
    {
        // Aquí puedes cargar los datos del paciente usando el ID proporcionado
        // Por ejemplo, obtener el peso inicial del paciente desde la base de datos
        string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";

        using (var conn = new MySqlConnection(connectionString))
        {
            await conn.OpenAsync();
            string sql = "SELECT pesoInicial FROM paciente WHERE idPaciente = @idPaciente";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        pesoInicial = reader.GetInt32("pesoInicial");
                        // Asigna el valor de pesoInicial a algún control en tu UI si es necesario
                    }
                }
            }
        }
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await InsertarDatosAsync();
        await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPacientes() }));
    }
    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPreRegistro() }));
    }
    private async Task InsertarDatosAsync()
    {
        string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";
        using (var conn = new MySqlConnection(connectionString))
        {
            await conn.OpenAsync();
            var transaction = await conn.BeginTransactionAsync();
            try
            {
                string sqlUpdateRol = "UPDATE persona SET rol = @nuevoRol WHERE idPersona = @Persona_idPersona";
                using (var cmdUpdateRol = new MySqlCommand(sqlUpdateRol, conn, transaction))
                {
                    cmdUpdateRol.Parameters.AddWithValue("@nuevoRol", "paciente");
                    cmdUpdateRol.Parameters.AddWithValue("@Persona_idPersona", pacienteId);
                    await cmdUpdateRol.ExecuteNonQueryAsync();
                }

                string sqlInsert = @"INSERT INTO diagnostico (baciloscopiaMuestra1, cultivo, genExpert, fechaRegistro, pesoInicial, Persona_idPersona) 
                                 VALUES (@baciloscopiaMuestra1, @cultivo, @genExpert, @fechaRegistro, @pesoInicial, @Persona_idPersona)";
                using (var cmdInsert = new MySqlCommand(sqlInsert, conn, transaction))
                {
                    cmdInsert.Parameters.AddWithValue("@baciloscopiaMuestra1", BaciloscopiaPicker.SelectedItem?.ToString());
                    cmdInsert.Parameters.AddWithValue("@cultivo", CultivoPicker.SelectedItem?.ToString());
                    cmdInsert.Parameters.AddWithValue("@genExpert", GenexpertPicker.SelectedItem?.ToString());
                    cmdInsert.Parameters.AddWithValue("@fechaRegistro", DateTime.Now);
                    cmdInsert.Parameters.AddWithValue("@pesoInicial", pesoInicial);
                    cmdInsert.Parameters.AddWithValue("@Persona_idPersona", pacienteId);

                    await cmdInsert.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
                await DisplayAlert("Éxito", "Diagnóstico y actualización de rol registrados correctamente.", "OK");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await DisplayAlert("Error", $"Error al registrar el diagnóstico o actualizar el rol: {ex.Message}", "OK");
            }
        }
    }


}