using FluxoCaixa.Application.Objects.Responses;

namespace FluxoCaixa.Application.UserCases.Users;

public interface IUsersService
{
    Task<AuthenticateResponse> AuthenticateUser(string username, string password);
    Task<List<AuthenticateResponse>> GetAll();
}
