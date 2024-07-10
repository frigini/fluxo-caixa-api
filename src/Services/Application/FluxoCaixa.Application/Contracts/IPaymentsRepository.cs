using FluxoCaixa.Domain.Entities;

namespace FluxoCaixa.Application.Contracts;

public interface IPaymentsRepository : IRepository<Payment>
{
    Task<List<Payment>> GetByType(int type);
    Task<List<Payment>> GetAll();
    Task<List<Payment>> GetAllByDate(DateTime date);
}
