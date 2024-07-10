using FluxoCaixa.Application.Objects.Requests;
using FluxoCaixa.Application.Objects.Responses;

namespace FluxoCaixa.Application.UserCases.Users;

public interface IUsersService
{
    Task<AuthenticateResponse> AuthenticateUser(string username, string password);
    Task<IEnumerable<AuthenticateResponse>> GetAll();
    Task<UserResponse> AddUser(AuthenticateRequest request);
}
