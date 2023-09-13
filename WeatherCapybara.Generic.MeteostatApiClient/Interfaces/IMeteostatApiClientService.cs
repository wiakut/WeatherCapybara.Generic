using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.MeteostatApiClient.Models;
using WeatherCapybara.Generic.Shared.Domain;

namespace WeatherCapybara.Generic.MeteostatApiClient.Interfaces;

public interface IMeteostatApiClientService
{
    Task<Result<MeteostatApiWeatherResponse>> GetMeteostatApiWeatherHistoryByPoint(
        Point point,
        DateOnly startDate,
        DateOnly endDate);
}