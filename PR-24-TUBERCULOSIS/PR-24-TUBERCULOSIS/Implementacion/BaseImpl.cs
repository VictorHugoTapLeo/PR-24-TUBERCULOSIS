using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PR_24_TUBERCULOSIS.Implementacion
{
    public class BaseImpl
    {
        //string connectionString = @"Server=localhost\SQLEXPRESS;Database=dbInstitution;Trusted_Connection=True;";
        //"Server=localhost;Database=tuberculosis;User Id=root;Password=vale2004;"
        //string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=vale2004;";

        string connectionString = @"Server=localhost;Database=tuberculosis;User Id=root;Password=1860;";


        public int GetLastPersonID()
        {
            string query = "SELECT MAX(idPersona) FROM persona;";
            int lastID = 0;

            MySqlCommand command = CreateBasicCommand(query);
            try
            {
                command.Connection.Open();
                var result = command.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    lastID = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return lastID;
        }

        internal string query = "";
        public MySqlCommand CreateBasicCommand()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            return command;
        }

        //es uma sobrecarga
        public MySqlCommand CreateBasicCommand(string sql)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            //connection.Open();


            MySqlCommand command = new MySqlCommand(sql, connection);
            return command;

        }

        public List<MySqlCommand> Create2BasicCommand(string sql1, string sql2)
        {
            List<MySqlCommand> commands = new List<MySqlCommand>();
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command1 = new MySqlCommand(sql1, connection);
            commands.Add(command1);

            MySqlCommand command2 = new MySqlCommand(sql2, connection);
            commands.Add(command2);

            return commands;

        }
        public List<MySqlCommand> CreateNBasicCommand(List<string> sql)
        {
            List<MySqlCommand> commands = new List<MySqlCommand>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command;

            foreach (var item in sql)
            {
                command = new MySqlCommand(item, connection);
                commands.Add(command);
            }

            return commands;
        }



        public int ExecuteBasicCommand(MySqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }

        }


        public int ExecutNeBasicCommand(List<MySqlCommand> commands)
        {
            MySqlTransaction t = null;

            MySqlCommand command0 = commands[0];
            int n = 0;
            try
            {
                command0.Connection.Open();
                t = command0.Connection.BeginTransaction();//controlado todo con la conexion 

                //return command0.ExecuteNonQuery();
                foreach (MySqlCommand item in commands)
                {
                    item.Transaction = t;
                    n += item.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                throw ex;
            }
            finally
            {
                command0.Connection.Close();
            }
            return n;
        }




        public DataTable ExecuteDataTableCommand(MySqlCommand command)
        {
            DataTable tabla = new DataTable();

            try
            {
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(tabla);
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                command.Connection.Close();
            }
            return tabla;
        }
        public int ExecuteNBasicCommand(List<MySqlCommand> commands)
        {
            MySqlTransaction t = null;
            MySqlCommand command0 = commands[0];
            int n = 0;
            try
            {
                command0.Connection.Open();
                t = command0.Connection.BeginTransaction();
                foreach (MySqlCommand item in commands)
                {
                    item.Transaction = t;
                    n += item.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                throw ex;
            }
            finally
            {
                command0.Connection.Close();

            }
            return n;
        }
        public DataTable ExecutableDataTableCommand(MySqlCommand command)
        {
            DataTable table = new DataTable();
            try
            {
                command.Connection.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                adapter.Fill(table);
            }
            catch (Exception ex) { throw ex; }
            finally { command.Connection.Close(); }
            return table;
        }

    }
}

