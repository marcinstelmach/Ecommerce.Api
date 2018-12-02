using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface IDiscountCategoryRepository : IRepository<DiscountCategory>
    {
        Task AddRangeAsync(IEnumerable<DiscountCategory> discountCategories);

        Task<IList<ProductCategory>> GetCategories(ProductCategoryDiscount discount);

        Task DeleteRangeAsync(ProductCategoryDiscount discount);
    }
}
