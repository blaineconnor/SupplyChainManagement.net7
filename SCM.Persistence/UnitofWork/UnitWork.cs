using SCM.Domain.Common;
using SCM.Domain.Repositories;
using SCM.Domain.UnitofWork;
using SCM.Persistence.Context;
using SCM.Persistence.Repositories;

namespace SCM.Persistence.UnitofWork
{
    public class UnitWork : IUnitWork
    {
        private Dictionary<Type, object> _repositories;
        private readonly SCM_Context _context;

        public UnitWork(SCM_Context context)
        {
            _repositories = new Dictionary<Type, object>();
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            var result = false;

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            return result;
        }
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (_repositories.ContainsKey(typeof(IRepository<T>)))
            {
                return (IRepository<T>)_repositories[typeof(IRepository<T>)];
            }

            var repository = new Repository<T>(_context);
            _repositories.Add(typeof(IRepository<T>), repository);
            return repository;
        }

        public IGenericRepository<T> GetGenericRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(IGenericRepository<T>)))
            {
                return (IGenericRepository<T>)_repositories[typeof(IGenericRepository<T>)];
            }
            var repository = new GenericRepository<T>(_context);
            _repositories.Add(typeof(IGenericRepository<T>), repository);
            return repository;
        }


        #region Dispose

        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _context.Dispose();
            }


            _disposed = true;
        }

        

        #endregion

    }
}