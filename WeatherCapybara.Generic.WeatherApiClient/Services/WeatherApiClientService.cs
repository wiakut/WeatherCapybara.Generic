using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.Shared.Domain;
using WeatherCapybara.Generic.WeatherApiClient.Interfaces;
using WeatherCapybara.Generic.WeatherApiClient.Models;

namespace WeatherCapybara.Generic.WeatherApiClient.Services;

public class WeatherApiClientService : IWeatherApiClientService
{
    private readonly HttpClient _client;
    private readonly ILogger<WeatherApiClientService> _logger;

    public WeatherApiClientService(
        HttpClient client, 
        ILogger<WeatherApiClientService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<Result<WeatherApiWeatherResponse>> GetWeatherApiWeatherHistoryByPoint(
        Point point,
        DateOnly startDate,
        DateOnly? endDate = null,
        string languageCode = "en")
    {
        try
        {
            var requestStringBuilder =
                new StringBuilder($"/history.json?q={point.LatitudeRequestString},{point.LongitudeRequestString}&dt={startDate:yyyy-MM-dd}&lang={languageCode}");

            if (endDate != null)
                requestStringBuilder.Append($"end_dt={endDate:yyyy-MM-dd}");

            var weatherResponse = await _client.GetFromJsonAsync<WeatherApiWeatherResponse>(requestStringBuilder.ToString());
        
            return Result.Of<WeatherApiWeatherResponse>(weatherResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Request failure with message {@ErrorMessage}",ex.Message);
            return Result.Failure<WeatherApiWeatherResponse>(new Error(
                "RequestFailure",
                ex.Message));
        }
    }
}