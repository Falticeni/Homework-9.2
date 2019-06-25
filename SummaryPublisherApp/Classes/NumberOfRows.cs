using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CrudBookApp.Classes;

//       Number of rows from the Publisher table (Execute scalar)      //


namespace SummaryPublisherApp.Classes
{
    public class NumberOfRows : Conexiune
    {
        public static void NrOfRows()
        {
            // Sql string
            string nrRows = "Select count (*) from Publisher ";

            // Command
            SqlCommand comand1 = new SqlCommand(nrRows, SqlConnection);

            try
            {
                SqlConnection.Open(); // deschidem conexiunea
                var nrOfRows = comand1.ExecuteScalar();  // executam scalarul
                Console.WriteLine("Numarul de randuri din tabela Publisher este {0}", nrOfRows);
            }
            catch
            {
                Console.WriteLine("A aparut o eroare!");
            }
            finally
            {
                SqlConnection.Close();
            }
                        

        }
    }
}
