using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.Contracts
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(string id);
        Task<User> AuthenticateUser(string username, string password);
    }
}
