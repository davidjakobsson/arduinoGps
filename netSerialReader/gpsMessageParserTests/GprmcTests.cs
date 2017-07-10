using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gpsMessageParser.Parsers;
using Xunit;

namespace gpsMessageParserTests
{
    public class GprmcTests
    {

        [Fact]
        public void ParseGprmc()
        {
            string gprmcMessage = "$GPRMC,115850.000,A,5916.6604,N,01512.7131,E,0.18,186.99,070717,,,A*6A";

            var gprmcParser = new GprmcParser();

            var gpsData = gprmcParser.ParseGprmc(gprmcMessage);
            Assert.Equal("59.277673°N", gpsData.Latitude);
            Assert.Equal("15.211885°E", gpsData.Longitude);
            Assert.Equal(187, gpsData.DirectionDegrees);
            Assert.Equal(0.2, gpsData.SpeedKnots);
            Assert.Equal(0.2*1.852, gpsData.SpeedKph);

            Assert.Equal(11, gpsData.UtcDateTime.Value.Hour);
            Assert.Equal(58, gpsData.UtcDateTime.Value.Minute);
            Assert.Equal(50, gpsData.UtcDateTime.Value.Second);
            Assert.Equal(7, gpsData.UtcDateTime.Value.Day);
            Assert.Equal(7, gpsData.UtcDateTime.Value.Month);
            Assert.Equal(2017, gpsData.UtcDateTime.Value.Year);

        }

        [Fact]
        public void ParseTimeGprmc()
        {
            string gprmcMessage = "$GPRMC,115850.000,A,5916.6604,N,01512.7131,E,0.18,186.99,070717,,,A*6A";

            var gprmcParser = new GprmcParser();

            var gpsData = gprmcParser.ParseGprmc(gprmcMessage);

            Assert.Equal(11, gpsData.UtcDateTime.Value.Hour);
            Assert.Equal(58, gpsData.UtcDateTime.Value.Minute);
            Assert.Equal(50, gpsData.UtcDateTime.Value.Second);


        }

        [Fact]
        public void ParseDateGprmc()
        {
            string gprmcMessage = "$GPRMC,115850.000,A,5916.6604,N,01512.7131,E,0.18,186.99,070717,,,A*6A";

            var gprmcParser = new GprmcParser();

            var gpsData = gprmcParser.ParseGprmc(gprmcMessage);
            Assert.Equal(7, gpsData.UtcDateTime.Value.Day);
            Assert.Equal(7, gpsData.UtcDateTime.Value.Month);
            Assert.Equal(2017, gpsData.UtcDateTime.Value.Year);

        }

        [Fact]
        public void ParseDirectionGprmc()
        {
            string gprmcMessage = "$GPRMC,115850.000,A,5916.6604,N,01512.7131,E,0.18,186.99,070717,,,A*6A";

            var gprmcParser = new GprmcParser();

            var gpsData = gprmcParser.ParseGprmc(gprmcMessage);

            Assert.Equal(187, gpsData.DirectionDegrees);

        }

        [Fact]
        public void ParseSpeedGprmc()
        {
            string gprmcMessage = "$GPRMC,115850.000,A,5916.6604,N,01512.7131,E,0.18,186.99,070717,,,A*6A";

            var gprmcParser = new GprmcParser();

            var gpsData = gprmcParser.ParseGprmc(gprmcMessage);

            Assert.Equal(0.18, gpsData.SpeedKnots);
            Assert.Equal(0.18 * 1.852, gpsData.SpeedKph);


        }

        [Fact]
        public void ParseLongitudeGprmc()
        {
            string gprmcMessage = "$GPRMC,115850.000,A,5916.6604,N,01512.7131,E,0.18,186.99,070717,,,A*6A";

            var gprmcParser = new GprmcParser();

            var gpsData = gprmcParser.ParseGprmc(gprmcMessage);
            Assert.Equal("15.211885°E", gpsData.Longitude);


        }

        [Fact]
        public void ParseLatitudeGprmc()
        {
            string gprmcMessage = "$GPRMC,115850.000,A,5916.6604,N,01512.7131,E,0.18,186.99,070717,,,A*6A";

            var gprmcParser = new GprmcParser();

            var gpsData = gprmcParser.ParseGprmc(gprmcMessage);
            Assert.Equal("59.277673°N", gpsData.Latitude);


        }

    }
}
