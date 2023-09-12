namespace WeatherCapybara.Generic.Shared.Domain;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation problem has occured");

    Error[] Errors { get; }
}