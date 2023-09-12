using System.Net.Http.Json;
using System.Text;
using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.WeatherApiClient.Interfaces;
using WeatherCapybara.Generic.WeatherApiClient.Models;

namespace WeatherCapybara.Generic.WeatherApiClient.Services;

public class WeatherApiClientService : IWeatherApiClientService
{
    private readonly HttpClient _client;

    public WeatherApiClientService(HttpClient client)
    {
        _client = client;
    }

    public async Task<WeatherApiWeatherResponse?> GetWeatherApiWeatherHistoryByPoint(
        Point point,
        DateOnly startDate,
        DateOnly? endDate = null,
        string languageCode = "en")
    {
        var requestStringBuilder =
            new StringBuilder($"/history.json?q={point.LatitudeRequestString},{point.LongitudeRequestString}&dt={startDate:yyyy-MM-dd}&lang={languageCode}");

        if (endDate != null)
            requestStringBuilder.Append($"end_dt={endDate:yyyy-MM-dd}");

        return await _client.GetFromJsonAsync<WeatherApiWeatherResponse>(requestStringBuilder.ToString());
    }
}