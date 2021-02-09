namespace Streetwood.API.ViewModels.Orders
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Streetwood.API.CustomValidators;
    using Streetwood.Infrastructure.Dto;

    [OrderAddressValidator]
    public class CreateOrderViewModel
    {
        [Required]
        public IList<ProductWithCharmsOrderDto> Products { get; set; }

        [Required]
        public Guid? ShipmentId { get; set; }

        [Required]
        public Guid? PaymentId { get; set; }

        public NewAddressDto Address { get; set; }

        public Guid? AddressId { get; set; }

        public string Comment { get; set; }

        public string PromoCode { get; set; }
    }
}