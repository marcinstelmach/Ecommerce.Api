using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class CharmCategoryRepository : Repository<CharmCategory>, ICharmCategoryRepository
    {
        private readonly IDbContext dbContext;

        public CharmCategoryRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(CharmCategory charmCategory)
        {
            await dbContext.CharmCategories.AddAsync(charmCategory);
        }
    }
}
