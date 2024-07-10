using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Infra.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace FluxoCaixa.Infra.Repositories;

public class UsersRepository(FluxoCaixaContext context) : IUsersRepository
{
    public async Task<User?> AddAndUpdateUser(User user)
    {
        bool isSuccess = false;
        var obj = await context.Users.FirstOrDefaultAsync(c => c.Id == user.Id);
        if (obj != null)
        {
            context.Users.Update(obj);
            isSuccess = await context.SaveChangesAsync() > 0;
        }
        else
        {
            await context.Users.AddAsync(user);
            isSuccess = await context.SaveChangesAsync() > 0;
        }

        return isSuccess ? user : null;
    }

    public async Task<User> AuthenticateUser(string username, string password) => await context.Users.SingleOrDefaultAsync(u => u.Username == username && u.Password == password);

    public async Task<IEnumerable<User>> GetAll() => await context.Users.ToListAsync();

    public async Task<User> GetById(Guid id) => await context.Users.FindAsync(id);
}
