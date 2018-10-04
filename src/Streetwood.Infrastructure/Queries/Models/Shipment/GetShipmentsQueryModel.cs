using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Shipment
{
    public class GetShipmentsQueryModel : IRequest<IList<ShipmentDto>>
    {
    }
}
