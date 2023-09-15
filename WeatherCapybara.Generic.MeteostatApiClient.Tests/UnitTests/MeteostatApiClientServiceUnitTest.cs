using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Moq.Protected;
using WeatherCapybara.Generic.Domain.Models;
using WeatherCapybara.Generic.MeteostatApiClient.Models;
using WeatherCapybara.Generic.MeteostatApiClient.Services;
using WeatherCapybara.Generic.Shared.Domain;
using Xunit;

namespace WeatherCapybara.Generic.MeteostatApiClient.Tests.UnitTests;

public class MeteostatApiClientServiceUnitTest
{
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private MeteostatApiClientService _meteostatApiClientService;

    public MeteostatApiClientServiceUnitTest()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
    }

    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ReturnsSuccessResult()
    {
        SetupHttpResponseWithContent(JsonContent.Create(new MeteostatApiWeatherResponse()));

        var result = await _meteostatApiClientService.GetMeteostatApiWeatherHistoryByPoint(new Point(1,1), It.IsAny<DateOnly>(),
            It.IsAny<DateOnly>());
        
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ReturnsFailedResult()
    {
        SetupHttpResponseWithContent(JsonContent.Create((MeteostatApiWeatherResponse)null));
        
        var result = await _meteostatApiClientService.GetMeteostatApiWeatherHistoryByPoint(new Point(1,1), It.IsAny<DateOnly>(),
            It.IsAny<DateOnly>());
        
        Assert.True(result.IsFailure);
        Assert.Equal(Error.NullValue,result.Errors[0]);
    }
    
    [Fact]
    public async Task GetMeteostatApiWeatherHistoryByPoint_ThrowsExceptionReturnsFailedResult()
    {
        SetupHttpResponseWithContent(null);
        
        var result = await _meteostatApiClientService.GetMeteostatApiWeatherHistoryByPoint(new Point(1,1), It.IsAny<DateOnly>(),
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

        _meteostatApiClientService =
            new MeteostatApiClientService(httpClient, NullLogger<MeteostatApiClientService>.Instance);
    }
}