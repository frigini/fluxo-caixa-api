using FluxoCaixa.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.WebApi.Setup;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDependencyInjection(configuration);

        services.AddDbContext<FluxoCaixaContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection"), opt =>
            {
                opt.EnableRetryOnFailure();
            });
        });

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddApiVersioning();
        services.AddHealthChecks()
                        .AddSqlServer(configuration.GetConnectionString("SqlConnection"));

        return services;
    }
}
