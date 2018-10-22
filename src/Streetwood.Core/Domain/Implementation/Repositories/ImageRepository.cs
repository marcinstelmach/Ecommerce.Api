using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
