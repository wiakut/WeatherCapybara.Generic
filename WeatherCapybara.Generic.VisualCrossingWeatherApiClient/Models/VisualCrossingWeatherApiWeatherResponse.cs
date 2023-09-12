using Newtonsoft.Json;

namespace WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Models;

public class VisualCrossingWeatherApiWeatherResponse
{
    [JsonProperty("locations")]
    public Dictionary<string, VisualCrossingWeatherApiStation> Stations { get; set; }
}
