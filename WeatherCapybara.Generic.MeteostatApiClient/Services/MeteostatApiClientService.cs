using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.MeteostatApiClient.Interfaces;
using WeatherCapybara.Generic.MeteostatApiClient.Models;
using WeatherCapybara.Generic.Shared.Domain;

namespace WeatherCapybara.Generic.MeteostatApiClient.Services;

public class MeteostatApiClientService : IMeteostatApiClientService
{
    private readonly HttpClient _client;
    private readonly ILogger<MeteostatApiClientService> _logger;

    public MeteostatApiClientService(
        HttpClient client, 
        ILogger<MeteostatApiClientService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<Result<MeteostatApiWeatherResponse>> GetMeteostatApiWeatherHistoryByPoint(
        Point point, 
        DateOnly startDate, 
        DateOnly endDate)
    {
        try
        {
            var weatherResponse = await _client.GetFromJsonAsync<MeteostatApiWeatherResponse>(
                $"/point/daily?lat={point.LatitudeRequestString}&lon={point.LongitudeRequestString}&start={startDate:yyyy-MM-dd}&end={endDate:yyyy-MM-dd}");
            
            return Result.Of<MeteostatApiWeatherResponse>(weatherResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError("Request failure with message {@ErrorMessage}",ex.Message);
            return Result.Failure<MeteostatApiWeatherResponse>(new Error(
                "RequestFailure",
                ex.Message));
        }
    }
}