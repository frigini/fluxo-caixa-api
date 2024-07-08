using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Infra.Context;
using FluxoCaixa.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Infra;

public static class InfraServiceColletion
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IFluxoCaixaContext, FluxoCaixaContext>();
        services.AddScoped<IPaymentsRepository, PaymentsRepository>();

        return services;
    }
}

