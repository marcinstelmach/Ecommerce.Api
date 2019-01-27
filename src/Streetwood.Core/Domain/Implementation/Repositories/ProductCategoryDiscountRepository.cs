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
            await dbContext
                .ProductCategoryDiscounts
                .AddAsync(productCategoryDiscount);
        }

        public async Task<IList<ProductCategoryDiscount>> GetActiveAsync()
        {
            var enabledDiscounts = await dbContext.ProductCategoryDiscounts
                .Where(s => s.IsActive)
                .Include(s => s.DiscountCategories)
                .ToListAsync();

            return enabledDiscounts;
        }

        public async Task<List<ProductCategoryDiscount>> GetActiveByCategoryId(Guid id)
        {
            var discounts = await dbContext.DiscountCategories
                .Where(s => s.ProductCategory.Id == id)
                .Where(s => s.ProductCategoryDiscount.IsActive)
                .Select(s => s.ProductCategoryDiscount)
                .ToListAsync();

            return discounts;
        }
    }
}
