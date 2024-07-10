using FluxoCaixa.Application;
using FluxoCaixa.Infra;

namespace FluxoCaixa.WebApi.Setup;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices();

        return services; 
    }
}

