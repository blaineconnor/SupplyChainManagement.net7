using SCM.Domain.Common;
using SCM.Domain.Repositories;

namespace SCM.Domain.UnitofWork
{
    public interface IUnitWork : IDisposable
    {
        public IRepository<T> GetRepository<T>() where T : BaseEntity;
        public Task<bool> CommitAsync();
        public Task<bool> SendMessage(string message);

    }
}
