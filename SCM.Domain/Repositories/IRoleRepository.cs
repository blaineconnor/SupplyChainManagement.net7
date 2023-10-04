using SCM.Domain.Entities;
using System.Linq.Expressions;

namespace SCM.Domain.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<IEnumerable<object>> GetAllAsync();
        Task<bool> CheckRole(int roleId, int userId);
        Task GetById(object id);
        void Add(object entity);
        void Update(object entity);
        void Delete(object id);
    }
}
