using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Filters;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IOrderQueryService
    {
        Task<OrderDto> GetAsync(Guid id);

        Task<IList<OrderDto>> GetFilteredAsync(OrderQueryFilter filter);
    }
}
