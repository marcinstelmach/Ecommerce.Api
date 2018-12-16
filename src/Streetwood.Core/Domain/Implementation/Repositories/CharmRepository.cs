using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class CharmRepository : Repository<Charm>, ICharmRepository
    {
        private readonly IDbContext dbContext;

        public CharmRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IList<Charm>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            var charms = await dbContext.Charms
                .Where(s => ids.Contains(s.Id))
                .ToListAsync();

            return charms;
        }
    }
}
