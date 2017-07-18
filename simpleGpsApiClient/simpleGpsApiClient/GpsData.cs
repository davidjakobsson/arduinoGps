using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simpleGpsApiClient
{
    public class GpsData
    {
        public string Device { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? UtcDateTime { get; set; }
        public decimal? SpeedKph { get; set; }
        public decimal? SpeedKnots { get; set; }
        public int? DirectionDegrees { get; set; }
    }
}
