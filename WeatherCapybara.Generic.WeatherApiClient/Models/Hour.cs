using Newtonsoft.Json;

namespace WeatherCapybara.Generic.WeatherApiClient.Models;

public class Hour
{
    [JsonProperty("windDegree")]
    public double? WindDirectionInDegrees { get; set; }
    
    public long TimeEpoch { get; set; }
    public string Time { get; set; }
    public double? TempC { get; set; }
    public double? TempF { get; set; }
    public long IsDay { get; set; }
    public Condition Condition { get; set; }
    public double? WindMph { get; set; }
    public double? WindKph { get; set; }
    public string WindDir { get; set; }
    public double? PressureMb { get; set; }
    public double? PressureIn { get; set; }
    public double? PrecipMm { get; set; }
    public double? PrecipIn { get; set; }
    public double? Humidity { get; set; }
    public double? Cloud { get; set; }
    public double? FeelslikeC { get; set; }
    public double? FeelslikeF { get; set; }
    public double? WindchillC { get; set; }
    public double? WindchillF { get; set; }
    public double? HeatindexC { get; set; }
    public double? HeatindexF { get; set; }
    public double? DewpointC { get; set; }
    public double? DewpointF { get; set; }
    public long? WillItRain { get; set; }
    public long? ChanceOfRain { get; set; }
    public long? WillItSnow { get; set; }
    public double? ChanceOfSnow { get; set; }
    public double? VisKm { get; set; }
    public double? VisMiles { get; set; }
    public double? GustMph { get; set; }
    public double? GustKph { get; set; }
    public double? Uv { get; set; }
}