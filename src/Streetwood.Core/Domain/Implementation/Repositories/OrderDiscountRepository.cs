using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class OrderDiscountRepository : Repository<OrderDiscount>, IOrderDiscountRepository
    {
        private readonly IDbContext dbContext;

        public OrderDiscountRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(OrderDiscount discount)
        {
            await dbContext.OrderDiscounts.AddAsync(discount);
        }

        public async Task<OrderDiscount> GetByCodeAsync(string code)
        {
            var discount = await dbContext
                .OrderDiscounts
                .SingleOrDefaultAsync(s => s.Code == code);

            return discount;
        }
    }
}
