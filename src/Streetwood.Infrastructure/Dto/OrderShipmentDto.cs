namespace Streetwood.Infrastructure.Dto
{
    using System;

    public class OrderShipmentDto
    {
        public Guid Id { get; set; }

        public ShipmentDto Shipment { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string TrackingUrl { get; set; }

        public string TrackingId { get; set; }

        public ShipmentStatusDto Status { get; set; }
    }
}