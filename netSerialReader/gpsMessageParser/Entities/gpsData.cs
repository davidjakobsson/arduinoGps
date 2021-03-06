﻿using System;
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
        public DateTime? UtcDateTime { get; set; }
        public decimal? SpeedKph { get; set; }
        public decimal? SpeedKnots { get; set; }
        public int? DirectionDegrees { get; set; }

        public GpsData()
        {
            Latitude = null;
            Longitude = null;
            UtcDateTime = null;
            SpeedKph = null;
            SpeedKnots = null;
            DirectionDegrees = null;
        }
    }
}
