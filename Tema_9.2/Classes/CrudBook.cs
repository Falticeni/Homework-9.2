using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CrudBookApp.Classes
{
    public class CrudBook : Conexiune
    {
        //Print the inserted id (Execute scalar with select identity):        
        public static void InsertBook(string title, int publisherId, int year, decimal price)
        {
            //SQLQuery
            string insert = "Insert into Book (Title, PublisherId, Year, Price)" +
                            "Values (@Title, @PublisherId, @Year, @Price)" +
                            "Select Cast (scope_identity() as int)";

            //Command
            SqlCommand insertnewBook = new SqlCommand(insert, SqlConnection);

            //Parameter's initialization
            SqlParameter Title = new SqlParameter { ParameterName = "Title", SqlDbType = SqlDbType.VarChar, Value = title };
            SqlParameter PublisherId = new SqlParameter { ParameterName = "PublisherId", SqlDbType = SqlDbType.Int, Value = publisherId };
            SqlParameter Year = new SqlParameter { ParameterName = "Year", SqlDbType = SqlDbType.Int, Value = year };
            SqlParameter Price = new SqlParameter { ParameterName = "Price", SqlDbType = SqlDbType.Decimal, Value = price };

            //Add Parameters to command
            insertnewBook.Parameters.Add(Title);
            insertnewBook.Parameters.Add(PublisherId);
            insertnewBook.Parameters.Add(Year);
            insertnewBook.Parameters.Add(Price);

            try
            {
                SqlConnection.Open(); // open connection
                var bId = insertnewBook.ExecuteScalar();
                Console.WriteLine("Cartea cu Id-ul {0} a fost adaugata in baza de date.", bId);
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


        //Update a book(read id from console):
        public static void UpdateTitle(SqlParameter BookId)
        {
            //SQLQuery
            string update = "Update Book " +
                            "Set Title = @Title " +
                            "Where BookId = @BookId ";
            //Command
            SqlCommand updateTitle = new SqlCommand(update, SqlConnection);

            Console.WriteLine("Introduceti noul titlu de carte: ");
            string updatedTitle = Console.ReadLine();
            //Parameter's initialization
            SqlParameter UpdateTitle = new SqlParameter { ParameterName = "Title", SqlDbType = SqlDbType.VarChar, Value = updatedTitle };

            //Add Parameters to command
            updateTitle.Parameters.Add(BookId);
            updateTitle.Parameters.Add(UpdateTitle);

            try
            {
                SqlConnection.Open(); // open connection
                updateTitle.ExecuteNonQuery();
                Console.WriteLine("Titlul cartii cu id-ul {0} a fost actualizat.", BookId.Value);
            }
            catch
            {
                Console.WriteLine("Nu exista un asemenea Id de carte in baza de date.");
            }
            finally
            {
                SqlConnection.Close(); // close connection
            }
        }
        public static void UpdatePublisherId(SqlParameter BookId)
        {
            //SQLQuery
            string update = "Update Book " +
                           "Set PublisherId = @PublisherId " +
                            "Where BookId = @BookId ";
            //Command
            SqlCommand updatePublisherId = new SqlCommand(update, SqlConnection);

            Console.WriteLine("Actualizati PublisherId: ");
            int updatedPublisherId = Convert.ToInt16(Console.ReadLine());
            //Parameter's initialization
            SqlParameter UpdatePublisherId = new SqlParameter { ParameterName = "PublisherId", SqlDbType = SqlDbType.Int, Value = updatedPublisherId };

            //Add Parameters to command
            updatePublisherId.Parameters.Add(BookId);
            updatePublisherId.Parameters.Add(UpdatePublisherId);

            try
            {
                SqlConnection.Open(); // open connection
                updatePublisherId.ExecuteNonQuery();
                Console.WriteLine("PublisherId-ul cartii cu id-ul {0} a fost actualizat.", BookId.Value);
            }
            catch
            {
                Console.WriteLine("Nu exista un asemenea Id de carte in baza de date.");
            }
            finally
            {
                SqlConnection.Close(); // close connection
            }
        }
        public static void UpdateYear(SqlParameter BookId)
        {
            //SQLQuery
            string update = "Update Book " +
                            "Set Year = @Year " +
                            "Where BookId = @BookId ";
            //Command
            SqlCommand updateYear = new SqlCommand(update, SqlConnection);

            Console.WriteLine("Introduceti noul an actualizat: ");
            int updatedYear = Convert.ToInt16(Console.ReadLine());
            //Parameter's initialization
            SqlParameter UpdateYear = new SqlParameter { ParameterName = "Year", SqlDbType = SqlDbType.Int, Value = updatedYear };

            //Add Parameters to command
            updateYear.Parameters.Add(BookId);
            updateYear.Parameters.Add(UpdateYear);

            try
            {
                SqlConnection.Open(); // open connection
                updateYear.ExecuteNonQuery();
                Console.WriteLine("Anul cartii cu id-ul {0} a fost actualizat.", BookId.Value);
            }
            catch
            {
                Console.WriteLine("Nu exista un asemenea Id de carte in baza de date.");
            }
            finally
            {
                SqlConnection.Close(); // close connection
            }
        }
        public static void UpdatePrice(SqlParameter BookId)
        {
            //SQLQuery
            string update = "Update Book " +
                            "Set Price = @Price " +
                            "Where BookId = @BookId ";
            //Command
            SqlCommand updatePrice = new SqlCommand(update, SqlConnection);

            Console.WriteLine("Introduceti noul pret actualizat: ");
            int updatedPrice = Convert.ToInt16(Console.ReadLine());
            //Parameter's initialization
            SqlParameter UpdatePrice = new SqlParameter { ParameterName = "Price", SqlDbType = SqlDbType.Int, Value = updatedPrice };

            //Add Parameters to command
            updatePrice.Parameters.Add(BookId);
            updatePrice.Parameters.Add(UpdatePrice);

            try
            {
                SqlConnection.Open(); // open connection
                updatePrice.ExecuteNonQuery();
                Console.WriteLine("Pretul cartii cu id-ul {0} a fost actualizat.", BookId.Value);
            }
            catch
            {
                Console.WriteLine("Nu exista un asemenea Id de carte in baza de date.");
            }
            finally
            {
                SqlConnection.Close(); // close connection
            }
        }


        //Delete a book(read id from console):
        public static void DeleteBook(SqlParameter BookId)
        {
            //SQLQuery
            string delete = "Delete from Book " +
                            "Where BookId = @BookId ";
            //Command
            SqlCommand deleteBook = new SqlCommand(delete, SqlConnection);

            //Add Parameter to command
            deleteBook.Parameters.Add(BookId);

            try
            {
                SqlConnection.Open(); // open connection
                deleteBook.ExecuteNonQuery();
                Console.WriteLine("Cartea cu id-ul {0} a fost stearsa.", BookId.Value);
            }
            catch
            {
                Console.WriteLine("Nu exista un asemenea Id de carte in baza de date.");
            }
            finally
            {
                SqlConnection.Close(); // close connection
            }
        }

        
        //Select a book(read id from console):
        public static void ReadBook(SqlParameter BookId)
        {
            //SQLQuery
            string read = "Select * from Book " +
                          "Where BookId = @BookId ";

            //Command
            SqlCommand readBook = new SqlCommand(read, SqlConnection);

            //Add Parameter to command
            readBook.Parameters.Add(BookId);

            try
            {
                SqlConnection.Open(); // open connection
                SqlDataReader book = readBook.ExecuteReader();
                while (book.Read())
                {
                    Console.WriteLine($"Book Id: {book["BookId"]}");
                    Console.WriteLine($"Title: {book["Title"]}");
                    Console.WriteLine($"Publisher Id: {book["PublisherId"]}");
                    Console.WriteLine($"Year: {book["Year"]}");
                    Console.WriteLine($"Pret: {book["Price"]}");
                }
            }
            catch
            {
                Console.WriteLine("Nu exista un asemenea Id de carte in baza de date.");
            }
            finally
            {
                SqlConnection.Close(); // close connection
            }
        }
    }
}
