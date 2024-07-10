using FluxoCaixa.Infra.Context;
using FluxoCaixa.Application.Contracts;
using FluxoCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Infra.Repositories;

public class PaymentsRepository(FluxoCaixaContext context) : IPaymentsRepository
{
    public async Task<Payment> Create(Payment entity)
    {
        await context.Payments.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        await context.Payments.Where(p => p.Id == id).ExecuteDeleteAsync();
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Payment> Get(Guid id) => await context.Payments.FindAsync(id);

    public async Task<List<Payment>> GetAll() => await context.Payments.ToListAsync();

    public async Task<List<Payment>> GetAllByDate(DateTime date) => await context.Payments.AsNoTracking().Where(p => p.PaymentDate == date).ToListAsync();

    public async Task<List<Payment>> GetByType(int type) => await context.Payments.AsNoTracking().Where(p => (int)p.PaymentType == type).ToListAsync();

    public async Task<bool> Update(Payment entity)
    {
        context.Payments.Update(entity);
        return await context.SaveChangesAsync() > 0;
    }
}

