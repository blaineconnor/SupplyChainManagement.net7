using SCM.Domain.Common;
using SCM.Domain.Repositories;

namespace SCM.Domain.UnitofWork
{
    public interface IUnitWork : IDisposable
    {
        public IRepository<T> GetRepository<T>() where T : BaseEntity;
        public IGenericRepository<T> GetGenericRepository<T>() where T : class;
        public Task<bool> CommitAsync();
    }
}
