using DesafioCarrefour.Infra.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioCarrefour.Infra;

public static class InfraServiceColletion
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDesafioCarrefourContext, DesafioCarrefourContext>();

        //addscoped dos repositories

        return services;
    }
}

