using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task AddAsync(ProductCategory productCategory);

        Task<ProductCategory> GetWithChildrenAsync(Guid id);

        Task<IList<ProductCategory>> GetAvailableTreeAsync();

        Task<IList<ProductCategory>> GetByIdsAsync(IEnumerable<Guid> ids);

        Task<IList<ProductCategory>> GetChildrenAsync();
    }
}
