using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using WeatherCapybara.Generic.Shared.Domain;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Interfaces;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Models;

namespace WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Services;

public class VisualCrossingWeatherApiClientService : IVisualCrossingWeatherApiClientService
{
    private readonly HttpClient _client;
    private readonly ILogger<VisualCrossingWeatherApiClientService> _logger;

    public VisualCrossingWeatherApiClientService(
        HttpClient client, 
        ILogger<VisualCrossingWeatherApiClientService> logger)
    {
        _client = client;
        _logger = logger;
    }
    
    public async Task<Result<VisualCrossingWeatherApiWeatherResponse>> GetVisualCrossingWeatherApiWeatherHistoryByCityAndCountryCode(
        string city, 
        string countryCode, 
        DateOnly startDate,
        DateOnly endDate)
    {
        try
        {
            var weatherResponse = await _client.GetFromJsonAsync<VisualCrossingWeatherApiWeatherResponse>(
                $"/history?startDateTime={startDate:yyyy-MM-dd}&endDateTime={endDate:yyyy-MM-dd}" +
                $"&aggregateHours=24&location={city},{countryCode}&unitGroup=metric&contentType=json");
            
            return Result.Of<VisualCrossingWeatherApiWeatherResponse>(weatherResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Request failure with message {@ErrorMessage}",ex.Message);
            return Result.Failure<VisualCrossingWeatherApiWeatherResponse>(new Error(
                "RequestFailure",
                ex.Message));
        }
    }
}