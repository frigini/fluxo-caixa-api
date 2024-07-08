using DesafioCarrefour.Domain.Entities;

namespace DesafioCarrefour.Application.Contracts
{
    public interface IPaymentsRepository : IRepository<Payment>
    {
        Task<Payment> GetByType(string type);
    }
}
