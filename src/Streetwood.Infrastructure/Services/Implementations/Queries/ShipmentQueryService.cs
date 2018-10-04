using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class ShipmentQueryService : IShipmentQueryService
    {
        private readonly IShipmentRepository shipmentRepository;
        private readonly IMapper mapper;

        public ShipmentQueryService(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            this.shipmentRepository = shipmentRepository;
            this.mapper = mapper;
        }

        public async Task<IList<ShipmentDto>> GetAsync()
        {
            var shipment = await shipmentRepository.GetAsync();
            return mapper.Map<IList<ShipmentDto>>(shipment);
        }
    }
}
