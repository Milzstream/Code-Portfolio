using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Business.Library
{
    internal static class COMMON
    { 
        public static String EMAIL_SERVER
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["emailServer"].ConnectionString;
            }
        }

        public static String EMAIL_USERNAME
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["emailUsername"].ConnectionString;
            }
        }

        public static String EMAIL_PASSWORD
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["emailPassword"].ConnectionString;
            }
        }
    }
}
