using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IShipmentQueryService
    {
        Task<IList<ShipmentDto>> GetAsync();

        Task<ShipmentDto> GetAsync(Guid id);

        Task<Shipment> GetRawAsync(Guid id);
    }
}
