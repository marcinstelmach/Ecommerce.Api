using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Address;

namespace Streetwood.Infrastructure.Commands.Models.Order
{
    public class AddOrderCommandModel : IRequest
    {
        public IList<int> ProductsIds { get; set; }

        public IList<Guid> CharmsIds { get; set; }

        public Guid ShipmentId { get; set; }

        public Guid UserId { get; set; }

        public Guid? OrderDiscountId { get; set; }

        public AddAddressCommandModel Address { get; set; }

    }
}
