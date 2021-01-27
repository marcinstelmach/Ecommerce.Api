using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface IOrdersRepository : IRepository<Order>
    {
        Task AddAsync(Order order);

        Task<Order> GetFullAndEnsureExistsAsync(int id);

        Task<Order> GetAndEnsureExistAsync(int id);
    }
}
