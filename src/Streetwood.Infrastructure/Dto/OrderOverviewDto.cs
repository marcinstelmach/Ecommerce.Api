using System;

namespace Streetwood.Infrastructure.Dto
{
    public class OrderOverviewDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public ShipmentStatusDto ShipmentStatus { get; set; }

        public PaymentStatusDto PaymentStatus { get; set; }

        public bool IsClosed { get; set; }

        public decimal FinalPrice { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}