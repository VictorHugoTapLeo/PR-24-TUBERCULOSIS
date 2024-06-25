namespace PR_24_TUBERCULOSIS.Views.Paciente;
using MySql.Data.MySqlClient;
using PR_24_TUBERCULOSIS.Implementacion;

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
            await DisplayAlert("Error", "Por favor, seleccione una condici�n.", "OK");
            return;
        }

        try
        {
            var baseImpl = new BaseImpl(); // Crear una instancia de la clase BaseImpl

            using (var conn = new MySqlConnection(baseImpl.connectionString))
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

            await DisplayAlert("�xito", "Condici�n registrada correctamente.", "OK");
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new MenuActividades());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error al registrar la condici�n: {ex.Message}", "OK");
        }
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new MenuActividades());
    }
	private bool EsBaciloscopiaValida(out string campoInvalido)
	{
		campoInvalido = string.Empty;

		// Verificar si se ha seleccionado una opci�n v�lida en el Picker de Baciloscopia
		if (ControlEgresoPicker.SelectedIndex == -1)
		{
			campoInvalido = "Debe seleccionar una opci�n para Baciloscopia.";
			return false;
		}

		return true;
	}
	private bool CamposSonValidos(out string campoInvalido)
	{
		campoInvalido = string.Empty;

		// Validar Baciloscopia
		if (!EsBaciloscopiaValida(out campoInvalido))
		{
			return false;
		}
		return true;
	}

}