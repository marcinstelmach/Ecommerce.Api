using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

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
    }
}
