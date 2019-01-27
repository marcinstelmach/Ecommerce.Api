using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface IProductCategoryDiscountRepository : IRepository<ProductCategoryDiscount>
    {
        Task AddAsync(ProductCategoryDiscount productCategoryDiscount);

        Task<IList<ProductCategoryDiscount>> GetActiveAsync();

        Task<List<ProductCategoryDiscount>> GetActiveByCategoryId(Guid id);
    }
}
