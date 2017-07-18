using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gpsWebApi.Models;

namespace gpsWebApi.Controllers
{
    public class GpsController : Controller
    {


        // POST: Gps/Create
        [HttpPost]
        public void Post(GpsData position)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            
        }

        [HttpGet]
        public GpsData GetExample()
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

        
    }
}
