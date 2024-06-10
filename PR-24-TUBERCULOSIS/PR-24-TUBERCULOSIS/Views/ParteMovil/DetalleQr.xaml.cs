namespace PR_24_TUBERCULOSIS.Views.ParteMovil;
using MySql.Data.MySqlClient;
using System;
public partial class DetalleQr : ContentPage
{
    public string QrText { get; set; }
    public DetalleQr(string qrText)
	{
		InitializeComponent();
        QrText = qrText;
        BindingContext = this;

        //// Verificar si el ID existe en la base de datos y su rol es paciente
        //bool idAndRoleValid = VerificarIdYRolEnBaseDeDatos(qrText);
        //if (idAndRoleValid)
        //{
        //	// El ID existe en la base de datos y su rol es paciente
        //	Console.WriteLine("El ID existe en la base de datos y su rol es paciente.");
        //}
        //else
        //{
        //	// El ID no existe en la base de datos o su rol no es paciente
        //	Console.WriteLine("El ID no existe en la base de datos o su rol no es paciente.");
        //}
    }
    //private bool VerificarIdYRolEnBaseDeDatos(string id)
    //{
    //	string connectionString = "Server=localhost; Port=3306; Database=tuberculosis1; Uid=root; Pwd=1234567; SslMode=None;";
    //	string sql = "SELECT COUNT(*) FROM persona WHERE id = @id AND rol = 'paciente'";

    //	using (var conn = new MySqlConnection(connectionString))
    //	{
    //		conn.Open();

    //		using (var cmd = new MySqlCommand(sql, conn))
    //		{
    //			cmd.Parameters.AddWithValue("@id", id);
    //			int count = Convert.ToInt32(cmd.ExecuteScalar());
    //			return count > 0;
    //		}
    //	}
    //}
}

