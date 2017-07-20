using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GpsApi.Helpers;
using GpsApi.Models;

namespace GpsApi.Controllers
{
    public class GpsController : ApiController
    {
        // GET: api/Gps
        public GpsData Get()
        {
            GpsData gpsData = new GpsData();
            gpsData.DirectionDegrees = 20;
            gpsData.Device = "exampleDevice";
            gpsData.Latitude = "59.277673°N";
            gpsData.Longitude = "15.211885°E";
            gpsData.SpeedKnots = Decimal.One;
            gpsData.SpeedKph = (gpsData.SpeedKnots * (decimal)1.852);
            gpsData.UtcDateTime = DateTime.UtcNow;
            return gpsData;
        }

        // GET: api/Gps/5
        public string Get(int id)
        {
            return "value";
        }

        public HttpResponseMessage Post([FromBody]GpsData data)
        {
            try
            {
                SaveToDatabase(data);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            
        }

        private void SaveToDatabase(GpsData data)
        {
            AppSettingsProvider appSettingsProvider = new AppSettingsProvider();

            using (SqlConnection connection = new SqlConnection(appSettingsProvider.DatabaseConnectionString))
            {


                try
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;

                    command.Parameters.Add(new SqlParameter("Device", data.Device));
                    command.Parameters.Add(new SqlParameter("Latitude", data.Latitude));
                    command.Parameters.Add(new SqlParameter("Longitude", data.Longitude));
                    if (data.SpeedKnots.HasValue)
                    {
                       command.Parameters.Add(new SqlParameter("SpeedKnots", data.SpeedKnots.Value)); 
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("SpeedKnots", DBNull.Value));
                    }
                    if (data.SpeedKph.HasValue)
                    {
                        command.Parameters.Add(new SqlParameter("SpeedKph", data.SpeedKph.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("SpeedKph", DBNull.Value));
                    }
                    if (data.UtcDateTime.HasValue)
                    {
                        command.Parameters.Add(new SqlParameter("UtcDateTime", data.UtcDateTime));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("UtcDateTime", DBNull.Value));
                    }
                    

                    command.CommandText = "Insert into GpsData (Device, Latitude, Longitude, SpeedKnots, SpeedKph, UtcDateTime) values (@Device, @Latitude, @Longitude, @SpeedKnots, @SpeedKph, @UtcDateTime)";

                    command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    //TODO log?

                    throw e;
                }


            }
        }

        // POST: api/Gps
        //public void Post([FromBody]string value)
        //{
        //}

    }
}
