namespace WeatherCapybara.Generic.WeatherApiClient.Models;

public class Forecastday
{
    public DateTimeOffset Date { get; set; }
    public long DateEpoch { get; set; }
    public Day Day { get; set; }
    public Astro Astro { get; set; }
    public List<Hour> Hour { get; set; }
}