using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netSerialReader.Database
{
    public class GpsRawData
    {


        public void SaveGpsRawData(string gpsRawData)
        {

            AppSettingsProvider appSettingsProvider = new AppSettingsProvider();

            using (SqlConnection connection = new SqlConnection(appSettingsProvider.DatabaseConnectionString))
            {


                try
                {
                    //SqlCommand command = new SqlCommand();
                    //connection.Open();
                    //command.Connection = connection;

                    //command.CommandText = "select Id, Name, Description, Created, LastModified from ContactType ";


                    //SqlDataReader reader = command.ExecuteReader();

                    

                }
                catch (Exception e)
                {
                    //TODO log?

                    throw e;
                }


            }




        }

    }
}
