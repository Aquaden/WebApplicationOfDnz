using Microsoft.AspNetCore.Mvc;

namespace WebApplicationOfDnz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost(Name = "PostWeatherForecast")]
        public WeatherForecast Post(int temp)
        {
            WeatherForecast forecast = new WeatherForecast();
            forecast.Date = DateTime.Now;
            forecast.TemperatureC = temp;
            forecast.Summary = Summaries[0];
            return forecast;
        }

        [HttpDelete(Name = "DeleteWeatherForecast")]
        public string[] Delete(int index)
        {
             Summaries[index] = string.Empty;

            return Summaries;
        }
        [HttpPut(Name = "PutWeatherForecast")]
        public string[] Put(int index)
        {
            Summaries[index] = "Updated";

            return Summaries;

        }


    }
}