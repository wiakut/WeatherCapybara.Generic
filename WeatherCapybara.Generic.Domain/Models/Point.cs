using System.Globalization;

namespace WeatherCapybara.Generic.Domain.Models;

public record Point(
    double Latitude,
    double Longitude)
{
    private static readonly CultureInfo Culture = new("en-US");

    public string LatitudeRequestString => Latitude.ToString(Culture);
    public string LongitudeRequestString => Longitude.ToString(Culture);
}