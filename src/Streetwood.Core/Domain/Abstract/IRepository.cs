using System;
using System.Linq;
using System.Threading.Tasks;

namespace Streetwood.Core.Domain.Abstract
{
    public interface IRepository<in T> where T:Entity
    {
        Task<IQueryable<Entity>> GetAsync();
        Task<Entity> GetAsync(Guid id);
        Task<Entity> GetAndEnsureExist(Guid id);
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SaveChangesAsync();
    }
}
