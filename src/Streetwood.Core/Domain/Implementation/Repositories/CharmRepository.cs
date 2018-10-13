using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class CharmRepository : Repository<Charm>, ICharmRepository
    {
        private readonly ICharmRepository charmRepository;

        public CharmRepository(IDbContext dbContext, ICharmRepository charmRepository)
            : base(dbContext)
        {
            this.charmRepository = charmRepository;
        }
    }
}
