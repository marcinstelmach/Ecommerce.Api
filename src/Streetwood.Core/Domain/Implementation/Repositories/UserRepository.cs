using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Models;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IDbContext dbContext;
        public UserRepository(IDbContext dbContext) 
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
