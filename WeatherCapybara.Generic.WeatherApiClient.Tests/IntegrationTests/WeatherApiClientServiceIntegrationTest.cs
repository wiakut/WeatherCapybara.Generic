using Microsoft.Extensions.Logging;
using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.Helpers.Contants;
using WeatherCapybara.Generic.WeatherApiClient.Services;
using Xunit;

namespace WeatherCapybara.Generic.WeatherApiClient.Tests.IntegrationTests;

public class WeatherApiClientServiceIntegrationTest : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly WeatherApiClientService _weatherApiClientService;

    public WeatherApiClientServiceIntegrationTest()
    {
        _httpClient = new HttpClient
        {
            DefaultRequestHeaders =
            {
                {ApiClientConstants.RapidClientApiKeyHeaderKey, "a383d65229mshef9ddd92b69e9f9p115938jsnf7c823904f4a"},
                {ApiClientConstants.RapidClientApiHostHeaderKey, "weatherapi-com.p.rapidapi.com"}
            },
            BaseAddress = new Uri("https://weatherapi-com.p.rapidapi.com"),
        };

        _weatherApiClientService = new WeatherApiClientService(_httpClient, new Logger<WeatherApiClientService>(new LoggerFactory()));
    }

    [Fact]
    public async Task GetWeatherApiWeatherHistoryByPoint_ReturnsWeatherData()
    {
        // Arrange
        var point = new Point(48.85, 2.3508);
        var startDate = new DateOnly(2023, 9, 8);
        var endDate = new DateOnly(2023, 9, 9);

        // Act
        var result = await _weatherApiClientService.GetWeatherApiWeatherHistoryByPoint(point, startDate, endDate);

        // Assert
        Assert.True(result.IsSuccess);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
