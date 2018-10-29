using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Shipment
{
    public class DeleteShipmentCommandModel : IRequest
    {
        public Guid Id { get; set; }

        public DeleteShipmentCommandModel(Guid id)
        {
            Id = id;
        }
    }
}
