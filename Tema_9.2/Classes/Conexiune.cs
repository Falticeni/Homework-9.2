using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CrudBookApp.Classes
{
    public class Conexiune
    {
        public static SqlConnection SqlConnection { get; } = new SqlConnection("Data Source =.; Initial Catalog = Week9; Integrated Security = True");
    }
}
