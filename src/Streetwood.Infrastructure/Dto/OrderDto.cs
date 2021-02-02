using System;
using System.Collections.Generic;

namespace Streetwood.Infrastructure.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public decimal BasePrice { get; set; }

        public decimal FinalPrice { get; set; }

        public DateTimeOffset CreationDateTime { get; set; }

        public DateTimeOffset? ClosedDateTime { get; set; }

        public UserDto User { get; set; }

        public OrderDiscountDto OrderDiscount { get; set; }

        public AddressDto Address { get; set; }

        public OrderShipmentDto OrderShipment { get; set; }

        public OrderPaymentDto OrderPayment { get; set; }

        public IEnumerable<ProductOrderDto> ProductOrders { get; set; }
    }
}
