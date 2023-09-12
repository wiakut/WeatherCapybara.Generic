using Newtonsoft.Json;

namespace WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Models;

public class VisualCrossingWeatherApiStation
{
    [JsonProperty("values")]
    public List<VisualCrossingWeatherApiStationWeatherData> Data { get; set; }
    public string Id { get; set; }
    public string Address { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string StationContributions { get; set; }
    public long Index { get; set; }
    public long Distance { get; set; }
    public long Time { get; set; }
    public string Tz { get; set; }
    public string CurrentConditions { get; set; }
    public string Alerts { get; set; }
}