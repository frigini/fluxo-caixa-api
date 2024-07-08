using FluxoCaixa.Application;
using FluxoCaixa.Infra;

namespace FluxoCaixa.WebApi.Setup;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddInfrastructureServices();
        services.AddApplicationServices();

        return services; 
    }
}

