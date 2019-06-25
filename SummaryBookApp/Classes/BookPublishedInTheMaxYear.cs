using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CrudBookApp.Classes;

//                     The book that is published in the max year (can use multiple commands)                    //


namespace SummaryBookApp.Classes
{
    public class BookPublishedInTheMaxYear : Conexiune
    {
        public static void MaxYear()
        {

            //SQLQuery
            string maxYear = "Select * from Book " +
                             "Where Year=(Select max (Year) from Book)";

            //Command
            SqlCommand bookPublishedInMaxYear = new SqlCommand(maxYear, SqlConnection);

            try
            {
                SqlConnection.Open(); // open connection

                //DataReader
                SqlDataReader reader = bookPublishedInMaxYear.ExecuteReader();
                List<Book> list = new List<Book>();

                while (reader.Read())
                {
                    object id = (int)reader["BookId"];
                    object title = reader["Title"];
                    object publisherId = reader["PublisherId"];
                    object year = reader["Year"];
                    object price = reader["Price"];

                    // Create carte (obj)
                    Book carte = new Book { BookId = (int)id, Title = (string)title, PublisherId = (int)publisherId, Year = (int)year, Price = (decimal)price };

                    // add carte (obj) to list
                    list.Add(carte);
                }
                Console.WriteLine($"Ultima carte publicata: \n");
                foreach (var carte in list)
                {
                    carte.Print();
                }
            }
            catch
            {
                Console.WriteLine("A aparut o eroare.");
            }
            finally
            {
                SqlConnection.Close(); // close connection
            }
        }
    }
}
