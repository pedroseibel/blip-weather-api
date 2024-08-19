using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace WeatherAPI.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["WeatherAPI:ApiKey"]?.Trim() ?? throw new ArgumentNullException(nameof(configuration), "API key is not configured.");
        }

        public async Task<JObject> GetWeatherAsync(string city)
        {
            var response = await _httpClient.GetAsync($"https://api.hgbrasil.com/weather?key={_apiKey}&city_name={city}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to fetch weather data: {response.ReasonPhrase}");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JObject.Parse(content);
        }
    }
}