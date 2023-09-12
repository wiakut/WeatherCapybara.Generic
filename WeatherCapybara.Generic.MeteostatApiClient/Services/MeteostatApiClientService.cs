using System.Net.Http.Json;
using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.MeteostatApiClient.Interfaces;
using WeatherCapybara.Generic.MeteostatApiClient.Models;

namespace WeatherCapybara.Generic.MeteostatApiClient.Services;

public class MeteostatApiClientService : IMeteostatApiClientService
{
    private readonly HttpClient _client;

    public MeteostatApiClientService(HttpClient client)
    {
        _client = client;
    }

    public async Task<MeteostatApiWeatherResponse?> GetMeteostatApiWeatherHistoryByPoint(
        Point point, 
        DateOnly startDate, 
        DateOnly endDate) =>
        await _client.GetFromJsonAsync<MeteostatApiWeatherResponse>(
            $"/point/daily?lat={point.LatitudeRequestString}&lon={point.LongitudeRequestString}&start={startDate:yyyy-MM-dd}&end={endDate:yyyy-MM-dd}");
}