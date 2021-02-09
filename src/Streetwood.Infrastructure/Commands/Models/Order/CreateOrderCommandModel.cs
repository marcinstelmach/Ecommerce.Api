using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Commands.Models.Order
{
    public class CreateOrderCommandModel : IRequest<int>
    {
        public IList<ProductWithCharmsOrderDto> Products { get; set; }

        public Guid ShipmentId { get; set; }

        public Guid PaymentId { get; set; }

        public Guid UserId { get; set; }

        public NewAddressDto Address { get; set; }

        public Guid? AddressId { get; set; }

        public string Comment { get; set; }

        public string PromoCode { get; set; }
    }
}
