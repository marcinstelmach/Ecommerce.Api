using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task AddAsync(ProductCategory productCategory);

        Task<ProductCategory> GetWithChildren(Guid id);
    }
}
