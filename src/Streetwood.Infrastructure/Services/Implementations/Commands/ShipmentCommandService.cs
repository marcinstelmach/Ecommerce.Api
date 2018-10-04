using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class ShipmentCommandService : IShipmentCommandService
    {
        private readonly IShipmentRepository shipmentRepository;

        public ShipmentCommandService(IShipmentRepository shipmentRepository)
        {
            this.shipmentRepository = shipmentRepository;
        }

        public async Task AddAsync(string name, string nameEng, string description, string descriptionEng, decimal price, bool isActive, ShipmentType type)
        {
            await shipmentRepository.AddAsync(new Shipment(name, nameEng, description, descriptionEng, price, isActive, type));
            await shipmentRepository.SaveChangesAsync();
        }
    }
}
