using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummaryPublisherApp.Classes;



namespace NrOfBooks
{
    class Program : NrOfBookPerPublisher
    {
        static void Main(string[] args)
        {
            NrOfBooksPerPublisher();
            Console.ReadKey();
        }
    }
}
