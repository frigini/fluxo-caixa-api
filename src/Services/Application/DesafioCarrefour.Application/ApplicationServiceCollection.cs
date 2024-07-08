using DesafioCarrefour.Application.UserCases.Balance;
using DesafioCarrefour.Application.UserCases.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioCarrefour.Application;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBalanceService, BalanceService>();
        services.AddScoped<IPaymentsService, PaymentsService>();

        return services;
    }
}

