using FluxoCaixa.Domain.Entities;
using MongoDB.Driver;

namespace FluxoCaixa.Infra.Context;

public interface IFluxoCaixaContext
{
    IMongoCollection<Payment> Payments {  get; }
    IMongoCollection<User> Users {  get; }
}

