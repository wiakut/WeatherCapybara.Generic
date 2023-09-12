using MediatR;
using WeatherCapybara.Generic.Shared.Primitives;

namespace WeatherCapybara.Generic.Shared.Common.Other;

public interface IDomainEventHandler<TDomainEvent>
    : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{ }