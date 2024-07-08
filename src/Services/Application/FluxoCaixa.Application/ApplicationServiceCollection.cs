using FluxoCaixa.Application.UserCases.Balance;
using FluxoCaixa.Application.UserCases.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Application;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBalanceService, BalanceService>();
        services.AddScoped<IPaymentsService, PaymentsService>();

        return services;
    }
}

