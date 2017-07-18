using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

        public void Post([FromBody]GpsData data)
        {
            int i = 1;
        }

        // POST: api/Gps
        //public void Post([FromBody]string value)
        //{
        //}

    }
}
