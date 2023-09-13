using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.Shared.Domain;
using WeatherCapybara.Generic.WeatherApiClient.Models;

namespace WeatherCapybara.Generic.WeatherApiClient.Interfaces;

public interface IWeatherApiClientService
{
    Task<Result<WeatherApiWeatherResponse>> GetWeatherApiWeatherHistoryByPoint(
        Point point,
        DateOnly startDate,
        DateOnly? endDate = null,
        string languageCode = "en");
}