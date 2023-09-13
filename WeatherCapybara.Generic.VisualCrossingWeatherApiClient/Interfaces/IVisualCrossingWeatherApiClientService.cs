using System.Drawing;
using WeatherCapybara.Generic.Shared.Domain;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Models;

namespace WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Interfaces;

public interface IVisualCrossingWeatherApiClientService
{
    Task<Result<VisualCrossingWeatherApiWeatherResponse>> GetVisualCrossingWeatherApiWeatherHistoryByCityAndCountryCode(
        string city,
        string countryCode,
        DateOnly startDate,
        DateOnly endDate);
}