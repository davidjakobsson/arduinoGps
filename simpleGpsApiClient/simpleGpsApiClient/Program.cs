using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

            var gpsData = GetGpsExampleAsync("api/gps");

            Console.ReadLine();
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
