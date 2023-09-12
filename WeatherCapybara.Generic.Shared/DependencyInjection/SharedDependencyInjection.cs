using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WeatherCapybara.Generic.Shared.Common.Behaviors;

namespace WeatherCapybara.Generic.Shared.DependencyInjection;

public static class SharedDependencyInjection
{
    public static IServiceCollection AddSharedServices(
        this IServiceCollection services, 
        params Assembly[] assemblies)
    {
        var assembly = typeof(SharedDependencyInjection).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(assemblies));

        services.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: true);
        return services;
    }
    
    public static IServiceCollection AddLoggingBehavior(this IServiceCollection services)
    {
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(LoggingPipelineBehavior<,>));
        
        return services;
    }
    
    public static IServiceCollection AddValidationBehavior(this IServiceCollection services)
    {
        services.AddScoped(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationPipelineBehavior<,>));
        
        return services;
    }
}