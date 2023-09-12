using Newtonsoft.Json;

namespace WeatherCapybara.Generic.VisualCrossingWeatherApiClient.Models;

public struct VisualCrossingWeatherApiStationWeatherData
{
    [JsonProperty("wdir")]
    public double? WindDirectionInDegrees { get; set; }
    [JsonProperty("temp")]
    public double? TemperatureF { get; set; }
    [JsonProperty("maxt")]
    public double? MaxTemperatureF { get; set; }
    [JsonProperty("mint")]
    public double? MinTemperatureC { get; set; }
    [JsonProperty("wspd")]
    public double? WindSpeedInKmPerHour { get; set; }   
    [JsonProperty("datetimeStr")]
    public DateTimeOffset Date { get; set; }
    [JsonProperty("precip")]
    public double? PrecipitationInMillimeters { get; set; }
    
    public double? Visibility { get; set; }
    public double? Solarenergy { get; set; }
    public double? Heatindex { get; set; }
    public double? Cloudcover { get; set; }
    public long Datetime { get; set; }
    public double? Solarradiation { get; set; }
    public string Weathertype { get; set; }
    public string Snowdepth { get; set; }
    public double? Sealevelpressure { get; set; }
    public string Snow { get; set; }
    public double? Dew { get; set; }
    public double? Humidity { get; set; }
    public long Precipcover { get; set; }
    public double? Wgust { get; set; }
    public string Conditions { get; set; }
    public string Windchill { get; set; }
    public string Info { get; set; }
}
