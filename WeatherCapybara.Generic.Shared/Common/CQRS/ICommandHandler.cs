using MediatR;
using WeatherCapybara.Generic.Shared.Domain;

namespace WeatherCapybara.Generic.Shared.Common.CQRS;

public interface ICommandHandler<TCommand> 
    : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{ }

public interface ICommandHandler<TCommand, TResponse> 
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{ }