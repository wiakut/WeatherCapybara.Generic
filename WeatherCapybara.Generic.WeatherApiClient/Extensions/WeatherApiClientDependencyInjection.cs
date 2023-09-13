using Microsoft.Extensions.DependencyInjection;
using WeatherCapybara.Generic.Helpers.Contants;
using WeatherCapybara.Generic.Shared.Common.Extensions;
using WeatherCapybara.Generic.WeatherApiClient.Interfaces;
using WeatherCapybara.Generic.WeatherApiClient.Services;

namespace WeatherCapybara.Generic.WeatherApiClient.Extensions;

public static class WeatherApiClientDependencyInjection
{
    public static IServiceCollection AddWeatherApiClient(this IServiceCollection services)
    {
        services.AddHttpClient<IWeatherApiClientService, WeatherApiClientService>((serviceProvider, httpClient) =>
        {
            httpClient.DefaultRequestHeaders.Add(ApiClientConstants.RapidClientApiKeyHeaderKey, "a383d65229mshef9ddd92b69e9f9p115938jsnf7c823904f4a");
            httpClient.DefaultRequestHeaders.Add(ApiClientConstants.RapidClientApiHostHeaderKey, "weatherapi-com.p.rapidapi.com");
            httpClient.BaseAddress = new Uri("https://weatherapi-com.p.rapidapi.com");
        }).AddGenericHttpClientRetryPolicy();
        
        return services;
    }
}