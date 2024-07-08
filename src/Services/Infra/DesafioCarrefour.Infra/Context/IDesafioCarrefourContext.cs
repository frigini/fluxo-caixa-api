using DesafioCarrefour.Domain.Entities;
using MongoDB.Driver;

namespace DesafioCarrefour.Infra.Context;

public interface IDesafioCarrefourContext
{
    IMongoCollection<Payment> Payments {  get; }
}

