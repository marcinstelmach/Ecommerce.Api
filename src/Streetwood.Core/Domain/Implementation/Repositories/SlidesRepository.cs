namespace Streetwood.Core.Domain.Implementation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Streetwood.Core.Domain.Abstract;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Entities;

    public class SlidesRepository : Repository<Slide>, ISlidesRepository
    {
        private readonly IDbContext dbContext;

        public SlidesRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Slide>> GetSlidesAsync()
        {
            return await dbContext.Slides.ToArrayAsync();
        }

        public async Task<int> GetLastOrderIndexAsync()
        {
            return await dbContext.Slides
                .OrderByDescending(x => x.OrderIndex)
                .Select(x => x.OrderIndex)
                .FirstOrDefaultAsync();
        }

        public void Add(Slide slide)
        {
            dbContext.Slides.Add(slide);
        }
    }
}