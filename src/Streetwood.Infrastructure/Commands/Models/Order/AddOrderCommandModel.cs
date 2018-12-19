using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Address;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Commands.Models.Order
{
    public class AddOrderCommandModel : IRequest
    {
        public IList<ProductWithCharmsOrderDto> Products { get; set; }

        public IList<Guid> CharmsIds { get; set; }

        public Guid ShipmentId { get; set; }

        public Guid UserId { get; set; }

        public Guid? OrderDiscountId { get; set; }

        public AddAddressCommandModel Address { get; set; }

        public string Comment { get; set; }

        public string PromoCode { get; set; }
    }
}
