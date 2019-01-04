using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Address;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Commands.Models.Order
{
    public class AddOrderCommandModel : IRequest<Guid>
    {
        [Required]
        public IList<ProductWithCharmsOrderDto> Products { get; set; }

        [Required]
        public Guid ShipmentId { get; set; }

        [Required]
        public Guid UserId { get; protected set; }

        [Required]
        public AddAddressCommandModel Address { get; set; }

        public string Comment { get; set; }

        public string PromoCode { get; set; }

        public AddOrderCommandModel SetUserId(Guid id)
        {
            UserId = id;
            return this;
        }
    }
}
