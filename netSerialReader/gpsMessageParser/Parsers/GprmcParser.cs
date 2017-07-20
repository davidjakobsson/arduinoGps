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

            gpsData.Latitude = ParseLatLong(gprmcArray[3], gprmcArray[4]);
            gpsData.Longitude = ParseLatLong(gprmcArray[5], gprmcArray[6]);

            return gpsData;
        }

        private string ParseLatLong(string nmeaDegreesAndMinutes, string hemisphere)
        {
            string degrees = NmeaToDegreesParser(nmeaDegreesAndMinutes);
            string returnvalue = degrees + "°";
            if (!string.IsNullOrEmpty(hemisphere))
            {
                returnvalue = returnvalue + hemisphere;
            }
            return returnvalue;
            
        }

        private string NmeaToDegreesParser(string nmeaDegreesAndMinutes)
        {
            //The format for NMEA coordinates is (d)ddmm.mmmm
            //d = degrees and m = minutes
            //There are 60 minutes in a degree so divide the minutes by 60 and add that to the degrees.

            decimal decimalMinutes;
            decimal decimalDegrees;

            try
            {
                var nmeaArray = nmeaDegreesAndMinutes.Split('.');

                string degrees = string.Empty;
                string minutes = string.Empty;

                switch (nmeaArray[0].Length)
                {
                    case 3:
                        degrees = nmeaArray[0].Substring(0, 1);
                        minutes = nmeaArray[0].Substring(1, 2) + '.' + nmeaArray[1];
                        break;
                    case 4:
                        degrees = nmeaArray[0].Substring(0, 2);
                        minutes = nmeaArray[0].Substring(2, 2) + '.' + nmeaArray[1];
                        break;
                    case 5:
                        degrees = nmeaArray[0].Substring(0, 3);
                        minutes = nmeaArray[0].Substring(3, 2) + '.' + nmeaArray[1];
                        break;

                    default:
                        try
                        {
                            minutes = nmeaArray[0] + '.' + nmeaArray[1];
                        }
                        catch (Exception e)
                        {
                            //Some error, log or fix
                            minutes = string.Empty;
                        }
                        
                        break;

                }

                if (!string.IsNullOrEmpty(degrees))
                {
                    if (decimal.TryParse(degrees, style, culture, out decimalDegrees) &&  decimal.TryParse(minutes, style, culture, out decimalMinutes))
                    {
                        return Convert.ToString(Math.Round(decimalDegrees + (decimalMinutes / 60), 6), culture);
                    }
                }
                else
                {
                    if (decimal.TryParse(minutes, style, culture, out decimalMinutes))
                    {
                        return Convert.ToString(Math.Round((decimalMinutes / 60), 6), culture);
                    }
                }

            }
            catch (Exception e)
            {
                //TODO Log?
                Console.WriteLine(e);
                throw;
            }


            return null;
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
