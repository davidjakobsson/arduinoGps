using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netSerialReader
{
    public class AppSettingsProvider
    {
        public string DatabaseConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["GpsRawData"].ConnectionString; }
        }

        public bool SaveRawToDatabase
        {
            get
            {
                bool saveRawData = false;
                string saveRawDataSetting = ConfigurationManager.AppSettings.Get("SaveRawToDatabase");
                Boolean.TryParse(saveRawDataSetting, out saveRawData);

                return saveRawData;

            }
        }
    }
}
