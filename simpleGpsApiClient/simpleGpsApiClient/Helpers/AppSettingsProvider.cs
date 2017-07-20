using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleGpsApiClient.Helpers
{
    public class AppSettingsProvider
    {
        public string DatabaseConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["GpsRawData"].ConnectionString; }
        }
    }
}
