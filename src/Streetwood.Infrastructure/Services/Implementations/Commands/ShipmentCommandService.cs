using System;
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

        public async Task AddAsync(string name, string nameEng, string description, string descriptionEng, decimal price, ShipmentType type)
        {
            await shipmentRepository.AddAsync(new Shipment(name, nameEng, description, descriptionEng, price, type));
            await shipmentRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string name, string nameEng, string description, string descriptionEng, bool isActive, decimal price, ShipmentType type)
        {
            var shipment = await shipmentRepository.GetAndEnsureExistAsync(id);
            shipment.SetName(name);
            shipment.SetEngName(nameEng);
            shipment.SetDescription(description);
            shipment.SetDescriptionEng(descriptionEng);
            shipment.SetIsActive(isActive);
            shipment.SetPrice(price);
            shipment.SetType(type);

            await shipmentRepository.SaveChangesAsync();
        }
    }
}
