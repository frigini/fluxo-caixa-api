using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Infra.Context;
using FluxoCaixa.Infra.Repositories;
using FluxoCaixa.Infra.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Infra;

public static class InfraServiceColletion
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<FluxoCaixaContext>();
        services.AddScoped<IPaymentsRepository, PaymentsRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

        return services;
    }
}

