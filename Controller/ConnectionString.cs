using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataBaseDates.Controller
{
    class ConnectionString
    {
        public static string ConnStr //для виведення рядка-підключення до бази даних
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DataBaseDates.Properties.Settings.ConnStr"].ConnectionString;
            }
        }
    }
}
