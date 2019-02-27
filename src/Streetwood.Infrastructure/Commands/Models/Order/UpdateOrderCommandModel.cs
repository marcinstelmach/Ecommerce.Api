using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Order
{
    public class UpdateOrderCommandModel : IRequest
    {
        public int Id { get; protected set; }

        public DateTime? PayedDateTime { get; set; }

        public DateTime? ShipmentDateTime { get; set; }

        public DateTime? ClosedDateTime { get; set; }

        public UpdateOrderCommandModel SetId(int id)
        {
            Id = id;
            return this;
        }
    }
}
