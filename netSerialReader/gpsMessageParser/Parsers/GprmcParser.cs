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
            gpsData.UtcDateTime = ParseUtcDate(gprmcArray[1], gprmcArray[9]);
            gpsData.SpeedKnots = ParseSpeedKnots(gprmcArray[7]);
            gpsData.SpeedKph = ConvertKnotsToKph(gpsData.SpeedKnots);

            return gpsData;
        }

        private decimal? ConvertKnotsToKph(decimal? speedKnots)
        {
            if (speedKnots != null)
            {
                decimal knots = speedKnots.Value;
                return knots * (decimal)1.852;
            }
            return null;
        }

        private decimal? ParseSpeedKnots(string knotsString)
        {
            if (!string.IsNullOrEmpty(knotsString))
            {
                decimal knots;
                if (decimal.TryParse(knotsString, style, culture, out knots))
                {
                    return knots;
                }
            }
            return null;

        }

        private DateTime? ParseUtcDate(string timeString, string dateString)
        {
            try
            {
                int day = Convert.ToInt32(dateString.Substring(0, 2)); 
                int month = Convert.ToInt32(dateString.Substring(2, 2));
                int year = Convert.ToInt32("20" + dateString.Substring(4, 2));

                int hour = Convert.ToInt32(timeString.Substring(0, 2));
                int minute = Convert.ToInt32(timeString.Substring(2, 2));
                int second = Convert.ToInt32(timeString.Substring(4, 2));
                
                return new DateTime(year, month, day, hour, minute, second);

            }
            catch (Exception e)
            {
                //TODO LOG?
                
            }
            return null;
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
