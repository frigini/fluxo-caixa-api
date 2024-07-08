using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Context;
using MongoDB.Driver;

namespace FluxoCaixa.Infra.Repositories;

public class UsersRepository(IFluxoCaixaContext context) : IUsersRepository
{
    public async Task<User> AuthenticateUser(string username, string password) => await context.Users.Find(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();

    public async Task<List<User>> GetAll() => await context.Users.Find(Builders<User>.Filter.Empty).ToListAsync();

    public async Task<User> GetById(string id) => await context.Users.Find(u => u.Id == id).FirstOrDefaultAsync();
}
