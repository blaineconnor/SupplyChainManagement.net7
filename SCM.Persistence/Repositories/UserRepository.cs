using Microsoft.EntityFrameworkCore;
using SCM.Domain.Entities;
using SCM.Domain.Repositories;
using SCM.Persistence.Context;

namespace SCM.Persistence.Repositories
{
    public class UserRepository<T> : GenericRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(SCM_Context context) : base(context)
        {
            _dbSet = context.Set<User>();
        }

        public void Add(object entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(object entity)
        {
            throw new NotImplementedException();
        }

        public Task GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(object entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<object>> IUserRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
