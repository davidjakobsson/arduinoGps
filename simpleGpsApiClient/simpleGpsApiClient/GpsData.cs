using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleGpsApiClient
{
    public class GpsData
    {
        public GpsData()
        {
            
        }

        public GpsData(string device, string latitude, string longitude, DateTime? utcDateTime, decimal? speedKph, decimal? speedKnots, int? directionDegrees)
        {
            Device = device;
            Latitude = latitude;
            Longitude = longitude;
            UtcDateTime = utcDateTime;
            SpeedKph = speedKph;
            SpeedKnots = speedKnots;
            DirectionDegrees = directionDegrees;
        }

        public GpsData(int id, string device, string latitude, string longitude, DateTime? utcDateTime, decimal? speedKph, decimal? speedKnots, int? directionDegrees)
        {
            Id = id;
            Device = device;
            Latitude = latitude;
            Longitude = longitude;
            UtcDateTime = utcDateTime;
            SpeedKph = speedKph;
            SpeedKnots = speedKnots;
            DirectionDegrees = directionDegrees;
        }

        public int Id { get; set; }
        public string Device { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? UtcDateTime { get; set; }
        public decimal? SpeedKph { get; set; }
        public decimal? SpeedKnots { get; set; }
        public int? DirectionDegrees { get; set; }
    }
}
