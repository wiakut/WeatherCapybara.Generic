using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.WeatherApiClient.Models;

namespace WeatherCapybara.Generic.WeatherApiClient.Interfaces;

public interface IWeatherApiClientService
{
    Task<WeatherApiWeatherResponse?> GetWeatherApiWeatherHistoryByPoint(
        Point point,
        DateOnly startDate,
        DateOnly? endDate = null,
        string languageCode = "en");
}