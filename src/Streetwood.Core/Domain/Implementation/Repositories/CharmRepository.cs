using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class CharmRepository : Repository<Charm>, ICharmRepository
    {
        public CharmRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
