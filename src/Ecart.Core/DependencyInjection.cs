using Ecart.Core.Configurations;
using Ecart.Core.Resilience;
using Ecart.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecart.Core;
public static class DependencyInjection
{
    public static IServiceCollection AddDaprServices
        (this IServiceCollection services)
    {
        services.AddScoped(typeof(IContentStore<>), typeof(ContentStore<>));
        services.AddScoped(typeof(IEventPublisher<>), typeof(EventPublisher<>));
        services.AddScoped<ISecretStore, SecretStore>();
        return services;
    }

    public static IServiceCollection AddPollyService
        (this IServiceCollection services)
    {
        services.AddSingleton<PollyPolicies>();
        return services;
    }


    public static IServiceCollection AddDaprConfiguration
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DaprConfig>(configuration.GetSection("Dapr"));
        return services;
    }

    public static IServiceCollection AddSqlConfiguration
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SqlConfig>(configuration.GetSection("Database"));
        return services;
    }
    public static IServiceCollection AddPollyRetryConfiguration
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RetryConfig>(configuration.GetSection("Retry"));
        return services;
    }

    public static IServiceCollection AddPollyCircuitBreakerConfiguration
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CircuitBreakerConfig>(configuration.GetSection("CircuitBreaker"));
        return services;
    }
}
