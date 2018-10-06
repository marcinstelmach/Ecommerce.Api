using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    public class ProductRespository : Repository<Product>, IProductRepository
    {
        private readonly IDbContext dbContext;

        public ProductRespository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
