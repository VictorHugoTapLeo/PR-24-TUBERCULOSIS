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
    class ControlTratamientoImpl : BaseImpl, IControlTratamiento
    {
        public int Delete(ClControlTratamiento t)
        {
            throw new NotImplementedException();
        }

        public ClControlTratamiento Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ClControlTratamiento t)
        {
            int result = 0;
            string query = "INSERT INTO controltratamiento (basiloscopia, cultivo, aumentoDosis, persona_idPersona, orden_idorden) " +
                           "VALUES (@basiloscopia, @cultivo, @aumentoDosis, @persona_idPersona, @orden_idorden)";

            MySqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@basiloscopia", t.Basiloscopia);
            command.Parameters.AddWithValue("@cultivo", t.Cultivo);
            command.Parameters.AddWithValue("@aumentoDosis", t.AumentoDosis);
            command.Parameters.AddWithValue("@persona_idPersona", AtributosPaciente.UserId);
            command.Parameters.AddWithValue("@orden_idorden", t.OrdenIdOrden);

            try
            {
                result = ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public DataTable Select()
        {
            query = @"SELECT 
               C.idControlTratamiento, C.basiloscopia, C.cultivo, C.aumentoDosis, d.genExpert, concat( p.primerNombre,' ', p.primerApellido)
               AS 'Nombre Paciente'
            FROM 
                tuberculosis.controltratamiento AS C
            JOIN 
                tuberculosis.diagnostico AS d ON C.Persona_idPersona = d.persona_idPersona
                JOIN
                tuberculosis.persona as P ON p.idPersona = c.persona_idPersona
                WHERE C.persona_idPersona = @idPersona ";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPersona", AtributosPaciente.UserId);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(ClControlTratamiento t)
        {
            throw new NotImplementedException();
        }



        ClControlTratamiento IControlTratamiento.Get(int id)
        {
            throw new NotImplementedException();
        }

        public string GetGenexpertForPersona(int personaId)
        {
            string genexpertValue = null;
            string query = "SELECT genExpert FROM diagnostico WHERE Persona_idPersona = @personaId";

            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@personaId", personaId);

            try
            {
                command.Connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    genexpertValue = result.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

            return genexpertValue;
        }

    }
}
