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
    public class SeguimientoPesoImpl : BaseImpl, ISeguimientoPeso
    {
        public int Delete(SeguimientoPeso t)
        {
            throw new NotImplementedException();
        }

        public SeguimientoPeso Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(SeguimientoPeso t)
        {
            query = @"INSERT INTO peso (peso, fechaCreacion,Persona_idPersona)
                        VALUES (@peso,CURRENT_TIMESTAMP, @idPersona);";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@peso", t.peso);
            command.Parameters.AddWithValue("@idPersona", AtributosPaciente.UserId); //recuperar el id de la persona cuando a la que se esta registrando el seguimiento

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
            query = @"SELECT fechaRegistro AS 'FechaRegistro',peso AS 'Peso',(SELECT CONCAT(
    IFNULL(primerNombre, ''), ' ', 
    IFNULL(segundoNombre, ''), ' ', 
    IFNULL(primerApellido, ''), ' ', 
    IFNULL(segundoApellido, '')
)
FROM tuberculosis.persona 
WHERE idPersona = @idPersona) AS Paciente FROM tuberculosis.peso WHERE Persona_idPersona = @idPersona
                    ORDER BY 1;";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPersona", AtributosPaciente.UserId); // paciente id del cual se esta registrando su peso
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update(SeguimientoPeso t)
        {
            throw new NotImplementedException();
        }
    }
}
