using Forte.Weather.Services;
using Microsoft.AspNetCore.Mvc;

namespace Forte.Weather.Api.Controllers;
[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    /// <summary>
    /// Return weather forecast for the next 5 days
    /// </summary>
    /// <returns>List with weather forcast</returns>
    [HttpGet("{days}")]
    public async Task<IEnumerable<WeatherModel>> Get(int days)
    {
        return await _weatherService.WeatherForcast(days);
    }
}
