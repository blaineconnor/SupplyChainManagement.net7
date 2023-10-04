using SCM.Domain.Entities;
using System.Linq.Expressions;

namespace SCM.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<IEnumerable<object>> GetAllAsync();
        Task GetById(object id);
        void Add(object entity);
        void Update(object entity);
        void Delete(object entity);

    }
}
