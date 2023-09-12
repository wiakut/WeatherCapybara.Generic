using System.Text;
using MediatR;
using Microsoft.Extensions.Logging;
using WeatherCapybara.Generic.Shared.Domain;

namespace WeatherCapybara.Generic.Shared.Common.Behaviors;

public class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger) 
        => _logger = logger;

    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Starting request {@RequestName}, {@DateTimeUtc}.",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        var result = await next();

        if (result.IsFailure)
        {
            var errorsString = new StringBuilder();
            foreach (var error in result.Errors)
            {
                errorsString.AppendJoin(error, ", ");
            }
            
            _logger.LogError(
                "Request failure {@RequestName}, {@Errors}, {@DateTimeUtc}.",
                typeof(TRequest).Name,
                errorsString.ToString(),
                DateTime.UtcNow);
        }
        
        _logger.LogInformation(
            "Completed request {@RequestName}, {@DateTimeUtc}.",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        return result;
    }
}