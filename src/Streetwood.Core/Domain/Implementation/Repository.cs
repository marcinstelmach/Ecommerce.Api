using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Domain.Implementation
{
    internal class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public async Task<IQueryable<Entity>> GetAsync()
            => await Task.FromResult(dbSet.AsQueryable());

        public async Task<Entity> GetAsync(Guid id)
            => await dbSet.FindAsync(id);

        public async Task<Entity> GetAndEnsureExist(Guid id)
        {
            var result = await dbSet.FindAsync(id);
            if (result == null)
            {
                throw new StreetwoodException(ErrorCode.GenericNotExist<T>());
            }

            return result;
        }

        public async Task AddAsync(T entity)
            => await dbSet.AddAsync(entity);

        public async Task Update(T entity)
            => await Task.FromResult(dbSet.Update(entity));

        public async Task Delete(T entity)
            => await Task.FromResult(dbSet.Remove(entity));

        public async Task SaveChangesAsync()
        {
            if (await dbContext.SaveChangesAsync() < 0)
            {
                throw new StreetwoodException(ErrorCode.CannotSaveDatabase);
            }
        }
    }
}
