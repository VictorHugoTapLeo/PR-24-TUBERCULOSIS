using MySql.Data.MySqlClient;
using PR_24_TUBERCULOSIS.Interface;
using PR_24_TUBERCULOSIS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_24_TUBERCULOSIS.Implementacion
{
    public class KardexImpl : BaseImpl, IKardex
    {
        public int Delete(KardexModel t)
        {
            throw new NotImplementedException();
        }

        public KardexModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(KardexModel t)
        {
            query = @"
                    INSERT INTO tuberculosis.cardex (tipoTuberculosis, saturacion, frecuenciaCardiaca, frecuenciaRespiratoria, diagnosticadoPor, Persona_idPersona, docificacionMedicamentos,numeroDosis,cultivo,basiloscopia)
                    VALUES (@tipoTuberculosis, @saturacion, @frecuenciaCardiaca, @frecuenciaRespiratoria, @diagnosticadoPor, @Persona_idPersona, @docificacionMedicamentos,@numeroDosis,@cultivo,@basiloscopia);";

            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@tipoTuberculosis", t.tipoTuberculosis);
            command.Parameters.AddWithValue("@saturacion", t.saturacion);
            command.Parameters.AddWithValue("@frecuenciaCardiaca", t.frecuenciaCardiaca);
            command.Parameters.AddWithValue("@frecuenciaRespiratoria", t.frecuenciaRespiratoria);
            command.Parameters.AddWithValue("@diagnosticadoPor", SessionManager.UserId); //doctor que esta registrando este kardex
            command.Parameters.AddWithValue("@Persona_idPersona", AtributosPaciente.UserId); //colocar el id de la persona a la que se esta resgistrando osea el paciente
            command.Parameters.AddWithValue("@docificacionMedicamentos", t.docificacionMedicamentos);
            command.Parameters.AddWithValue("@numeroDosis", t.numeroDosis);
            command.Parameters.AddWithValue("@cultivo", t.cultivo);
            command.Parameters.AddWithValue("@basiloscopia", t.basiloscopia);



            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT fechacreacion AS 'Fecha', tipoTuberculosis AS 'Tipo Tuberculosis', docificacionMedicamentos AS 'Docificacion',idCardex AS 'id'
                      FROM tuberculosis.cardex
                      WHERE Persona_idPersona = @idPersona; ";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPersona", AtributosPaciente.UserId); // recuperar el id del paciente
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable Kardex(int idPersona, int idCardex)
        {
            query = @"SELECT tipoTuberculosis, saturacion, frecuenciaCardiaca,frecuenciaRespiratoria,(SELECT CONCAT(primerNombre,' ',primerApellido) FROM tuberculosis.persona WHERE idPersona = diagnosticadoPor)AS 'Diagnosticado Por',fechaCreacion,
docificacionMedicamentos,numeroDosis,cultivo,basiloscopia
              FROM tuberculosis.cardex
              WHERE Persona_idPersona = @idPersona AND idCardex = @idCardex;";

            MySqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@idPersona", idPersona);
            command.Parameters.AddWithValue("@idCardex", idCardex);

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(KardexModel t)
        {
            throw new NotImplementedException();
        }
    }
}
