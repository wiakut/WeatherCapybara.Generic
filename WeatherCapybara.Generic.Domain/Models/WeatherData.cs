namespace WeatherCapybara.Generic.Domain.Models;

public class WeatherData
{
    public double? AvgTemperatureF { get; set; }
    public double? MaxTemperatureF { get; set; }
    public double? MinTemperatureF { get; set; }
    public double? AvgTemperatureC { get; set; }
    public double? MaxTemperatureC { get; set; }
    public double? MinTemperatureC { get; set; }
    public double? WindDirectionInDegrees { get; set; }
    public double? WindSpeedInKmPerHour { get; set; }
    public DateOnly Date { get; set; }
    public double? PrecipitationInMillimeters { get; set; }
}