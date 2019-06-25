using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace CrudBookApp.Classes
{
    class IOHandler : Conexiune
    {
        public static SqlParameter ReadId()
        {
            Console.WriteLine("Book id: ");
            int bookId = Convert.ToInt32(Console.ReadLine());
            SqlParameter p_bookId = new SqlParameter
            {
                ParameterName = "BookId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = bookId
            };

            return p_bookId;
        }

        public static void Menu()
        {
            Console.WriteLine("Selectati optiunea: ");
            Console.WriteLine("1 - Adauga carte");
            Console.WriteLine("2 - Actualizare titlu carte");
            Console.WriteLine("3 - Actualizare Id editura");
            Console.WriteLine("4 - Actualizare an");
            Console.WriteLine("5 - Actualizare pret");
            Console.WriteLine("6 - Stergeti o carte");
            Console.WriteLine("7 - Afisati informatiile despre o carte");
            Console.WriteLine("8 - Iesire program");
            Console.WriteLine();
            UpdateBook();
        }

        public static void UpdateBook()
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);

            if (cki.Key.Equals(ConsoleKey.D1))
            {
                Console.WriteLine("Introduceti un titlu: ");
                string title = Console.ReadLine();
                Console.WriteLine("Introduceti un publisherId: ");
                int publisherId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Introduceti anul lansarii cartii: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Introduceti pretul cartii: ");
                decimal price = Convert.ToInt32(Console.ReadLine());
                CrudBook.InsertBook(title, publisherId, year, price);
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D2))
            {
                SqlParameter p_bookId = ReadId();
                CrudBook.UpdateTitle(p_bookId);
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D3))
            {
                SqlParameter p_bookId = ReadId();
                CrudBook.UpdatePublisherId(p_bookId);
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D4))
            {
                SqlParameter p_bookId = ReadId();
                CrudBook.UpdateYear(p_bookId);
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D5))
            {
                SqlParameter p_bookId = ReadId();
                CrudBook.UpdatePrice(p_bookId);
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D6))
            {
                SqlParameter p_bookId = ReadId();
                CrudBook.DeleteBook(p_bookId);
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D7))
            {
                SqlParameter p_bookId = ReadId();
                CrudBook.ReadBook(p_bookId);
                Console.WriteLine();
                Menu();
            }
            else if (cki.Key.Equals(ConsoleKey.D8))
            {
                SqlConnection.Dispose();
                return;
            }
            else
            {
                Console.WriteLine("Optiune invalida!");
                Console.WriteLine();
                UpdateBook();
            }
        }
    }
}
