using System;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IProductCategoryQueryService
    {
        Task<ProductCategoryDto> GetProductCategoryByIdAsync(Guid id);
    }
}
