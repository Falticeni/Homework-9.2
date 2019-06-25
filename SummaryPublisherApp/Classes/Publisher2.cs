using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp.Classes
{
    public class Publisher2
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public decimal TotalPriceOfBooks { get; set; }

        internal void Print()
        {
            Console.WriteLine($"PublisherId = {PublisherId}, Name = {Name}, TotalPriceOfBooks = {TotalPriceOfBooks}\n");
        }
    }
}
