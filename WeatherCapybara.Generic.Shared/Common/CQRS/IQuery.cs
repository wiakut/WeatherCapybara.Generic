using MediatR;
using WeatherCapybara.Generic.Shared.Domain;

namespace WeatherCapybara.Generic.Shared.Common.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }