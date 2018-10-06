using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IProductQueryService
    {
        Task<IList<ProductListDto>> GetAsync();

        Task<ProductDto> GetAsync(int id);
    }
}
