using Newtonsoft.Json;

namespace WeatherCapybara.Generic.MeteostatApiClient.Models;

public class MeteostatApiWeatherData
{
    public DateOnly Date { get; set; }
    [JsonProperty("tavg")]
    public double? AverageTemperatureC { get; set; }
    [JsonProperty("tmin")]
    public double? MinTemperatureC { get; set; }
    [JsonProperty("tmax")]
    public double? MaxTemperatureC { get; set; }
    [JsonProperty("prcp")]
    public double? PrecipitationInMillimeters { get; set; }
    [JsonProperty("wdir")]
    public double? WindDirectionInDegrees { get; set; }
    [JsonProperty("wspd")]
    public double? WindSpeedInKmPerHour { get; set; }
    public double? Snow { get; set; }
    public double? Wpgt { get; set; }
    public double? Pres { get; set; }
    public double? Tsun { get; set; }
}
