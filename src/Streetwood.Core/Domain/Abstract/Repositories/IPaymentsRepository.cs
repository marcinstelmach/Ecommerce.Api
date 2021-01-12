namespace Streetwood.Core.Domain.Abstract.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Streetwood.Core.Domain.Entities;

    public interface IPaymentsRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync();
    }
}