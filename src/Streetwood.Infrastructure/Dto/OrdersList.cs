using System;

namespace Streetwood.Infrastructure.Dto
{
    public class OrdersList
    {
        public Guid Id { get; set; }

        public bool IsShipped { get; set; }

        public bool IsPayed { get; set; }

        public bool IsClosed { get; set; }

        public string Comment { get; set; }

        public decimal BasePrice { get; set; }

        public decimal ShipmentPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public DateTime CreationDateTime { get; set; }

        public DateTime? PayedDateTime { get; set; }

        public DateTime? ShipmentDateTime { get; set; }

        public DateTime? ClosedDateTime { get; set; }
    }
}