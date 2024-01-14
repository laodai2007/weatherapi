using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WeatherApp.Infrastructure;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    //private static readonly string[] Summaries = new[]
    //{
    //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //};

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherInfoService _weatherInfoService;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherInfoService weatherInfoService)
    {
        _logger = logger;
        _weatherInfoService = weatherInfoService;
    }

    //[HttpGet(Name = "GetWeatherForecast")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}

    [HttpGet("{code}", Name = "GetWeatherForecast")]
    public async Task<IActionResult> GetWeatherByCode(string code)
    {
        var result = _weatherInfoService.GetWeatherInfos(code);

        if (result != null)
        {
            return Ok(result);
        }
        return StatusCode(500);
    }
}