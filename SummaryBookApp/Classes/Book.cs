using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBookApp.Classes
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        internal void Print()
        {
            Console.WriteLine($"BookId = {BookId}, Title = {Title}, PublisherId = {PublisherId}, Year = {Year}, Price = {Price}\n");
        }
    }
}
