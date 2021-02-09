namespace Streetwood.Core.Domain.Entities
{
    using System;
    using Streetwood.Core.Domain.Abstract;
    using Streetwood.Core.Domain.Enums;
    using Streetwood.Core.Exceptions;

    public class OrderShipment : Entity
    {
        public OrderShipment(Shipment shipment)
        {
            Id = Guid.NewGuid();
            SetShipment(shipment);
            Price = shipment.Price;
            UpdatedAt = DateTimeOffset.UtcNow;
            Status = ShipmentStatus.Pending;
        }

        protected OrderShipment()
        {
        }

        public virtual Shipment Shipment { get; protected set; }

        public decimal Price { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }

        public string TrackingUrl { get; protected set; }

        public string TrackingId { get; protected set; }

        public ShipmentStatus Status { get; protected set; }

        public void SetShipmentTrackingData(string trackingUrl, string trackingId)
        {
            if (TrackingId == trackingId && TrackingUrl == trackingUrl)
            {
                return;
            }

            TrackingUrl = trackingUrl;
            TrackingId = trackingId;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void Send()
        {
            if (Status != ShipmentStatus.Pending)
            {
                throw new StreetwoodException(ErrorCode.CannotSendNotPendingShipment);
            }

            Status = ShipmentStatus.InProgress;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        public void Complete()
        {
            if (Status != ShipmentStatus.InProgress)
            {
                throw new StreetwoodException(ErrorCode.CannotCompleteNotInProgressShipment);
            }

            Status = ShipmentStatus.Completed;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        private void SetShipment(Shipment shipment) => Shipment = shipment;
    }
}