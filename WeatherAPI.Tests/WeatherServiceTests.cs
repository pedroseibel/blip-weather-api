using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Newtonsoft.Json.Linq;
using WeatherAPI.Services;
using Xunit;

public class WeatherServiceTests
{
    private readonly WeatherService _weatherService;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;

    public WeatherServiceTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        var configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            { "WeatherAPI:ApiKey", "test_api_key" }
        }).Build();

        _weatherService = new WeatherService(httpClient, configuration);
    }

    [Fact]
    public async Task GetWeatherAsync_ReturnsWeatherData()
    {
        var city = "London";
        var responseContent = new JObject { { "temperature", "20" } }.ToString();
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            });

        var result = await _weatherService.GetWeatherAsync(city);

        Assert.NotNull(result["temperature"]);
        Assert.Equal("20", result["temperature"]?.ToString());
    }
}