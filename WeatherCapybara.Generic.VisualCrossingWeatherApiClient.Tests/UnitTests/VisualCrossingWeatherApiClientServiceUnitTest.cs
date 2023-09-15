using System.Drawing;
using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.Protected;
using WeatherCapybara.Generic.Shared.Domain;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Models;
using WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Services;
using Xunit;

namespace WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Tests.UnitTests;

public class VisualCrossingWeatherApiClientServiceUnitTest
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private VisualCrossingWeatherApiClientService _visualCrossingWeatherApiClientService;

    public VisualCrossingWeatherApiClientServiceUnitTest()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
    }

    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ReturnsSuccessResult()
    {
        SetupHttpResponseWithContent(JsonContent.Create(new VisualCrossingWeatherApiWeatherResponse()));

        var result = await _visualCrossingWeatherApiClientService.GetVisualCrossingWeatherApiWeatherHistoryByCityAndCountryCode(
            "A", 
            "A",
            It.IsAny<DateOnly>(),
            It.IsAny<DateOnly>());
        
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ReturnsFailedResult()
    {
        SetupHttpResponseWithContent(JsonContent.Create((VisualCrossingWeatherApiWeatherResponse)null));
        
        var result = await _visualCrossingWeatherApiClientService.GetVisualCrossingWeatherApiWeatherHistoryByCityAndCountryCode(
            "A", 
            "A",
            It.IsAny<DateOnly>(),
            It.IsAny<DateOnly>());
        
        Assert.True(result.IsFailure);
        Assert.Equal(Error.NullValue,result.Errors[0]);
    }
    
    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ThrowsExceptionReturnsFailedResult()
    {
        SetupHttpResponseWithContent(null);
        
        var result = await _visualCrossingWeatherApiClientService.GetVisualCrossingWeatherApiWeatherHistoryByCityAndCountryCode(
            "A", 
            "A",
            It.IsAny<DateOnly>(),
            It.IsAny<DateOnly>());
        
        Assert.True(result.IsFailure);
        Assert.Equal("RequestFailure",result.Errors.First().Code);
    }

    private void SetupHttpResponseWithContent(HttpContent content)
    {
        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage {
                StatusCode = HttpStatusCode.OK,
                Content = content
            });
        var httpClient = new HttpClient(_httpMessageHandlerMock.Object);
        httpClient.BaseAddress = new Uri("http://test.com/");

        _visualCrossingWeatherApiClientService =
            new VisualCrossingWeatherApiClientService(httpClient, NullLogger<VisualCrossingWeatherApiClientService>.Instance);
    }
}