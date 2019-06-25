using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CrudBookApp.Classes;

namespace SummaryBookApp.Classes
{
    public class IOHandler : Conexiune
    {
        public static void Menu()
        {
            Console.WriteLine("Selectati optiunea: ");
            Console.WriteLine("1 - All the books that are published in 2005");
            Console.WriteLine("2 - The book that is published in the max year (can use multiple commands)");
            Console.WriteLine("3 - Top 10 books (Title, Year, Price)");
            Console.WriteLine("4 - Iesire program");
            Console.WriteLine();
            BookApp();
        }

        public static void BookApp()
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.D1))
            {
                BookPublishedIn2005.Book2005();
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D2))
            {
                BookPublishedInTheMaxYear.MaxYear();
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D3))
            {
                Top10Books.TopTenBooks();
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D4))
            {
                SqlConnection.Dispose();
                return;
            }
            else
            {
                Console.WriteLine("Optiune invalida!");
                Console.WriteLine();
                BookApp();
            }
        }
    }
}
