using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        private readonly IDbContext dbContext;

        public ProductCategoryRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(ProductCategory productCategory)
        {
            await dbContext.ProductCategories.AddAsync(productCategory);
        }

        public async Task<ProductCategory> GetWithChildrenAsync(Guid id)
        {
            return await dbContext
                .ProductCategories
                .Where(s => s.Id == id)
                .Include(s => s.ProductCategories)
                .SingleOrDefaultAsync();
        }

        public async Task<IList<ProductCategory>> GetAvailableTreeAsync()
        {
            var categories = await dbContext
                .ProductCategories
                .Where(s => s.Status == ItemStatus.Available)
                .Include(s => s.Parent)
                .Where(s => s.Parent == null)
                .Include(s => s.ProductCategories)
                .Include(s => s.DiscountCategories)
                    .ThenInclude(s => s.ProductCategoryDiscount)
                .ToListAsync();

            foreach (var category in categories)
            {
                var subCategories = category.ProductCategories.Where(s => s.Status == ItemStatus.Available).ToList();
                category.ProductCategories.Clear();
                category.ProductCategories.AddRange(subCategories);
            }

            return categories;
        }

        public async Task<IList<ProductCategory>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            var categories = await dbContext.ProductCategories
                .Where(s => ids.Contains(s.Id))
                .ToListAsync();

            return categories;
        }
    }
}
