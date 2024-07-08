using DesafioCarrefour.Infra;

namespace DesafioCarrefour.WebApi.Setup;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddInfrastructureServices();

        return services; 
    }
}

