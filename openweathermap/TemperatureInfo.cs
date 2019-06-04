using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openweathermap
{
    class TemperatureInfo
    {
        public float Temp { get; set; }
        public float Pressure { get; set; }
        public float Humidity { get; set; }
    }
    class CloudsInfo
    {
        public float All { get; set; }
    }
    class WindInfo
    {
        public float Speed { get; set; }
    }
    class WeatherInfo
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }
    class SysInfo
    {
        //sys.country Country code(GB, JP etc.)
        //sys.sunrise Sunrise time, unix, UTC
        //sys.sunset Sunset time, unix, UTC
        public string Country { get; set; }
        public double Sunrise { get; set; }
        public double Sunset { get; set; }

        public string ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp).ToString();
        }
    }
}
