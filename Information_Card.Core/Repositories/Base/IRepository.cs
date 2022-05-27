using Information_Card.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Information_Card.Core.Repositories.Base
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
