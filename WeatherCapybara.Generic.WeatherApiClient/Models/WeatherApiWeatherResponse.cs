using Newtonsoft.Json;

namespace WeatherCapybara.Generic.WeatherApiClient.Models;

public class WeatherApiWeatherResponse
{
    public Location Location { get; set; }
    [JsonProperty("forecast")]
    public Forecast WeatherForecast { get; set; }
}
