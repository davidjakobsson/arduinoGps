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
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;

                    command.Parameters.Add(new SqlParameter("MessageType", gpsRawData.Substring(1, 5)));
                    command.Parameters.Add(new SqlParameter("Data", gpsRawData));
                    command.Parameters.Add(new SqlParameter("Device", "TestDevice"));

                    command.CommandText = "Insert into gprmc (MessageType, Data, Device) values (@MessageType, @Data, @Device)";

                    command.ExecuteNonQuery();

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
