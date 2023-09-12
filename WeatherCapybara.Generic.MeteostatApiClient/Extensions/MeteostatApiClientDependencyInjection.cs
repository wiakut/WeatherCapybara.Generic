using Microsoft.Extensions.DependencyInjection;
using WeatherCapybara.Generic.Helpers.Contants;
using WeatherCapybara.Generic.MeteostatApiClient.Interfaces;
using WeatherCapybara.Generic.MeteostatApiClient.Services;

namespace WeatherCapybara.Generic.MeteostatApiClient.Extensions;

public static class MeteostatApiClientDependencyInjection
{
    public static IServiceCollection AddMeteostatApiClient(this IServiceCollection services)
    {
        services.AddHttpClient<IMeteostatApiClientService, MeteostatApiClientService>((serviceProvider, httpClient) =>
        {
            httpClient.DefaultRequestHeaders.Add(ApiClientConstants.RapidClientApiKeyHeaderKey, "a383d65229mshef9ddd92b69e9f9p115938jsnf7c823904f4a");
            httpClient.DefaultRequestHeaders.Add(ApiClientConstants.RapidClientApiHostHeaderKey, "meteostat.p.rapidapi.com");
            httpClient.BaseAddress = new Uri("https://meteostat.p.rapidapi.com");
        });
        
        return services;
    }
}