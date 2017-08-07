using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Data
{
    internal static class COMMON
    {
        public static String CONNECTION_STRING
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SQL-SERVER"].ConnectionString;
            }
        }
    }
}
