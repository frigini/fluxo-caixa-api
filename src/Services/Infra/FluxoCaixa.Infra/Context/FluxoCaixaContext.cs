using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Settings;
using MongoDB.Driver;

namespace FluxoCaixa.Infra.Context;

public class FluxoCaixaContext : IFluxoCaixaContext
{
    public FluxoCaixaContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        Payments = database.GetCollection<Payment>(settings.PaymentsCollection);
        Users = database.GetCollection<User>(settings.UsersCollection);
    }

    public IMongoCollection<Payment> Payments { get; }
    public IMongoCollection<User> Users { get; }
}

