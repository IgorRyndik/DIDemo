using DIDemoWebAPI.Logging;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DIDemoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        /// <summary>
        /// Отримання залежності за допомогою властивості 
        /// </summary>
        [FromServices]
        public IMyLogger MyLogger { get; set; }

        private readonly IMyLogger _logger;

        /// <summary>
        /// Один із способів отримання залежності за допомогою конструктора
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(IMyLogger logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.Log("Отримання залежностi через конструктор");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetWeatherForecastByMethod")]
        public IEnumerable<WeatherForecast> GetByMethod([FromServices] IMyLogger logger)
        {
            logger.Log("Отримання залежностi через аргумент методу");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetWeatherForecastByContext")]
        public IEnumerable<WeatherForecast> GetByContext()
        {
            var logger = HttpContext.RequestServices.GetService<IMyLogger>();
            logger?.Log("Отримання залежностi за допомогою контексту");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetWeatherForecastByProperty")]
        public IEnumerable<WeatherForecast> GetByProperty()
        {
            MyLogger.Log("Отримання залежностi за допомогою властивостi");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}