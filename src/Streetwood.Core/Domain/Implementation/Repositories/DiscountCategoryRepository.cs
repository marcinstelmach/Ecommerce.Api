using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class DiscountCategoryRepository : Repository<DiscountCategory>, IDiscountCategoryRepository
    {
        private readonly IDbContext dbContext;

        public DiscountCategoryRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddRangeAsync(IEnumerable<DiscountCategory> discountCategories)
        {
            await dbContext
                .DiscountCategories
                .AddRangeAsync(discountCategories);
        }

        public async Task<IList<ProductCategory>> GetCategories(ProductCategoryDiscount discount)
        {
            var categories = await dbContext
                .DiscountCategories
                .Where(s => s.ProductCategoryDiscount == discount)
                .Select(s => s.ProductCategory)
                .ToListAsync();

            return categories;
        }

        public async Task DeleteRangeAsync(ProductCategoryDiscount discounts)
        {
            var discountsCategory = await dbContext
                .DiscountCategories
                .Where(s => s.ProductCategoryDiscount == discounts)
                .ToListAsync();

            dbContext.DiscountCategories.RemoveRange(discountsCategory);
        }
    }
}