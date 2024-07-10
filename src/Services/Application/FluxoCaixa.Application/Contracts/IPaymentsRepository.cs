using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.Contracts;

public interface IPaymentsRepository : IRepository<Payment>
{
    Task<IEnumerable<Payment>> GetByType(int type);
    Task<IEnumerable<Payment>> GetAll();
    Task<IEnumerable<Payment>> GetAllByDate(DateTime date);
}