using Newtonsoft.Json;

namespace WeatherCapybara.Generic.WeatherApiClient.Models;

public class Day
{
    [JsonProperty("maxtempC")]
    public double? MaxTemperatureC { get; set; }
    [JsonProperty("maxtempF")]
    public double? MaxTemperatureF { get; set; }
    [JsonProperty("mintempC")]
    public double? MinTemperatureC { get; set; }
    [JsonProperty("mintempF")]
    public double? MinTemperatureF { get; set; }
    [JsonProperty("avgtempC")]
    public double? AvgTemperatureC { get; set; }
    [JsonProperty("avgtempF")]
    public long? AvgTemperatureF { get; set; }
    [JsonProperty("maxwindKph")]
    public double? MaxWindSpeedKmPerHour { get; set; }
    [JsonProperty("totalprecipMm")]
    public double? PrecipitationInMillimeters { get; set; }
    
    public double? TotalprecipIn { get; set; }
    public double? AvgvisKm { get; set; }
    public double? AvgvisMiles { get; set; }
    public double? Avghumidity { get; set; }
    public Condition Condition { get; set; }
    public double? Uv { get; set; }
    public double? MaxwindMph { get; set; }
}