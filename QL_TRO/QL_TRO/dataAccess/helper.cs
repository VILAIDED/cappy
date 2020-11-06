using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace QL_TRO.dataAccess
{
    public class helper
    {
        public static string ConnectString()
        {
            return ConfigurationManager.ConnectionStrings["sql_connect"].ToString();
        }

      
    }
}
