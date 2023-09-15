using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.Protected;
using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.Shared.Domain;
using WeatherCapybara.Generic.WeatherApiClient.Models;
using WeatherCapybara.Generic.WeatherApiClient.Services;
using Xunit;

namespace WeatherCapybara.Generic.WeatherApiClient.Tests.UnitTests;

public class WeatherApiClientServiceUnitTest
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private WeatherApiClientService _weatherApiClientService;

    public WeatherApiClientServiceUnitTest()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
    }

    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ReturnsSuccessResult()
    {
        SetupHttpResponseWithContent(JsonContent.Create(new WeatherApiWeatherResponse()));

        var result = await _weatherApiClientService.GetWeatherApiWeatherHistoryByPoint(
            new Point(1,1),
            It.IsAny<DateOnly>(),
            It.IsAny<DateOnly>());
        
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ReturnsFailedResult()
    {
        SetupHttpResponseWithContent(JsonContent.Create((WeatherApiWeatherResponse)null));
        
        var result = await _weatherApiClientService.GetWeatherApiWeatherHistoryByPoint(
            new Point(1,1),
            It.IsAny<DateOnly>(),
            It.IsAny<DateOnly>());
        
        Assert.True(result.IsFailure);
        Assert.Equal(Error.NullValue,result.Errors[0]);
    }
    
    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ThrowsExceptionReturnsFailedResult()
    {
        SetupHttpResponseWithContent(null);
        
        var result = await _weatherApiClientService.GetWeatherApiWeatherHistoryByPoint(
            new Point(1,1),
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

        _weatherApiClientService =
            new WeatherApiClientService(httpClient, NullLogger<WeatherApiClientService>.Instance);
    }
}