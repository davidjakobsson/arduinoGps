using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using gpsMessageParser.Parsers;
using simpleGpsApiClient.Helpers;

namespace simpleGpsApiClient
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            
            RunAsync().Wait();
           
            
        }
        static async Task RunAsync()
        {

            client.BaseAddress = new Uri("http://localhost:41365/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GpsData gpsExample = CreateExampleData();
            HttpResponseMessage response = await client.PostAsJsonAsync("api/gps", gpsExample);

            //var gpsDataToSend = GetDataFromRaw();

            //foreach (var gpsData in gpsDataToSend)
            //{
            //    HttpResponseMessage response = await client.PostAsJsonAsync("api/gps", gpsData);
            //}

            //var gpsData = GetGpsExampleAsync("api/gps");

            Console.ReadLine();
        }

        private static List<GpsData> GetDataFromRaw()
        {
            List<GpsData> gpsData = new List<GpsData>();
            GprmcParser parser = new GprmcParser();

            AppSettingsProvider appSettingsProvider = new AppSettingsProvider();

            using (SqlConnection connection = new SqlConnection(appSettingsProvider.DatabaseConnectionString))
            {

                //GetRawData
                try
                {
                    SqlCommand command = new SqlCommand();
                    connection.Open();
                    command.Connection = connection;


                    command.Parameters.Add(new SqlParameter("MessageType", "GPRMC"));

                    command.CommandText = "select Id, MessageType, Data, Device, Parsed from gprmc where Parsed = 0 and MessageType = @MessageType";

                    var reader = command.ExecuteReader();
                    int i = 0;
                    while (reader.Read() && i < 100)
                    {
                        var dataString = reader.GetString(reader.GetOrdinal("Data"));
                        var parsedGpsData = parser.ParseGprmc(dataString);
                        var device = reader.GetString(reader.GetOrdinal("Device"));
                        GpsData gpsDataToSend = new GpsData(device, parsedGpsData.Latitude, parsedGpsData.Longitude, parsedGpsData.UtcDateTime, parsedGpsData.SpeedKph, parsedGpsData.SpeedKnots, parsedGpsData.DirectionDegrees);
                        gpsData.Add(gpsDataToSend);
                        i++;
                    }


                }
                catch (Exception e)
                {
                    //TODO log?

                    //throw e;
                    return gpsData;
                }


            }

            throw new NotImplementedException();
        }


        static async Task<GpsData> GetGpsExampleAsync(string path)
        {
            GpsData gpsData = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                gpsData = await response.Content.ReadAsAsync<GpsData>();
            }
            return gpsData;
        }

        private static GpsData CreateExampleData()
        {
            GpsData gpsData = new GpsData();
            gpsData.DirectionDegrees = 22;
            gpsData.Device = "exampleDevice2";
            gpsData.Latitude = "59.277672°N";
            gpsData.Longitude = "15.211888°E";
            gpsData.SpeedKnots = Decimal.One;
            gpsData.SpeedKph = (gpsData.SpeedKnots * (decimal)1.852);
            gpsData.UtcDateTime = DateTime.UtcNow;
            return gpsData;
        }
    }
}
