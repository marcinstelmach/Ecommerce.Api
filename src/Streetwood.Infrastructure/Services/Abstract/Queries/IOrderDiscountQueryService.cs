using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IOrderDiscountQueryService
    {
        Task<OrderDiscount> GetRawByCodeAsync(string code);

        Task<OrderDiscountDto> GetByCodeAsync(string code);

        Task<IList<OrderDiscountDto>> GetAsync();
    }
}
