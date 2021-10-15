using Forte.Weather.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    /// <param name="days">Number of days you want weather forcast</param>
    /// <returns>List with forecast</returns>
    [HttpGet("{days}")]
    public async Task<IEnumerable<WeatherModel>> Get(int days = 5)
    {
        return await _weatherService.WeatherForcast(days);
    }
}
