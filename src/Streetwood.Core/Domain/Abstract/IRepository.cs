using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streetwood.Core.Domain.Abstract
{
    public interface IRepository<T> where T : Entity
    {
        Task<IList<T>> GetListAsync();

        IQueryable<T> GetQueryable();

        Task<T> GetAsync(Guid id);

        Task<T> GetAndEnsureExistAsync(Guid id);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
    }
}
