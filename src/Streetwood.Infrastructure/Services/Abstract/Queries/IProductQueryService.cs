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

        Task<IList<ProductDto>> GetByCategoryIdAsync(Guid id);

        Task<IList<Product>> GetRawByIds(IEnumerable<int> ids);
    }
}
