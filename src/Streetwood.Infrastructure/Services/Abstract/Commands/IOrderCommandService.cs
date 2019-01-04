using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IOrderCommandService
    {
        Task<Guid> AddOrderAsync(User user, IList<ProductOrder> productOrders, Shipment shipment, OrderDiscount orderDiscount, string comment);
    }
}
