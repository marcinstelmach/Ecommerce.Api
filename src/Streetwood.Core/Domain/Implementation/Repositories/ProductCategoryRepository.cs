using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

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

        public async Task<ProductCategory> GetWithChildren(Guid id)
        {
            var result = await dbContext
                .ProductCategories
                .Where(s => s.Id == id)
                .Include(s => s.ProductCategories)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
