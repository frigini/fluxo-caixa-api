using DesafioCarrefour.Application.Contracts;
using DesafioCarrefour.Infra.Context;
using DesafioCarrefour.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioCarrefour.Infra;

public static class InfraServiceColletion
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDesafioCarrefourContext, DesafioCarrefourContext>();
        services.AddScoped<IPaymentsRepository, PaymentsRepository>();

        return services;
    }
}

