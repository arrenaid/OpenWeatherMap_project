using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openweathermap
{
    //use
    class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public CloudsInfo Clouds { get; set; }
        public WindInfo Wind { get; set; }
        public SysInfo Sys { get; set; }
        public List<WeatherInfo> Weather { get; set; }
        public string Name { get; set; }
    }

    //use
    class FiveDayWeatherResponse
    {
        public float Cnt { get; set; }
        public CityInfo City { get; set; }
        public List<ListFiveDayWeatherResponse> List { get; set; }
        
    }


    class ListFiveDayWeatherResponse
    {
        public float Dt { get; set; }
        public string Dt_txt { get; set; }
        public TemperatureInfo Main { get; set; }
        public CloudsInfo Clouds { get; set; }
        public WindInfo Wind { get; set; }
        public List<WeatherInfo> Weather { get; set; }
    }

    class CityInfo
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public float Id { get; set; }
    }
}

