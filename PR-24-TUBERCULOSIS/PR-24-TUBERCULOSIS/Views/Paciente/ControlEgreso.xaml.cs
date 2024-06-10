namespace PR_24_TUBERCULOSIS.Views.Paciente;
using MySql.Data.MySqlClient;
public partial class ControlEgreso : ContentPage
{
    private int pacienteId = 9;
    public ControlEgreso(int idPaciente)
	{
		InitializeComponent();
        pacienteId = idPaciente;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        string condicion = ControlEgresoPicker.SelectedItem?.ToString();
        if (string.IsNullOrEmpty(condicion))
        {
            await DisplayAlert("Error", "Por favor, seleccione una condición.", "OK");
            return;
        }

        try
        {
            string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";
            using (var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();

                string sqlUpdate = "UPDATE paciente SET condicion = @condicion WHERE idPaciente = @idPaciente";
                using (var cmd = new MySqlCommand(sqlUpdate, conn))
                {
                    cmd.Parameters.AddWithValue("@condicion", condicion);
                    cmd.Parameters.AddWithValue("@idPaciente", pacienteId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            await DisplayAlert("Éxito", "Condición registrada correctamente.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al registrar la condición: {ex.Message}", "OK");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new MenuActividades());
    }
}