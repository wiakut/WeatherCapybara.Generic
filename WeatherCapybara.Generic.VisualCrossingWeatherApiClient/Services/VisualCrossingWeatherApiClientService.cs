using System.Net.Http.Json;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Interfaces;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Models;

namespace WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Services;

public class VisualCrossingWeatherApiClientService : IVisualCrossingWeatherApiClientService
{
    private readonly HttpClient _client;

    public VisualCrossingWeatherApiClientService(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<VisualCrossingWeatherApiWeatherResponse?> GetVisualCrossingWeatherApiWeatherHistoryByCityAndCountryCode(
        string city, 
        string countryCode, 
        DateOnly startDate,
        DateOnly endDate)
        => await _client.GetFromJsonAsync<VisualCrossingWeatherApiWeatherResponse>(
            $"/history?startDateTime={startDate:yyyy-MM-dd}&endDateTime={endDate:yyyy-MM-dd}" +
            $"&aggregateHours=24&location={city},{countryCode}&unitGroup=metric&contentType=json");

}