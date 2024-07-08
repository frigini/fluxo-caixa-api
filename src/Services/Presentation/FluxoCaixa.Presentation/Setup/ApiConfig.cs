using FluxoCaixa.Infra.Settings;
using Microsoft.Extensions.Options;

namespace FluxoCaixa.WebApi.Setup;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDependencyInjection();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);
        services.AddApiVersioning();
        services.AddHealthChecks()
                        .AddMongoDb(configuration["MongoDbSettings:ConnectionString"], "FluxoCaixa HealthCheck", Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded);

        return services;
    }
}
