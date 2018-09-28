using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

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

        public async Task AddAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
        }
    }
}
