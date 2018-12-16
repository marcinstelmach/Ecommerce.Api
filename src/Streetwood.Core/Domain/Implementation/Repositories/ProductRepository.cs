using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IDbContext dbContext;

        public ProductRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> GetAndEnsureExistAsync(int id)
        {
            var product = await dbContext
                .Products
                .Where(s => s.Id == id)
                .Include(s => s.Images)
                .SingleOrDefaultAsync();

            if (product == null)
            {
                throw new StreetwoodException(ErrorCode.ProductNotFound);
            }

            return product;
        }

        public async Task<IList<Product>> GetByIdsAsync(IEnumerable<int> ids)
        {
            var products = await dbContext
                .Products
                .Where(s => ids.Contains(s.Id))
                .Include(s => s.ProductCategory)
                .ToListAsync();

            return products;
        }
    }
}
