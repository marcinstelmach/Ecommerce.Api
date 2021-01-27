using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IOrderCommandService
    {
        Task<Order> AddAsync(User user, IList<ProductOrder> productOrders, Shipment shipment, Payment payment,
            OrderDiscount orderDiscount, string comment, Address address);

        Task UpdateAsync(int id, bool payed, bool shipped, bool closed);
    }
}
