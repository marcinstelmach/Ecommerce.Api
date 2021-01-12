namespace Streetwood.Core.Domain.Implementation.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Streetwood.Core.Domain.Abstract;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Entities;

    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly IDbContext dbContext;

        public PaymentsRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await dbContext.Payments.ToArrayAsync();
        }
    }
}