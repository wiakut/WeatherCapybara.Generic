using WeatherCapybara.Generic.Helpers.Contants;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Interfaces;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Models;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Services;
using Xunit;

namespace WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Tests.IntegrationTests;

public class VisualCrossingWeatherApiClientServiceIntegrationTest : IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly IVisualCrossingWeatherApiClientService  _visualCrossingWeatherApiClientService;

    public VisualCrossingWeatherApiClientServiceIntegrationTest()
    {
        _httpClient = new HttpClient
        {
            DefaultRequestHeaders =
            {
                {ApiClientConstants.RapidClientApiKeyHeaderKey, "a383d65229mshef9ddd92b69e9f9p115938jsnf7c823904f4a"},
                {ApiClientConstants.RapidClientApiHostHeaderKey, "visual-crossing-weather.p.rapidapi.com"}
            },
            BaseAddress = new Uri("https://visual-crossing-weather.p.rapidapi.com"),
        };

        _visualCrossingWeatherApiClientService = new VisualCrossingWeatherApiClientService(_httpClient);
    }

    [Fact]
    public async Task GetVisualCrossingWeatherApiWeatherHistoryByCityAndCountryCode_ReturnsWeatherData()
    {
        var city = "Lviv";
        var countryCode = "UA";
        var startDate = new DateOnly(2023, 9, 1);
        var endDate = new DateOnly(2023, 9, 10);
        
        var result = await _visualCrossingWeatherApiClientService.GetVisualCrossingWeatherApiWeatherHistoryByCityAndCountryCode(
            city, countryCode, startDate, endDate);

        Assert.NotNull(result);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
