namespace PR_24_TUBERCULOSIS.Views.Paciente;
using System;
using System.Data;
using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;
using PR_24_TUBERCULOSIS.Implementacion;

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
        // Aqu� puedes cargar los datos del paciente usando el ID proporcionado
        // Por ejemplo, obtener el peso inicial del paciente desde la base de datos
        var baseImpl = new BaseImpl(); // Crear una instancia de la clase BaseImpl

        using (var conn = new MySqlConnection(baseImpl.connectionString))
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
                        // Asigna el valor de pesoInicial a alg�n control en tu UI si es necesario
                    }
                }
            }
        }
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
		string campoInvalido;

		// Validar los campos antes de proceder
		if (CamposSonValidos(out campoInvalido))
		{
			// Si los campos son v�lidos, procede a insertar los datos
			await InsertarDatosAsync();

			// Navegar a la lista de pacientes despu�s de la inserci�n exitosa
			await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPacientes() }));
		}
		else
		{
			// Mostrar mensaje de error indicando el campo inv�lido
			await DisplayAlert("Error", $"Campo inv�lido: {campoInvalido}", "OK");
		}
	}
    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NavigationPage(new ContentPage { Content = new ListaPreRegistro() }));
    }
    private async Task InsertarDatosAsync()
    {
        var baseImpl = new BaseImpl(); // Crear una instancia de la clase BaseImpl

        using (var conn = new MySqlConnection(baseImpl.connectionString))
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
                await DisplayAlert("�xito", "Diagn�stico y actualizaci�n de rol registrados correctamente.", "OK");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                await DisplayAlert("Error", $"Error al registrar el diagn�stico o actualizar el rol: {ex.Message}", "OK");
            }
        }
    }

	private bool EsBaciloscopiaValida(out string campoInvalido)
	{
		campoInvalido = string.Empty;

		// Verificar si se ha seleccionado una opci�n v�lida en el Picker de Baciloscopia
		if (BaciloscopiaPicker.SelectedIndex == -1)
		{
			campoInvalido = "Debe seleccionar una opci�n para Baciloscopia.";
			return false;
		}

		return true;
	}
	private bool EsCultivoValido(out string campoInvalido)
	{
		campoInvalido = string.Empty;

		// Verificar si se ha seleccionado una opci�n v�lida en el Picker de Cultivo
		if (CultivoPicker.SelectedIndex == -1)
		{
			campoInvalido = "Debe seleccionar una opci�n para Cultivo.";
			return false;
		}

		return true;
	}
	private bool EsClinicoValido(out string campoInvalido)
	{
		campoInvalido = string.Empty;

		// Verificar si el campo Cl�nico no est� vac�o
		if (string.IsNullOrWhiteSpace(ClinicoEntry.Text))
		{
			campoInvalido = "Debe ingresar el valor para Cl�nico.";
			return false;
		}

		return true;
	}
	private bool EsGenexpertValido(out string campoInvalido)
	{
		campoInvalido = string.Empty;

		// Verificar si se ha seleccionado una opci�n v�lida en el Picker de Genexpert
		if (GenexpertPicker.SelectedIndex == -1)
		{
			campoInvalido = "Debe seleccionar una opci�n para Genexpert.";
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

		// Validar Cultivo
		if (!EsCultivoValido(out campoInvalido))
		{
			return false;
		}

		// Validar Cl�nico
		if (!EsClinicoValido(out campoInvalido))
		{
			return false;
		}

		// Validar Genexpert
		if (!EsGenexpertValido(out campoInvalido))
		{
			return false;
		}

		// Puedes agregar m�s validaciones aqu� si es necesario

		return true;
	}

}