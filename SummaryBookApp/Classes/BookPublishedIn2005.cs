using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CrudBookApp.Classes;


//                 All the books that are published in 2010                    //


namespace SummaryBookApp.Classes
{
    public class BookPublishedIn2005 : Conexiune
    {
        public static void Book2005()
        {

            //SQLQuery
            string s_BookPublishedIn2005 = "Select * from Book " +
                                         "Where Year=2005";

            //Command
            SqlCommand c_BookPublishedIn2005 = new SqlCommand(s_BookPublishedIn2005, SqlConnection);

            try
            {
                SqlConnection.Open(); // open connection

                //DataReader
                SqlDataReader reader = c_BookPublishedIn2005.ExecuteReader();
                List<Book> list = new List<Book>();

                while (reader.Read())
                {
                    object id = (int)reader["BookId"];
                    object title = reader["Title"];
                    object publisherId = reader["PublisherId"];
                    object year = reader["Year"];
                    object price = reader["Price"];

                    // Create carte (obj)
                    Book carte = new Book { BookId = (int)id, Title = title as string, PublisherId = (int)publisherId, Year = (int)year, Price = (decimal)price };

                    // add carte (obj) to list
                    list.Add(carte);
                }
                Console.WriteLine($"Lista cartilor publicate in 2005: \n");
                foreach (var carte in list)
                {
                    carte.Print();
                }

            }
            //catch
            //{
            //    Console.WriteLine("A aparut o eroare.");
            //}
            finally
            {
                SqlConnection.Close(); // close connection
            }
        }
    }
}
