using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceAPI
{
    public class WeatherInfo
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public IEnumerable<Daily> daily { get; set; }
    }
    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
    }

    public class Weather
    {
        public string description { get; set; }
        public string main { get; set; }
    }
    public class Daily
    {
        public Temp temp { get; set; }
        public double humidity { get; set; }
        public IEnumerable<Weather> weather { get; set; }
    }
}
