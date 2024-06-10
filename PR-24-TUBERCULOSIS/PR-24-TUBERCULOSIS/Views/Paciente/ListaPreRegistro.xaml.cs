namespace PR_24_TUBERCULOSIS.Views.Paciente;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;


public partial class ListaPreRegistro : ContentView
{
    public ObservableCollection<Personas> Pacientes { get; set; }
    public ListaPreRegistro()
	{
		InitializeComponent();
        Pacientes = new ObservableCollection<Personas>();
        PacientesCollectionView.ItemsSource = Pacientes;
        LoadPacientes();
    }
    private async void LoadPacientes()
		{
			await CargarPacientesAsync();
		}
		private async Task CargarPacientesAsync()
		{
			string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";

			using (var conn = new MySqlConnection(connectionString))
			{
				await conn.OpenAsync();

				string sql = "SELECT idPersona, primerNombre, primerApellido FROM persona WHERE estado = 1 AND rol = 'preregistrado'";
				using (var cmd = new MySqlCommand(sql, conn))
				{
					using (var reader = await cmd.ExecuteReaderAsync())
					{
						Pacientes.Clear();
						while (await reader.ReadAsync())
						{
							var paciente = new Personas
							{
								Id = reader.GetInt32("idPersona"),
								Nombre = reader.GetString("primerNombre"),
								Apellido = reader.GetString("primerApellido")
							};
							Pacientes.Add(paciente);
						}
					}
				}
			}


		}



		private async void Button_Clicked_1(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CrearPaciente());
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			// Manejar el evento de clic para el botón "Eliminar"
			var button = sender as Button;
			var paciente = button?.BindingContext as Personas;
			if (paciente != null)
			{
				bool confirm = await App.Current.MainPage.DisplayAlert(
					"Confirmar eliminación",
					$"¿Está seguro de que desea eliminar a {paciente.Nombre} {paciente.Apellido}?",
					"Sí",
					"No"
				);

				if (confirm)
				{
					await EliminarPacienteAsync(paciente.Id);
					await CargarPacientesAsync(); // Recargar la lista de pacientes después de eliminar uno
				}
			}
		}	
		private async Task EliminarPacienteAsync(int idPersona)
		{
			string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";

			using (var conn = new MySqlConnection(connectionString))
			{
				await conn.OpenAsync();

				string sql = "UPDATE persona SET estado = 0 WHERE idPersona = @idPersona";
				using (var cmd = new MySqlCommand(sql, conn))
				{
					cmd.Parameters.AddWithValue("@idPersona", idPersona);
					await cmd.ExecuteNonQueryAsync();
				}
			}
		}

		private async void Button_Clicked_2(object sender, EventArgs e)
		{
			// Manejar el evento de clic para el botón "PreRegistro"
			var button = sender as Button;
			var paciente = button?.BindingContext as Personas;
			if (paciente != null)
			{
				await Navigation.PushAsync(new MetodoDiagnostico(paciente.Id));
			}
		}
    private async void Button_Clicked_3(object sender, EventArgs e)
    {

            await Navigation.PushAsync(new Menu());
    }
}
public class Personas
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Direccion { get; internal set; }
    public string Telefono { get; internal set; }
    public int Edad { get; internal set; }
    public string HistorialClinico { get; internal set; }
    public string Sexo { get; internal set; }
    public string Cedula { get; internal set; }
}


