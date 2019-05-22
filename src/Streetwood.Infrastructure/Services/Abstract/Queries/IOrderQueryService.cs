using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Filters;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IOrderQueryService
    {
        Task<OrderDto> GetAsync(int id);

        Task<Order> GetRawAndEnsureExistsAsync(int id);

        Task<IList<OrdersListDto>> GetFilteredAsync(OrderQueryFilter filter);
    }
}
