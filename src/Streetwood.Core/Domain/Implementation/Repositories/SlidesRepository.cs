namespace Streetwood.Core.Domain.Implementation.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Streetwood.Core.Domain.Abstract;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Entities;

    public class SlidesRepository : ISlidesRepository
    {
        private readonly IDbContext dbContext;

        public SlidesRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Slide>> GetSlidesAsync()
        {
            return await dbContext.Slides.ToArrayAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}