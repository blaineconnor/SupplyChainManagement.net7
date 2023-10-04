﻿using SCM.Domain.Common;
using System.Linq.Expressions;

namespace SCM.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateAsync(BaseEntity entity);
        Task RemoveAsync(T entity, bool hardDelete = false);
        Task RemoveAsync(object id, bool hardDelete = false);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
    }
}
