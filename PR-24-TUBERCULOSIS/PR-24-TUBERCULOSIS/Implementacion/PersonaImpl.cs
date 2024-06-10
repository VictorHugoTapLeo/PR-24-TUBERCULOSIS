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
    class PersonaImpl : BaseImpl, IPersona
    {
        public int Delete(Persona t)
        {
            throw new NotImplementedException();
        }

        public Persona Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Persona t)
        {
            throw new NotImplementedException();

        }

        public DataTable Select()
        {
            query = @"SELECT idPersona,usuario 
              FROM persona;";

            MySqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update(Persona t)
        {
            throw new NotImplementedException();
        }
        public DataTable Login(string usuario, string password)
        {
            query = @"SELECT idPersona,usuario, contra, rol , primerInicioSesion,  primerNombre, primerApellido
              FROM persona
              WHERE usuario = @usuario AND contra = @password;";
            //WHERE codigoPersonalSalud = @usuario AND contrasena = MD5(@password)"

            MySqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@password", password).MySqlDbType = MySqlDbType.VarChar;

            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Paciente(int idPersona)
        {
            query = @"SELECT idPersona, primerNombre, primerApellido
              FROM persona
              WHERE idPersona = @idPersona AND rol = 'paciente'";

            MySqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@idPersona", idPersona);


            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateRecoverPassword(string usuario, string password)
        {
            query = @"UPDATE persona SET primerInicioSesion = 0, contra = @password
                    WHERE usuario = @usuario";

            MySqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@usuario", usuario);
            command.Parameters.AddWithValue("@password", password);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            throw new NotImplementedException();
        }
        public int updatePasswordChange(int id, string user, string password, string oldPassword)
        {
            query = @"UPDATE persona SET primerInicioSesion = 1, contra = @password
                    WHERE usuario = @user AND idPersona = @id AND contra =  @oldPassword";

            MySqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@oldPassword", oldPassword);
            command.Parameters.AddWithValue("@user", user);
            command.Parameters.AddWithValue("@password", password);


            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
