using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace SQLLearning
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*SqlConnection myConnection = new SqlConnection("user id=usuario;" +
                                       "password=usuario;server=localhost;" +
                                       "Trusted_Connection=yes;" +
                                       "database=jardineria; " +
                                       "connection timeout=3");

            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT * FROM gamaproductos", myConnection);
                var myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine(myReader["Gama"].ToString());
                    Console.WriteLine(myReader["DescripcionTexto"].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }*/

            string connectionString =
         "Server=localhost;" +
         "Database=jardineria;" +
         "User ID=root;" +
         "Password=;" +
         "Pooling=false";
            IDbConnection dbcon;
            dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            IDbCommand dbcmd = dbcon.CreateCommand();
            // requires a table to be created named employee
            // with columns firstname and lastname
            // such as,
            //        CREATE TABLE employee (
            //           firstname varchar(32),
            //           lastname varchar(32));
            string sql =
                "SELECT * FROM gamasproducto";
            dbcmd.CommandText = sql;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Gama: {0}", reader["Gama"].ToString());
                Console.WriteLine("Descripción: {0}", reader["DescripcionTexto"].ToString());
            }
            // clean up
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbcon.Close();
            dbcon = null;

            Console.Read();
        }
    }
}