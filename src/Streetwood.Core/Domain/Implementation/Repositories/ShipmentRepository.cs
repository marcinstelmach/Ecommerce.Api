using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Core.Domain.Implementation.Repositories
{
    internal class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        private readonly IDbContext dbContext;

        public ShipmentRepository(IDbContext dbContext)
            : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Shipment shipment)
        {
            await dbContext.Shipments.AddAsync(shipment);
        }
    }
}
