using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface IOrderDiscountRepository : IRepository<OrderDiscount>
    {
        Task AddAsync(OrderDiscount discount);

        Task<OrderDiscount> GetByCodeAsync(string code);
    }
}
