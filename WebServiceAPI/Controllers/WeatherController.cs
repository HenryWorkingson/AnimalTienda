using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebServiceAPI.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> City(string city)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid=280fcf18f77436c9a2269afd60a10d81&units=metric");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    return Ok(new
                    {
                        Temp = rawWeather.Main.Temp,
                        Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                        City = rawWeather.Name,
                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Forecast4Days()
        {
            double lat = 40.416775;
            double lon = -3.703790;
            using (var client = new HttpClient())
            {
                try
                {
                    string key = "280fcf18f77436c9a2269afd60a10d81";
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync($"data/2.5/onecall?lat={lat}&lon={lon}&appid={key}");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    WeatherInfo weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(stringResult);
                    //var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    List<Double> Humedad = new List<double>();
                    List<Temp> temps = new List<Temp>();
                    List<IEnumerable<Weather>> weathers = new List<IEnumerable<Weather>>();
                    foreach (var z in weatherInfo.daily)
                    {
                        Humedad.Add(z.humidity);
                        temps.Add(z.temp);
                        weathers.Add(z.weather);
                    }
                    return Ok(new
                    {
                        //Lon=weatherInfo.Daily.First().lon,
                        //Lat=weatherInfo.Daily.First().lat,
                        //Humedad=weatherInfo.Daily.First().humidity,
                        Lat = weatherInfo.lat,
                        Lon = weatherInfo.lon,
                        Humedad,
                        temps,
                        weathers
                        
                        //Summary = string.Join(",", weatherInfo.Daily.Select(x => x.weather)),
                        
                    });
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                }
            }
        }
    }
}
