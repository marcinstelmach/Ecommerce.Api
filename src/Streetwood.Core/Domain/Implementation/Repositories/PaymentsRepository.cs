namespace Streetwood.Core.Domain.Implementation.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Streetwood.Core.Domain.Abstract;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Entities;
    using Streetwood.Core.Exceptions;
    using Streetwood.Core.Extensions;

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

        public async Task<Payment> GetPaymentAsync(Guid id)
        {
            return await dbContext.Payments.FindAndEnsureExistsAsync(x => x.Id == id, ErrorCode.PaymentDoesNotExists);
        }
    }
}