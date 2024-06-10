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
    public class PersonalImpl : BaseImpl, IPersonal
    {
        public int Delete(PersonalSalud t)
        {
            throw new NotImplementedException();
        }
        public int Delete1(int t)
        {
            query = @"UPDATE Persona SET estado=0,fechaActualizacion=CURRENT_TIMESTAMP
                      WHERE idPersona=@id;";
            MySqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", t);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Update(PersonalSalud t)
        {
            throw new NotImplementedException();
        }
        public PersonalSalud Get(int id)
        {
            PersonalSalud e = null;
            query = @"SELECT  p.idpersona, p.primerNombre,p.segundoNombre, p.primerApellido, p.segundoApellido, p.carnetIdentidad, p.numeroCelular, p.usuario,p.correo, 
                p.rol,s.codigo
                FROM persona p
                INNER JOIN personalsalud s ON p.idPersona = s.idPersonalSalud
                WHERE p.idPersona = @idPersona;";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPersona", id);

            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    e = new PersonalSalud
                    {
                        idPersona = int.Parse(table.Rows[0][0].ToString()),
                        primerNombre = table.Rows[0][1].ToString(),
                        segundoNombre = table.Rows[0][2].ToString(),
                        primerApellido = table.Rows[0][3].ToString(),
                        segundoApellido = table.Rows[0][4].ToString(),
                        ci = table.Rows[0][5].ToString(),
                        celular = int.Parse(table.Rows[0][6].ToString()),
                        usuario = table.Rows[0][7].ToString(),
                        email = table.Rows[0][8].ToString(),
                        rol = table.Rows[0][9].ToString(),
                        codigoPersonalSalud = table.Rows[0][10].ToString()

                    };

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return e;
        }

        public int Delete(int t)
        {
            query = @"UPDATE Person SET status=0,lastUpdate=CURRENT_TIMESTAMP
                      WHERE id=@id";
            MySqlCommand command = CreateBasicCommand(query);

            command.Parameters.AddWithValue("@id", t);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Insert(PersonalSalud t)
        {
            query = @"
                    INSERT INTO persona (primerNombre, segundoNombre, primerApellido, segundoApellido, carnetIdentidad, numeroCelular, usuario,contra,correo,rol)
                    VALUES (@primerNombre, @segundoNombre, @primerApellido, @segundoApellido, @carnetIdentidad, @numeroCelular, @usuario,@contra,@correo,@rol);

                    INSERT INTO PersonalSalud (idPersonalSalud, codigo,Hospital_idHospital)
                    VALUES (@idPersonalSalud,@codigo, 1);";



            int id = GetLastPersonID();
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@primerNombre", t.primerNombre);
            command.Parameters.AddWithValue("@segundoNombre", t.segundoNombre);
            command.Parameters.AddWithValue("@primerApellido", t.primerApellido);
            command.Parameters.AddWithValue("@segundoApellido", t.segundoApellido);
            command.Parameters.AddWithValue("@carnetIdentidad", t.ci);
            command.Parameters.AddWithValue("@numeroCelular", t.celular);
            command.Parameters.AddWithValue("@usuario", t.usuario);
            command.Parameters.AddWithValue("@contra", t.contrasena);
            command.Parameters.AddWithValue("@correo", t.email);
            command.Parameters.AddWithValue("@rol", t.rol);
            command.Parameters.AddWithValue("@idPersonalSalud", id);
            command.Parameters.AddWithValue("@codigo", t.codigoPersonalSalud);

            return ExecuteBasicCommand(command);
        }

        public DataTable Select()
        {
         //   query = @"SELECT 
         //   P.idpersona AS id, P.primerNombre AS Nombre , P.primerApellido AS Apellido, p.segundoApellido,p.carnetIdentidad AS CI

         //FROM
         //       persona AS P
         //   JOIN
         //       personalsalud AS ps ON P.idPersona = ps.idPersonalSalud


         //   WHERE
         //       P.estado = 1  AND p.rol = 'doctor'; ";
            query = @"SELECT idpersona AS id, primerNombre AS Nombre , primerApellido AS Apellido, segundoApellido,carnetIdentidad AS CI
             
            FROM tuberculosis.persona AS P
            WHERE 
                estado = 1  AND rol = 'doctor';";
            MySqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(PersonalSalud t, int id)
        {
            query = @"UPDATE persona SET primerNombre=@primerNombre,segundoNombre=@segundoNombre,primerApellido=@primerApellido,segundoApellido=@segundoApellido,carnetIdentidad=@carnetIdentidad,
                numeroCelular=@numeroCelular,correo=@correo, usuario=@usuario   
                     WHERE idPersona=@idPersona;

                      UPDATE personalsalud SET codigo=@codigo
                     WHERE idPersonalSalud=@idPersonalSalud;";
            MySqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idPersona", id);
            command.Parameters.AddWithValue("@primerNombre", t.primerNombre);
            command.Parameters.AddWithValue("@segundoNombre", t.segundoNombre);
            command.Parameters.AddWithValue("@primerApellido", t.primerApellido);
            command.Parameters.AddWithValue("@segundoApellido", t.segundoApellido);
            command.Parameters.AddWithValue("@carnetIdentidad", t.ci);
            command.Parameters.AddWithValue("@numeroCelular", t.celular);
            command.Parameters.AddWithValue("@correo", t.email);
            command.Parameters.AddWithValue("@usuario", t.usuario);
            // command.Parameters.AddWithValue("@id", t.usuario);

            command.Parameters.AddWithValue("@codigo", t.codigoPersonalSalud);
            command.Parameters.AddWithValue("@idPersonalSalud", id);

            return ExecuteBasicCommand(command);

        }
    }
}
