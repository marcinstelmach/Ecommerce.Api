using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task AddAsync(Order order);

        Task<Order> GetFullAsync(int id);

        Task<Order> GetAndEnsureExistAsync(int id);
    }
}
