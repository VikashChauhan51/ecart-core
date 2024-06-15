using Ecart.Core.Configurations;
using Ecart.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecart.Core;
public static class DependencyInjection
{
    public static IServiceCollection AddDaprServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IContentStore<>), typeof(ContentStore<>));
        services.AddScoped<ISecretStore, SecretStore>();
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
}
