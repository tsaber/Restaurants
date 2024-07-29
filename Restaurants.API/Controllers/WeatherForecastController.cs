using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, 
        IWeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet]
    [Route("{take}/example")]
    public IEnumerable<WeatherForecast> Get([FromQuery]int max, [FromRoute]int take)
    {
        var result = _weatherForecastService.Get();
        return result;
    }
    [HttpGet("{take}/currentDay")]
    public ObjectResult GetCurrentDayForecast([FromQuery]int max, [FromRoute]int take)
    {
        var result = _weatherForecastService.Get().First();
        //Response.StatusCode = 400;
        return StatusCode(400, result);

    }

    [HttpPost]
    public string Hello([FromBody] string name)
    {
        return $"Hello {name}";
    }
}
