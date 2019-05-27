using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using Streetwood.Infrastructure.CustomValidators;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Commands.Models.Order
{
    [AddOrderAddressValidator]
    public class AddOrderCommandModel : IRequest<int>
    {
        [Required]
        public IList<ProductWithCharmsOrderDto> Products { get; set; }

        [Required]
        public Guid ShipmentId { get; set; }

        [Required]
        public Guid UserId { get; protected set; }

        public NewAddressDto Address { get; set; }

        public Guid? AddressId { get; set; }

        public string Comment { get; set; }

        public string PromoCode { get; set; }

        public AddOrderCommandModel SetUserId(Guid id)
        {
            UserId = id;
            return this;
        }
    }
}
