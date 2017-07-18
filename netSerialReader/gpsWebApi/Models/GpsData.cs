using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace gpsWebApi.Models
{
    public class GpsData
    {
        [Required]
        public string Device { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? UtcDateTime { get; set; }
        public decimal? SpeedKph { get; set; }
        public decimal? SpeedKnots { get; set; }
        public int? DirectionDegrees { get; set; }
    }
}