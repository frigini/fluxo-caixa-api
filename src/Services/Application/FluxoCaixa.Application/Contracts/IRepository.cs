using FluxoCaixa.Core.DomainObjects;

namespace FluxoCaixa.Application.Contracts;

public interface IRepository<T> where T : Entity
{
    Task<T> Create(T entity);
    Task<bool> Delete(Guid id);
    Task<bool> Update(T entity);
    Task<T> Get(Guid id);
}
