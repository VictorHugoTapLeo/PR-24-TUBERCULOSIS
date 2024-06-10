namespace PR_24_TUBERCULOSIS.Views.Transferencia;
using MySql.Data.MySqlClient;
using PR_24_TUBERCULOSIS.Model;
using PR_24_TUBERCULOSIS.Views.Paciente;
using System.Data;
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
            string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";

            using (var conn = new MySqlConnection(connectionString))
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
        await InsertarDatosAsync();
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
        string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";

        using (var conn = new MySqlConnection(connectionString))
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
        string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";

        using (var conn = new MySqlConnection(connectionString))
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
        string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";

        using (var conn = new MySqlConnection(connectionString))
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
}