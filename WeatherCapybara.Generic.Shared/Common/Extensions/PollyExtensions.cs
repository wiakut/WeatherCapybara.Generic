using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;

namespace WeatherCapybara.Generic.Shared.Common.Extensions;

public static class PollyExtensions
{
    public static IHttpClientBuilder AddGenericHttpClientRetryPolicy(this IHttpClientBuilder httpClientBuilder)
    {
        httpClientBuilder.AddPolicyHandler((serviceProvider, httpRequestMessage) =>
        {
            return Policy
                .Handle<Exception>()
                .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, sleepDuration => TimeSpan.FromSeconds(3), (result, timeSpan, retryCount, context) =>
                {
                    if (serviceProvider.GetService<ILogger>() is not { } logger) return;

                    logger.LogWarning(
                        "HttpClient request attempt {@Attempt} failed with message: {@Message}, next attempt in {@Seconds} s.",
                        retryCount, result.Exception.Message, timeSpan.TotalSeconds);

                });
        });
        
        return httpClientBuilder;
    } 
}