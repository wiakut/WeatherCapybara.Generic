using Newtonsoft.Json;

namespace WeatherCapybara.Generic.MeteostatApiClient.Models;

public class MeteostatApiWeatherResponse
{
    public List<MeteostatApiWeatherData> Data { get; set; }
}


