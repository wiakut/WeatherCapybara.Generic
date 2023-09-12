using MediatR;
using WeatherCapybara.Generic.Shared.Domain;

namespace WeatherCapybara.Generic.Shared.Common.CQRS;

public interface ICommand : IRequest<Result>
{ }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
    
}