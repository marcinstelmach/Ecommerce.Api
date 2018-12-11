using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IOrderDiscountQueryService
    {
        Task<IList<OrderDiscountDto>> GetAsync();
    }
}
