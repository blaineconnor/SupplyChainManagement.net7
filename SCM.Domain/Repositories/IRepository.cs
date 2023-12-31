﻿using SCM.Domain.Common;
using System.Linq.Expressions;

namespace SCM.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync(params string[] includeColumns);
        Task<IQueryable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns);
        Task<T> GetSingleByFilterAsync(Expression<Func<T, bool>> filter, params string[] includeColumns);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
        Task<T> GetById(object id);
        Task<T> GetByName(object name);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);
    }
}
