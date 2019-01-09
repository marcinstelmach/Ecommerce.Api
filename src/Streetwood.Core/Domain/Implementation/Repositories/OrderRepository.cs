using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IDbContext dbContext;

        public OrderRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Order order)
            => await dbContext.Orders.AddAsync(order);

        public async Task<Order> GetFullAsync(Guid id)
        {
            var order = await dbContext
                .Orders
                .Where(s => s.Id == id)
                .Include(s => s.Address)
                .Include(s => s.OrderDiscount)
                .Include(s => s.Shipment)
                .Include(s => s.User)
                .Include(s => s.ProductOrders)
                    .ThenInclude(s => s.ProductCategoryDiscount)
                .Include(s => s.ProductOrders)
                    .ThenInclude(s => s.Product)
                        .ThenInclude(s => s.Images)
                .Include(s => s.ProductOrders)
                    .ThenInclude(s => s.ProductOrderCharms)
                        .ThenInclude(s => s.Charm)
                .SingleOrDefaultAsync();

            if (order == null)
            {
                throw new StreetwoodException(ErrorCode.GenericNotExist(typeof(Order), $"Order id: {id} not found"));
            }

            return order;
        }
    }
}
