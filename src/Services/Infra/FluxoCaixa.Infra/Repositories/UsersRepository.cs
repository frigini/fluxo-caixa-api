using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace FluxoCaixa.Infra.Repositories;

public class UsersRepository(FluxoCaixaContext context) : IUsersRepository
{
    public async Task<User> AuthenticateUser(string username, string password) => await context.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);

    public async Task<List<User>> GetAll() => await context.Users.ToListAsync();

    public async Task<User> GetById(Guid id) => await context.Users.FindAsync(id);
}
