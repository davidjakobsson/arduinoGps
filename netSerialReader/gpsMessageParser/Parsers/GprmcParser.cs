using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gpsMessageParser.Entities;

namespace gpsMessageParser.Parsers
{
    public class GprmcParser
    {
        private NumberStyles style = NumberStyles.AllowDecimalPoint;
        private CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
        public GpsData ParseGprmc(string gprmcString)
        {
            var gprmcArray = gprmcString.Split(',');

            GpsData gpsData = new GpsData();
            
            decimal degrees;
            if (decimal.TryParse(gprmcArray[8], style, culture, out degrees))
            {
                degrees = Math.Round(degrees);
                gpsData.DirectionDegrees = Convert.ToInt32(degrees);
            }


            return gpsData;
        }
    }
}
