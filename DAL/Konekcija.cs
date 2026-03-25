using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    internal class Konekcija
    {
        public static SqlConnection GetKonekcija()
        {
            string connStr = ConfigurationManager.ConnectionStrings["FilmoviDB"].ConnectionString;
            return new SqlConnection(connStr);
        }
    }
}
