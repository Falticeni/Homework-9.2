using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudBookApp.Classes;
using System.Data.SqlClient;

//                     The total price for books for a publisher         //


namespace SummaryPublisherApp.Classes
{
    public class TotalPrice: Conexiune
    {
        public static void TotalPriceOfBooks()
        {
            // Sql string 
            string totalPrice = "Select Publisher.PublisherId, Publisher.Name, Sum(Book.Price) as TotalPriceOfBooks " +
                "from Book, Publisher " +
                "Where Publisher.PublisherId = Book.PublisherId " +
                "Group by Publisher.PublisherId, Publisher.Name ";

            // Command
            SqlCommand comand4 = new SqlCommand(totalPrice, SqlConnection);

            try
            {
                SqlConnection.Open(); // open connection
                List<Publisher2> list = new List<Publisher2>(); // empty list of Publisher

                // DataReader
                SqlDataReader reader = comand4.ExecuteReader();
                while (reader.Read())
                {
                    object publisherId = reader["PublisherId"];
                    object name = reader["Name"];
                    object price = reader["TotalPriceOfBooks"];

                    Publisher2 editura = new Publisher2 { PublisherId = (int)publisherId, Name = name as string, TotalPriceOfBooks = (decimal)price };
                    list.Add(editura); // add editura to list
                }
                Console.WriteLine($"Lista cu preturile cartilor publicate de fiecare editura in parte: \n");
                foreach (Publisher2 edit in list)
                {
                    edit.Print();
                }

            }
            catch
            {
                Console.WriteLine("A aparut o eroare!");
            }
            finally
            {
                SqlConnection.Close(); // close connection
            }
        }
    }
}
