using Microsoft.Extensions.DependencyInjection;
using WeatherCapybara.Generic.Helpers.Contants;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Interfaces;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Services;

namespace WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Extensions;

public static class VisualCrossingWeatherApiClientDependencyInjection
{
    public static IServiceCollection AddVisualCrossingWeatherApiClient(this IServiceCollection services)
    {
        services.AddHttpClient<IVisualCrossingWeatherApiClientService, VisualCrossingWeatherApiClientService>((serviceProvider, httpClient) =>
        {
            httpClient.DefaultRequestHeaders.Add(ApiClientConstants.RapidClientApiKeyHeaderKey, "a383d65229mshef9ddd92b69e9f9p115938jsnf7c823904f4a");
            httpClient.DefaultRequestHeaders.Add(ApiClientConstants.RapidClientApiHostHeaderKey, "visual-crossing-weather.p.rapidapi.com");
            httpClient.BaseAddress = new Uri("https://visual-crossing-weather.p.rapidapi.com");
        });
        
        return services;
    }
}