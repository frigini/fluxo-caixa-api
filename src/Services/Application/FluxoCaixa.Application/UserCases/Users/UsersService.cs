using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;
using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.UserCases.Users;

public class UsersService(IUsersRepository usersRepository) : IUsersService
{
    public async Task<UserResponse> AddUser(AuthenticateRequest request)
    {
        var user = new User(request.Username, request.Password);
        var userCreated = await usersRepository.AddAndUpdateUser(user);

        if (userCreated == null) return null;

        return new UserResponse(userCreated.Id, userCreated.Username);
    }

    public async Task<AuthenticateResponse> AuthenticateUser(string username, string password)
    {
        var userAuthenticated = await usersRepository.AuthenticateUser(username, password);

        if (userAuthenticated == null) return null;

        return new AuthenticateResponse
        {
            Id = userAuthenticated.Id,
            Username = userAuthenticated.Username,
        };
    }

    public async Task<IEnumerable<AuthenticateResponse>> GetAll()
    {
        var payments = await usersRepository.GetAll();

        return payments.Select(u => new AuthenticateResponse { Id = u.Id, Username = u.Username });
    }
}
