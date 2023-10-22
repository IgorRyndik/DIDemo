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
        /// ��������� ��������� �� ��������� ���������� 
        /// </summary>
        [FromServices]
        public IMyLogger MyLogger { get; set; }

        private readonly IMyLogger _logger;

        /// <summary>
        /// ���� �� ������� ��������� ��������� �� ��������� ������������
        /// </summary>
        /// <param name="logger"></param>
        public WeatherForecastController(IMyLogger logger)
        {
            _logger = logger;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.Log("��������� ���������i ����� �����������");
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
            logger.Log("��������� ���������i ����� �������� ������");
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
            logger?.Log("��������� ���������i �� ��������� ���������");
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
            MyLogger.Log("��������� ���������i �� ��������� ����������i");
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