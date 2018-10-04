using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        Task AddAsync(Shipment shipment);
    }
}
