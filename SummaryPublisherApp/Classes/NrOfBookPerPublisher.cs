using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudBookApp.Classes;
using System.Data.SqlClient;

//      Number of books for each publisher (Publiher Name, Number of Books)    //


namespace SummaryPublisherApp.Classes
{
    public class NrOfBookPerPublisher : Conexiune
    {
        public static void NrOfBooksPerPublisher()
        {
            // Sql string
            string nrBperP = "Select Publisher.PublisherId, Publisher.Name, count (*) as NumberOfBooks " +
                "from Publisher, Book " +
                "Where Publisher.PublisherId = Book.PublisherId " +
                "Group by Publisher.PublisherId, Publisher.Name";

            // Command
            SqlCommand comand3 = new SqlCommand(nrBperP, SqlConnection);

            try
            {
                SqlConnection.Open(); // open connection
                List<Publisher1> NumberOfBooksPerPublisher = new List<Publisher1>(); // empty list of Publisher

                // DataReader
                SqlDataReader reader = comand3.ExecuteReader();
                while (reader.Read())
                {
                    object name = reader["Name"];
                    object publisherID = reader["PublisherId"];
                    object numberB = reader["NumberOfBooks"];

                    Publisher1 editura = new Publisher1 { PublisherId = (int)publisherID, Name = name as string, NumberOfBooks = (int)numberB };
                    NumberOfBooksPerPublisher.Add(editura); // add editura to list
                }
                Console.WriteLine($"Numarul cartilor publicate de fiecare editura in parte: \n");
                foreach (Publisher1 edit in NumberOfBooksPerPublisher)
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
