using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gpsMessageParser.Entities
{
    public class GpsData
    {
        public string Latitude { get; set; }
        public string  Longitude { get; set; }
        public DateTime UtcDateTime { get; set; }
        public double SpeedKph { get; set; }
        public double SpeedKnots { get; set; }
        public int DirectionDegrees { get; set; }
    }
}
