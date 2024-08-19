using Microsoft.AspNetCore.Mvc;
using WeatherAPI.Services;
using Newtonsoft.Json.Linq;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherForecastController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            try
            {
                var weatherData = await _weatherService.GetWeatherAsync(city);
                return Content(weatherData.ToString(), "application/json");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}