namespace Streetwood.Infrastructure.Services.Abstract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Streetwood.Core.Domain.Entities;

    public interface IOrderFactory
    {
        Task<Order> CreateOrderAsync(User user, IList<ProductOrder> productOrders, Shipment shipment, Payment payment,
            OrderDiscount orderDiscount, string comment, Address address);
    }
}
