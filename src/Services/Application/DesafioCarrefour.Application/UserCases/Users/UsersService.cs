using DesafioCarrefour.Application.Contracts;
using DesafioCarrefour.Application.Objects.Responses;
using DesafioCarrefour.Domain.Entities;

namespace DesafioCarrefour.Application.UserCases.Users;

public class UsersService(IUsersRepository usersRepository) : IUsersService
{
    public async Task<AuthenticateResponse> AuthenticateUser(string username, string password)
    {
        var user = await usersRepository.AuthenticateUser(username, password);

        return new AuthenticateResponse
        {
            Id = user.Id,
            Username = user.Username,
        };
    }

    public async Task<List<AuthenticateResponse>> GetAll()
    {
        var payments = await usersRepository.GetAll();

        return payments.Select(u => new AuthenticateResponse { Id = u.Id, Username = u.Username }).ToList();
    }
}
