using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IList<CharmCategory>> GetWithCharmsAsync()
        {
            var categories = await dbContext
                .CharmCategories
                .Include(s => s.Charms)
                .ToListAsync();
            return categories;
        }

        public async Task<CharmCategory> GetWithCharmsAsync(Guid id)
        {
            var category = await dbContext
                .CharmCategories
                .Include(s => s.Charms)
                .SingleAsync(s => s.Id == id);

            return category;
        }
    }
}
