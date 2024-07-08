using DesafioCarrefour.Application.Contracts;
using DesafioCarrefour.Domain.Entities;
using DesafioCarrefour.Infra.Context;
using MongoDB.Driver;

namespace DesafioCarrefour.Infra.Repositories;

public class UsersRepository(IDesafioCarrefourContext context) : IUsersRepository
{
    public async Task<User> AuthenticateUser(string username, string password) => await context.Users.Find(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();

    public async Task<List<User>> GetAll() => await context.Users.Find(Builders<User>.Filter.Empty).ToListAsync();

    public async Task<User> GetById(string id) => await context.Users.Find(u => u.Id == id).FirstOrDefaultAsync();
}
