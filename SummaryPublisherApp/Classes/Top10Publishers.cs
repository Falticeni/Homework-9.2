using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudBookApp.Classes;
using System.Data.SqlClient;
using System.Security.Policy;

//        Top 10 publishers(Id, Name) (SQL Data Reader)           //


namespace SummaryPublisherApp.Classes
{
    public class Top10Publishers: Conexiune
    {
        public static void TopTenPublishers()
        {
            // Sql string
            string top10 = "Select top 10 * from Publisher";

            // Command
            SqlCommand comand2 = new SqlCommand(top10, SqlConnection);

            try
            {
                SqlConnection.Open(); // deschidem conexiunea

                // DataReader
                SqlDataReader reader = comand2.ExecuteReader();
                List<Publisher> list = new List<Publisher>();

                while (reader.Read())
                {
                    object publisherId = reader["PublisherId"];
                    object name = reader["Name"];

                    //create Publisher
                    Publisher Editura = new Publisher { PublisherId = (int)publisherId, Name = name as string };

                    //Add Publisher to list
                    list.Add(Editura);
                }
                Console.WriteLine($"Lista primelor 10 edituri din baza de date: \n");
                foreach (Publisher editura in list)
                {
                    editura.Print();
                }
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
