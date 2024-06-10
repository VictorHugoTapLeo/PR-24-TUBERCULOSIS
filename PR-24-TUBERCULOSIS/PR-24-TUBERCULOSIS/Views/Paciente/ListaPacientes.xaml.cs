using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Views;
using PR_24_TUBERCULOSIS.Views.Kardex;

namespace PR_24_TUBERCULOSIS.Views.Paciente;

public partial class ListaPacientes : ContentView
{
    PersonaImpl persona;
    public ObservableCollection<Persona> Pacientes { get; set; }
    public ListaPacientes()
	{
		InitializeComponent();
        Pacientes = new ObservableCollection<Persona>();
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

            string sql = "SELECT idPersona, primerNombre, primerApellido FROM persona WHERE estado = 1 AND rol = 'paciente'";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    Pacientes.Clear();
                    while (await reader.ReadAsync())
                    {
                        var paciente = new Persona
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
        var paciente = button?.BindingContext as Persona;
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
        var paciente = button?.BindingContext as Persona;
        if (paciente != null)
        {
            //guardo en una clase los datos del paciente seleccionado
            persona = new PersonaImpl();
            DataTable dt = persona.Paciente(paciente.Id);
            if (dt.Rows.Count > 0)
            {
                AtributosPaciente.UserId = int.Parse(dt.Rows[0][0].ToString());
                AtributosPaciente.Name = dt.Rows[0][1].ToString();
                AtributosPaciente.LastName = dt.Rows[0][2].ToString();
            }
                await Navigation.PushAsync(new ViewKardex()); //deberia ir a la lista kardex de ese paciente


        }
    }
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Menu());
    }
}