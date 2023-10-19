using SCM.Domain.Common;
using SCM.Domain.Entities;
using SCM.Domain.Repositories;
using SCM.Domain.Services.Abstractions;
using SCM.Domain.UnitofWork;
using SCM.Persistence.Context;
using SCM.Persistence.Repositories;

namespace SCM.Persistence.UnitofWork
{
    public class UnitWork : IUnitWork
    {
        private Dictionary<Type, object> _repositories;
        private readonly SCM_Context _context;
        private readonly ILoggedUserService _loggedUserService;

        public UnitWork(SCM_Context context, ILoggedUserService loggedUserService)
        {
            _repositories = new Dictionary<Type, object>();
            _context = context;
            _loggedUserService = loggedUserService;
        }

        public async Task<bool> SendMessage(string message)
        {
            var messageEntity = new Message
            {
                DateTime = DateTime.Now,
                UserId = (int)_loggedUserService.UserId,
                Description = message,

            };

            GetRepository<Message>().Add(messageEntity);

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