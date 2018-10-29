using System;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Shipment
{
    public class GetShipmentQueryModel : IRequest<ShipmentDto>
    {
        public Guid Id { get; private set; }

        public GetShipmentQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
