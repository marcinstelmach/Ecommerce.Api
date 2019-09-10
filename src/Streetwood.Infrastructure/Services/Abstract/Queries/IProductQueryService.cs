using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IProductQueryService
    {
        Task<IList<ProductListDto>> GetAsync();

        Task<ProductDto> GetAsync(int id);

        Task<IList<ProductDto>> GetAvailableByCategoryIdAsync(Guid id);

        Task<IList<ProductWithDiscountDto>> GetAvailableWithDiscountByCategoryIdAsync(Guid id);

        Task<IList<Product>> GetRawByIdsAsync(IList<int> ids);
    }
}
