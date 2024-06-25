namespace PR_24_TUBERCULOSIS.Views.Transferencia;
using MySql.Data.MySqlClient;
using PR_24_TUBERCULOSIS.Implementacion;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Views.Paciente;
using System.Data;
using System.Text.RegularExpressions;

public partial class Transferencia : ContentPage
{
    //metodo para obtner id nesesario
    private int personaIds = AtributosPaciente.UserId; // Define el ID estático del paciente
    public Transferencia()
    {
        InitializeComponent();
        CargarDatosPaciente();
        CargarDatosPersona();
        int userId = SessionManager.UserId;
        CargarDatosDoctor(userId);
        //int doctorId = SessionManager.UserId; // ID del doctor estático
        //CargarDatosDoctor(doctorId);
    }
    private async Task InsertarDatosAsync()
    {
        try
        {
            var baseImpl = new BaseImpl(); // Crear una instancia de la clase BaseImpl

            using (var conn = new MySqlConnection(baseImpl.connectionString))
            {
                await conn.OpenAsync();

                using (var transaction = await conn.BeginTransactionAsync())
                {
                    string sqlInsertTransferencia = @"INSERT INTO transferencia (tipoTransferencia, sedeOrigen, establecimientoOrigen, cordinacionRedSaludOrigen, telefonoOrigen,fechaTransferencia,sedeDestino, establecimientoDestino, cordinacionRedSaludDestino, 
                                                    direccionDestino,numHistorialClinico, 
                                                  criterioIngreso, 
                                                  basiloscopiaDiagnostico, 
                                                  basiloscopiaResultado, 
                                                  basiloscopiaFecha, 
                                                  cultivoDiagnostico, 
                                                  cultivoResultado, 
                                                  cultivoFecha, 
                                                  genexpert, 
                                                  genexpertResultado, 
                                                  genexpertFecha, 
                                                  pruebas, 
                                                  pruebasResultado, 
                                                  pruebasFecha, 
                                                  ultimaBasiloscopia, 
                                                  ultimaBasiloscopiaResultado, 
                                                  ultimaBasiloscopiaFecha, 
                                                  histopatologia, 
                                                  histopatologiaResulto, 
                                                  histopatologiaFecha, 
                                                  motivo, 
                                                  tratamiento, 
                                                  fase, 
                                                  mes, 
                                                  dosis, 
                                                  comentario, 
                                                  idDoctor, 
                                                  cargo, 
                                                  persona_idPersona
                                              ) 
                                              VALUES (
                                                  @tipoTransferencia, 
                                                  @sedeOrigen, 
                                                  @establecimientoOrigen, 
                                                  @cordinacionRedSaludOrigen, 
                                                  @telefonoOrigen, 
                                                  @fechaTransferencia,
                                                  @sedeDestino, 
                                                  @establecimientoDestino, 
                                                  @cordinacionRedSaludDestino, 
                                                  @direccionDestino, 
                                                  @numHistorialClinico, 
                                                  @criterioIngreso, 
                                                  @basiloscopiaDiagnostico, 
                                                  @basiloscopiaResultado, 
                                                  @basiloscopiaFecha, 
                                                  @cultivoDiagnostico, 
                                                  @cultivoResultado, 
                                                  @cultivoFecha, 
                                                  @genexpert, 
                                                  @genexpertResultado, 
                                                  @genexpertFecha, 
                                                  @pruebas, 
                                                  @pruebasResultado, 
                                                  @pruebasFecha, 
                                                  @ultimaBasiloscopia, 
                                                  @ultimaBasiloscopiaResultado, 
                                                  @ultimaBasiloscopiaFecha, 
                                                  @histopatologia, 
                                                  @histopatologiaResulto, 
                                                  @histopatologiaFecha, 
                                                  @motivo, 
                                                  @tratamiento, 
                                                  @fase, 
                                                  @mes, 
                                                  @dosis, 
                                                  @comentario, 
                                                  @idDoctor, 
                                                  @cargo,
                                                  @persona_idPersona
                                              )";

                    var cmdInsertTransferencia = new MySqlCommand(sqlInsertTransferencia, conn, transaction);

                    // Asignar valores a los parámetros
                    //origen
                    cmdInsertTransferencia.Parameters.AddWithValue("@tipoTransferencia", tipoTransferencia);//radiobuton
                    cmdInsertTransferencia.Parameters.AddWithValue("@sedeOrigen", sedeOrigenEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@establecimientoOrigen", establecimientoOrigenEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@cordinacionRedSaludOrigen", coordinacionSaludEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@telefonoOrigen", telefonoEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@fechaTransferencia", FechaPicker.Date);
                    //destino
                    cmdInsertTransferencia.Parameters.AddWithValue("@sedeDestino", sedeDestinoEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@establecimientoDestino", establecimientoDestinoEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@cordinacionRedSaludDestino", coordinacionSaludDestinoEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@direccionDestino", direccionDestinoEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@numHistorialClinico", historialClinicoEntry.Text);
                    //Criterios
                    cmdInsertTransferencia.Parameters.AddWithValue("@criterioIngreso", tipoCriterio);//radio button
                    cmdInsertTransferencia.Parameters.AddWithValue("@basiloscopiaDiagnostico", baciloscopiaEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@basiloscopiaResultado", resultado1Entry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@basiloscopiaFecha", fecha1Picker.Date);
                    cmdInsertTransferencia.Parameters.AddWithValue("@cultivoDiagnostico", cultivoDiagnosticoEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@cultivoResultado", resultado2Entry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@cultivoFecha", fecha2Picker.Date);
                    cmdInsertTransferencia.Parameters.AddWithValue("@genexpert", geneXpertEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@genexpertResultado", resultado3Entry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@genexpertFecha", fecha3Picker.Date);
                    cmdInsertTransferencia.Parameters.AddWithValue("@pruebas", pruebaSensibilidadEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@pruebasResultado", resultado4Entry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@pruebasFecha", fecha4Picker.Date);
                    cmdInsertTransferencia.Parameters.AddWithValue("@ultimaBasiloscopia", ultimaBasiloscopiaEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@ultimaBasiloscopiaResultado", resultado5Entry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@ultimaBasiloscopiaFecha", fecha5Picker.Date);
                    cmdInsertTransferencia.Parameters.AddWithValue("@histopatologia", histopatologiaEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@histopatologiaResulto", resultado6Entry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@histopatologiaFecha", fecha6Picker.Date);
                    cmdInsertTransferencia.Parameters.AddWithValue("@motivo", motivoEntry.Text);
                    //
                    cmdInsertTransferencia.Parameters.AddWithValue("@tratamiento", tipoTratamiento);//radio buton
                    cmdInsertTransferencia.Parameters.AddWithValue("@fase", tipoFase);//radio buton
                    cmdInsertTransferencia.Parameters.AddWithValue("@mes", mesEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@dosis", dosisEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@comentario", comentarioTratamientoEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@idDoctor", SessionManager.UserId);//recuperar el id
                    cmdInsertTransferencia.Parameters.AddWithValue("@cargo", cargoRefEntry.Text);
                    cmdInsertTransferencia.Parameters.AddWithValue("@persona_idPersona", AtributosPaciente.UserId);
                    // Asignar los demás valores de los parámetros...

                    // Ejecutar la consulta
                    await cmdInsertTransferencia.ExecuteNonQueryAsync();

                    // Confirmar la transacción
                    await transaction.CommitAsync();
                }
            }

            // Mostrar mensaje de éxito
            await DisplayAlert("Éxito", "Datos insertados correctamente.", "OK");
            var navigation = Application.Current.MainPage.Navigation;
            await navigation.PushAsync(new MenuActividades());
        }
        catch (Exception ex)
        {
            // Mostrar mensaje de error en caso de excepción
            await DisplayAlert("Error", $"Error al insertar los datos: {ex.Message}", "OK");
        }

    }
    //tipotransferencia
    string tipoTransferencia = "";
    private void radioButton1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (radioButton1.IsChecked)
        {
            tipoTransferencia = "Referencia";
        }
        else if (radioButton2.IsChecked)
        {
            tipoTransferencia = "ContraReferencia";
        }
        else if (radioButton3.IsChecked)
        {
            tipoTransferencia = "Transferencia";
        }
    }
    //tipo criterio
    string tipoCriterio = "";
    private void radioButton1_CheckedChanged_1(object sender, CheckedChangedEventArgs e)
    {
        if (Criterios1.IsChecked)
        {
            tipoCriterio = "Pulmonar Bacteriológicamente Positivo";
        }
        else if (Criterios2.IsChecked)
        {
            tipoCriterio = "Nuevo";
        }
        else if (Criterios3.IsChecked)
        {
            tipoCriterio = "Recaída";
        }
        else if (Criterios4.IsChecked)
        {
            tipoCriterio = "Pulmonar Diagnóstico clínico";
        }
        else if (Criterios5.IsChecked)
        {
            tipoCriterio = "Perdida en el seguimiento";
        }
        else if (Criterios6.IsChecked)
        {
            tipoCriterio = "Extrapulmonar";
        }
        else if (Criterios7.IsChecked)
        {
            tipoCriterio = "Fracaso";
        }
    }
    string tipoTratamiento = "";
    private void Tratamientos1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (Tratamientos1.IsChecked)
        {
            tipoTratamiento = "TB-Sensible";
        }
        else if (Tratamientos2.IsChecked)
        {
            tipoTratamiento = "TB-MDR";
        }
        else if (Tratamientos3.IsChecked)
        {
            tipoTratamiento = "Modificado";
        }
        else if (Tratamientos4.IsChecked)
        {
            tipoTratamiento = "TB-XDR";
        }
        else if (Tratamientos5.IsChecked)
        {
            tipoTratamiento = "RAFA";
        }
    }
    string tipoFase = "";
    private void FaseActual1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (FaseActual1.IsChecked)
        {
            tipoFase = "Intensiva";
        }
        else if (FaseActual2.IsChecked)
        {
            tipoFase = "Continuacion";
        }
    }

    private async void Registrar_Clicked(object sender, EventArgs e)
    {
        string campoInvalido;
        if (CamposSonValidos(out campoInvalido))
        {
            await InsertarDatosAsync();
        }
        else
        {
            await DisplayAlert("Error", $"Por favor, complete el campo '{campoInvalido}' correctamente.", "OK");
        }
    }
    private async void CargarDatosPaciente()
    {
        var paciente = await ObtenerPacienteAsync(personaIds); // Utiliza el ID estático

        if (paciente != null)
        {

            sexoEntry.Text = paciente.Sexo;
            direccionActualEntry.Text = paciente.Direccion.ToString();
        }
        else
        {
            await DisplayAlert("Error", "No se encontraron datos para el paciente.", "OK");
        }
    }
    private async void CargarDatosPersona()
    {
        var paciente = await ObtenerPersonaAsync(personaIds); // Utiliza el ID estático

        if (paciente != null)
        {
            nombreApellidoEntry.Text = $"{paciente.Nombre} {paciente.Apellido}";
            telefonoPacienteEntry.Text = paciente.Telefono;
            edadEntry.Text = paciente.Edad.ToString();
            cedulaEntry.Text = paciente.Cedula;
        }
        else
        {
            await DisplayAlert("Error", "No se encontraron datos para el paciente.", "OK");
        }
    }
    public async Task<Personas> ObtenerPersonaAsync(int idPersona)
    {
        var baseImpl = new BaseImpl(); // Crear una instancia de la clase BaseImpl

        using (var conn = new MySqlConnection(baseImpl.connectionString))
        {
            await conn.OpenAsync();

            string sql = "SELECT idPersona, primerNombre, primerApellido, numeroCelular, carnetIdentidad FROM persona WHERE idPersona = @idPersona";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idPersona", idPersona);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Personas
                        {
                            Nombre = reader.GetString("primerNombre"),
                            Apellido = reader.GetString("primerApellido"),
                            Telefono = reader["numeroCelular"].ToString(), // Usa ToString para convertir a cadena
                            Cedula = reader["carnetIdentidad"].ToString() // Usa ToString para convertir a cadena
                        };
                    }
                }
            }
        }
        return null;
    }
    public async Task<Personas> ObtenerPacienteAsync(int idPersona)
    {
        var baseImpl = new BaseImpl(); // Crear una instancia de la clase BaseImpl

        using (var conn = new MySqlConnection(baseImpl.connectionString))
        {
            await conn.OpenAsync();

            string queryPaciente = "SELECT direccion, sexo FROM paciente WHERE idPaciente = @idPersona";
            using (var cmd = new MySqlCommand(queryPaciente, conn))
            {
                cmd.Parameters.AddWithValue("@idPersona", idPersona);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Personas
                        {
                            Sexo = reader.GetBoolean("sexo") ? "Masculino" : "Femenino",
                            Direccion = reader.GetString("direccion"),

                        };
                    }
                }
            }
        }
        return null;
    }

    public async Task<Personas> ObtenerDoctorAsync(int idUsuario)
    {
        var baseImpl = new BaseImpl(); // Crear una instancia de la clase BaseImpl

        using (var conn = new MySqlConnection(baseImpl.connectionString))
        {
            await conn.OpenAsync();

            string sql = "SELECT primerNombre, primerApellido, numeroCelular FROM persona WHERE idPersona = @idUsuario";
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Personas
                        {
                            Nombre = reader.GetString("primerNombre"),
                            Apellido = reader.GetString("primerApellido"),
                            Telefono = reader["numeroCelular"].ToString() // Usa ToString para convertir a cadena
                        };
                    }
                }
            }
        }
        return null;
    }

    private async void CargarDatosDoctor(int idUsuario)
    {
        var doctor = await ObtenerDoctorAsync(idUsuario);

        if (doctor != null)
        {
            nombreApellidoRefEntry.Text = $"{doctor.Nombre} {doctor.Apellido}";
            telefonoRefEntry.Text = doctor.Telefono;
        }
        else
        {
            await DisplayAlert("Error", "No se encontraron datos para el doctor.", "OK");
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var navigation = Application.Current.MainPage.Navigation;
        await navigation.PushAsync(new MenuActividades());
    }

    private bool CamposSonValidos(out string campoInvalido)
    {
        // Inicializa el campo inválido como vacío
        campoInvalido = string.Empty;

		// Validar campos de texto
		///origen
		// Validar selección de tipo de transferencia
		if (!radioButton1.IsChecked && !radioButton2.IsChecked && !radioButton3.IsChecked)
		{
			campoInvalido = "Tipo de transferencia";
			return false;
		}
		if (!EsTextoValido(sedeOrigenEntry.Text))
		{
			campoInvalido = "Sede de Destino (solo letras)";
			return false;
		}
		if (!EsTextoValido(coordinacionSaludEntry.Text))
		{
			campoInvalido = "Coordinacion de red de Salud (solo letras)";
			return false;
		}
		if (!EsTextoValido(municipioEntry.Text))
		{
			campoInvalido = "municipio de destino (solo letras)";
			return false;
		}
		if (!EsTextoValido(establecimientoOrigenEntry.Text))
		{
			campoInvalido = "establecimiento de destino (solo letras)";
			return false;
		}
		if (!EsNumeroCelularValido(telefonoEntry.Text))
		{
			campoInvalido = "telefono de destino (tiene que tener 8 digitos)";
			return false;
		}
		//destino
		if (!EsTextoValido(sedeDestinoEntry.Text))
        {
            campoInvalido = "Sede de Destino (solo letras)";
            return false;
        }
        if (!EsTextoValido(coordinacionSaludDestinoEntry.Text))
        {
            campoInvalido = "Coordinacion de red de Salud de destino (solo letras)";
            return false;
        }
        if (!EsTextoValido(municipioDestinoEntry.Text))
        {
            campoInvalido = "municipio de destino (solo letras)";
            return false;
        }
        if (!EsTextoValido(establecimientoDestinoEntry.Text))
        {
            campoInvalido = "establecimiento de destino (solo letras)";
            return false;
        }
		if (!EsTextoValido(direccionDestinoEntry.Text))
		{
			campoInvalido = "establecimiento de destino (solo letras)";
			return false;
		}

		//datos generales
		if (!EsEdadValida(edadEntry.Text, out int edad))
		{
			campoInvalido = "Edad de datos generales (solo numeros)";
			return false;
		}

		//criterio

		// Validar selección de tipo de criterio
		if (!Criterios1.IsChecked && !Criterios2.IsChecked && !Criterios3.IsChecked &&
			!Criterios4.IsChecked && !Criterios5.IsChecked && !Criterios6.IsChecked && !Criterios7.IsChecked)
		{
			campoInvalido = "Tipo de criterio";
			return false;
		}
		//resultadobacterologia
		if (!EsTextoValido(baciloscopiaEntry.Text))
		{
			campoInvalido = "Baciloscopia de diagnóstico (solo letras)";
			return false;
		}
		if (!EsTextoValido(cultivoDiagnosticoEntry.Text))
		{
			campoInvalido = "Cultivo de diagnóstico (solo letras)";
			return false;
		}
		if (!EsTextoValido(geneXpertEntry.Text))
		{
			campoInvalido = "GeneXpert/MTB-RIF u otro (solo letras)";
			return false;
		}
		if (!EsTextoValido(pruebaSensibilidadEntry.Text))
		{
			campoInvalido = "Prueba de sensibilidad y resistencia (solo letras)";
			return false;
		}
		if (!EsTextoValido(ultimaBasiloscopiaEntry.Text))
		{
			campoInvalido = "Resultado de última baciloscopia (solo letras)";
			return false;
		}
		if (!EsTextoValido(histopatologiaEntry.Text))
		{
			campoInvalido = "Resultado de histopatología (solo letras)";
			return false;
		}
		if (!EsTextoValido(motivoEntry.Text))
		{
			campoInvalido = "Motivo (solo letras)";
			return false;
		}
		if (!EsTextoValido(resultado1Entry.Text))
		{
			campoInvalido = "Resultado 1 (solo letras)";
			return false;
		}
		if (!EsTextoValido(resultado2Entry.Text))
		{
			campoInvalido = "Resultado 2 (solo letras)";
			return false;
		}
		if (!EsTextoValido(resultado3Entry.Text))
		{
			campoInvalido = "Resultado 3 (solo letras)";
			return false;
		}
		if (!EsTextoValido(resultado4Entry.Text))
		{
			campoInvalido = "Resultado 4 (solo letras)";
			return false;
		}
		if (!EsTextoValido(resultado5Entry.Text))
		{
			campoInvalido = "Resultado 5 (solo letras)";
			return false;
		}
		if (!EsTextoValido(resultado6Entry.Text))
		{
			campoInvalido = "Resultado 6 (solo letras)";
			return false;
		}
		//tratamiento
		// Validar selección de tipo de tratamiento
		if (!Tratamientos1.IsChecked && !Tratamientos2.IsChecked && !Tratamientos3.IsChecked &&
			!Tratamientos4.IsChecked && !Tratamientos5.IsChecked)
		{
			campoInvalido = "Tipo de tratamiento";
			return false;
		}
		//fase
		// Validar selección de tipo de fase
		if (!FaseActual1.IsChecked && !FaseActual2.IsChecked)
		{
			campoInvalido = "Tipo de fase";
			return false;
		}
		if (!EsTextoValido(mesEntry.Text))
		{
			campoInvalido = "mes de tratamiento (solo letras)";
			return false;
		}
		//persona que hace transferencia
		if (!EsTextoValido(cargoRefEntry.Text))
		{
			campoInvalido = "mes de tratamiento (solo letras)";
			return false;
		}

		return true;

    }

    private bool EsTextoValido(string texto)
    {
        // Solo permite letras y no debe estar vacío
        return !string.IsNullOrWhiteSpace(texto) && Regex.IsMatch(texto, @"^[a-zA-Z]+$");
    }
	private bool EsNumeroCelularValido(string numeroCelular)
	{
		// El número de celular debe tener exactamente 8 dígitos y comenzar con 7 o 6
		return !string.IsNullOrWhiteSpace(numeroCelular) && Regex.IsMatch(numeroCelular, @"^[76]\d{7}$");
	}
	private bool EsEdadValida(string edadTexto, out int edad)
	{
		// Inicializa la variable de salida
		edad = 0;

		// Verifica que el texto no esté vacío y que se pueda convertir a un número entero
		if (int.TryParse(edadTexto, out edad))
		{
			// Verifica que la edad esté en el rango válido
			return edad > 0 && edad <= 100;
		}

		return false;
	}

}