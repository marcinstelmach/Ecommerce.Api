using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class ProductCategoryDiscountRepository : Repository<ProductCategoryDiscount>, IProductCategoryDiscountRepository
    {
        private readonly IDbContext dbContext;

        public ProductCategoryDiscountRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(ProductCategoryDiscount productCategoryDiscount)
        {
            await dbContext.ProductCategoryDiscounts.AddAsync(productCategoryDiscount);
        }
    }
}
