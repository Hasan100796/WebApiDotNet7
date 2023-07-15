using Microsoft.AspNetCore.Mvc;

namespace WebApiDotNet7.Controllers
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
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet(Name ="GetTest")]
        //public List<WeatherForecast> GetData()
        //{
        //    List<WeatherForecast> list = new List<WeatherForecast>();
        //    list.Add(new WeatherForecast
        //    {
        //        Date= DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
        //        TemperatureC= Random.Shared.Next(-20,55),
        //        Summary = Summaries[0],

        //    });
        //    return list;
           
        //}
    }
}