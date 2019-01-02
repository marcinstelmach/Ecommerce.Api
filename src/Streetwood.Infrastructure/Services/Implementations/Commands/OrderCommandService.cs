using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class OrderCommandService : IOrderCommandService
    {
        public async Task AddOrderAsync(User user, IList<ProductOrder> productOrders, Shipment shipment, OrderDiscount orderDiscount)
        {
            throw new NotImplementedException();
        }
    }
}
