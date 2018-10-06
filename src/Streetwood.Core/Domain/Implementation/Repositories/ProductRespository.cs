using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;

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

        public async Task<Product> GetAsync(int id)
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
    }
}
