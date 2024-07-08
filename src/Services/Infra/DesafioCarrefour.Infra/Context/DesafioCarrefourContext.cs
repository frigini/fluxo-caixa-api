using DesafioCarrefour.Domain.Entities;
using DesafioCarrefour.Infra.Settings;
using MongoDB.Driver;

namespace DesafioCarrefour.Infra.Context;

public class DesafioCarrefourContext : IDesafioCarrefourContext
{
    public DesafioCarrefourContext(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        Payments = database.GetCollection<Payment>(settings.PaymentsCollection);
        Users = database.GetCollection<User>(settings.UsersCollection);
    }

    public IMongoCollection<Payment> Payments { get; }
    public IMongoCollection<User> Users { get; }
}

