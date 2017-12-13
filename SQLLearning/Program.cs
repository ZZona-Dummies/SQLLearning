using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace SQLLearning
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Important: CREATE USER 'usuario'@'localhost' IDENTIFIED VIA mysql_native_password USING '***'; GRANT USAGE ON *.* TO 'usuario'@'localhost' REQUIRE NONE; GRANT SELECT ON `jardineria`.* TO 'usuario'@'localhost';
            //           CREATE USER 'usuario'@'%' IDENTIFIED VIA mysql_native_password USING '***'; GRANT USAGE ON *.* TO 'usuario'@'%' REQUIRE NONE; GRANT SELECT ON `jardineria`.* TO 'usuario'@'localhost';
            // GRANT SELECT ON `jardineria`.* TO 'usuario'@'%' WITH GRANT OPTION; -- <--- Si no tiene GRANT option no nos va a dejar
            // GRANT SELECT ON `jardineria`.* TO 'usuario'@'localhost' WITH GRANT OPTION;

            string connectionString =
         "Server=localhost;" +
         "Database=jardineria;" +
         "User ID=usuario;" +
         "Password=usuario;" +
         "Pooling=false";

            using (IDbConnection dbcon = new MySqlConnection(connectionString))
            {
                dbcon.Open();
                using (IDbCommand dbcmd = dbcon.CreateCommand())
                {
                    string sql =
                        "SELECT * FROM gamasproducto";
                    dbcmd.CommandText = sql;
                    using (IDataReader reader = dbcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Gama: {0}", reader["Gama"].ToString());
                            Console.WriteLine("Descripción: {0}", reader["DescripcionTexto"].ToString());
                        }
                    }
                }
            }

            Console.Read();
        }
    }
}