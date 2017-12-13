using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection myConnection = new SqlConnection("user id=usuario;" +
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
            }

            Console.Read();
        }
    }
}
