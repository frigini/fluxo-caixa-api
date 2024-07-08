﻿using DesafioCarrefour.Infra.Context;
using DesafioCarrefour.Application.Contracts;
using DesafioCarrefour.Domain.Entities;
using MongoDB.Driver;

namespace DesafioCarrefour.Infra.Repositories;

public class PaymentsRepository(IDesafioCarrefourContext context) : IPaymentsRepository
{
    public async Task<Payment> Create(Payment entity)
    {
        await context.Payments.InsertOneAsync(entity);
        return entity;
    }

    public async Task<bool> Delete(string id)
    {
        var result = await context.Payments.DeleteOneAsync(d => d.Id == id);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<Payment> Get(string id) => await context.Payments.Find(d => d.Id == id).FirstOrDefaultAsync();

    public async Task<Payment> GetByType(string type) => await context.Payments.Find(d => d.PaymentType == type).FirstOrDefaultAsync();

    public async Task<bool> Update(Payment entity)
    {
        var result = await context.Payments.ReplaceOneAsync(d => d.Id == entity.Id, entity);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }
}

