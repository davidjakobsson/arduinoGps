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


            gpsData.DirectionDegrees = ParseDegrees(gprmcArray[8]);
            

            return gpsData;
        }

        private int? ParseDegrees(string degreesString)
        {
            decimal degrees;
            if (decimal.TryParse(degreesString, style, culture, out degrees))
            {
                degrees = Math.Round(degrees);
                return Convert.ToInt32(degrees);
            }
            return null;
        }
    }
}
