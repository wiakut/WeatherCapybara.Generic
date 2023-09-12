using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.MeteostatApiClient.Models;

namespace WeatherCapybara.Generic.MeteostatApiClient.Interfaces;

public interface IMeteostatApiClientService
{
    Task<MeteostatApiWeatherResponse?> GetMeteostatApiWeatherHistoryByPoint(
        Point point,
        DateOnly startDate,
        DateOnly endDate);
}