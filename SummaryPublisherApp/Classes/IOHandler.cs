using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudBookApp.Classes;
using System.Data.SqlClient;

namespace SummaryPublisherApp.Classes
{
    public class IOHandler : Conexiune
    {
        public static void Menu()
        {
            Console.WriteLine("Selectati optiunea: ");
            Console.WriteLine("1 - Number of rows from the Publisher table (Execute scalar)");
            Console.WriteLine("2 - Top 10 publishers (Id, Name) (SQL Data Reader)");
            Console.WriteLine("3 - Number of books for each publisher (Publiher Name, Number of Books)");
            Console.WriteLine("4 - The total price for books for a publisher");
            Console.WriteLine("5 - Iesire program");
            Console.WriteLine();
            Publisher();
        }

        public static void Publisher()
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.D1))
            {
                NumberOfRows.NrOfRows();
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D2))
            {
                Top10Publishers.TopTenPublishers();
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D3))
            {
                NrOfBookPerPublisher.NrOfBooksPerPublisher();
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D4))
            {
                TotalPrice.TotalPriceOfBooks();
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D5))
            {
                SqlConnection.Dispose();
                return;
            }
            else
            {
                Console.WriteLine("Optiune invalida!");
                Console.WriteLine();
                Publisher();
            }
        }
    }
}
