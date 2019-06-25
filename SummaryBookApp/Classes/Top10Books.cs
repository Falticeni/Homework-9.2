using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CrudBookApp.Classes;

//                  Top 10 books (Title, Year, Price)                       //


namespace SummaryBookApp.Classes
{
    public class Top10Books : Conexiune
    {
        public static void TopTenBooks()
        {
            //SQLQuery
            string top10 = "Select top 10 * from Book";

            //Command
            SqlCommand top10books = new SqlCommand(top10, SqlConnection);

            try
            {
                SqlConnection.Open(); // open connection

                //DataReader
                SqlDataReader reader = top10books.ExecuteReader();
                List<Book> list = new List<Book>();

                while (reader.Read())
                {
                    object bookId = reader["BookId"];
                    object title = reader["Title"];
                    object publisherId = reader["PublisherId"];
                    object year = reader["Year"];
                    object price = reader["Price"];

                    // Create carte (obj)
                    Book carte = new Book { BookId = (int)bookId, Title = title as string, PublisherId=(int)publisherId, Year = (int)year, Price = (decimal)price };

                    // add carte (obj) to list
                    list.Add(carte);
                }
                Console.WriteLine($"Lista primelor 10 carti din baza de date: \n");
                foreach (Book carte in list)
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
