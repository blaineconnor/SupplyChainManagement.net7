using Microsoft.EntityFrameworkCore;
using SCM.Domain.Common;
using SCM.Domain.Repositories;
using SCM.Persistence.Context;
using System.Linq.Expressions;

namespace SCM.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SCM_Context _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(SCM_Context context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);

        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {

            return await Task.FromResult(_dbSet.Where(expression));

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.FromResult(_dbSet.ToList());
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task RemoveAsync(T entity, bool hardDelete = false)
        {
            if (entity is BaseEntity soft && !hardDelete)
            {
                soft.IsDeleted = true;
                await UpdateAsync(entity);
            }
            else
            {
                await Task.FromResult(_dbSet.Remove(entity));
            }
            await SaveChanges();
        }

        public async Task RemoveAsync(object id, bool hardDelete = false)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentNullException("Kayıt bulunamadı");
            }

            await RemoveAsync(entity, hardDelete);
        }

        public async Task UpdateAsync(BaseEntity _entity)
        {
            var entity = await GetByIdAsync(_entity.Id);

            if (entity == null)
            {
                throw new Exception("");
            }
            if (entity is AuditableEntity at)
            {
                at.BoughtTime = DateTime.Now;
            }
            _context.Entry(entity).CurrentValues.SetValues(entity);
            await SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.FromResult(_dbSet.Update(entity));
            await SaveChanges();
        }
        private async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
