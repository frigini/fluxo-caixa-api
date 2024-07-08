using DesafioCarrefour.Domain.Entities;

namespace DesafioCarrefour.Application.Contracts
{
    public interface IPaymentsRepository : IRepository<Payment>
    {
        Task<Payment> GetByType(int type);
        Task<List<Payment>> GetAllByDate(DateTime date);
    }
}
