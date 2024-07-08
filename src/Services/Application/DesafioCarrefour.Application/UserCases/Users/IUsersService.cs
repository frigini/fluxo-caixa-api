using DesafioCarrefour.Application.Objects.Responses;

namespace DesafioCarrefour.Application.UserCases.Users;

public interface IUsersService
{
    Task<AuthenticateResponse> AuthenticateUser(string username, string password);
    Task<List<AuthenticateResponse>> GetAll();
}
