using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.Helpers.Contants;
using WeatherCapybara.Generic.MeteostatApiClient.Interfaces;
using WeatherCapybara.Generic.MeteostatApiClient.Services;
using Xunit;

namespace WeatherCapybara.Generic.MeteostatApiClient.Tests.IntegrationTests;

public class MeteostatApiClientServiceIntegrationTest : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly IMeteostatApiClientService  _meteostatApiClientService;

    public MeteostatApiClientServiceIntegrationTest()
    {
        _httpClient = new HttpClient
        {
            DefaultRequestHeaders =
            {
                {ApiClientConstants.RapidClientApiKeyHeaderKey, "a383d65229mshef9ddd92b69e9f9p115938jsnf7c823904f4a"},
                {ApiClientConstants.RapidClientApiHostHeaderKey, "meteostat.p.rapidapi.com"}
            },
            BaseAddress = new Uri("https://meteostat.p.rapidapi.com"),
        };

        _meteostatApiClientService = new MeteostatApiClientService(_httpClient);
    }

    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ReturnsWeatherData()
    {
        // Arrange
        var point = new Point(12.34, 56.78);
        var startDate = new DateOnly(2023, 9, 1);
        var endDate = new DateOnly(2023, 9, 10);
        
        // Act
        var result = await _meteostatApiClientService.GetMeteostatApiWeatherHistoryByPoint(point, startDate, endDate);

        // Assert
        Assert.NotNull(result);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
