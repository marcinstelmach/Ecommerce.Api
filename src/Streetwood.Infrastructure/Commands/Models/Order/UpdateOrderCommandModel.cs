namespace Streetwood.Infrastructure.Commands.Models.Order
{
    using MediatR;
    using Streetwood.Infrastructure.Dto;

    public class UpdateOrderCommandModel : IRequest
    {
        public int Id { get; set; }

        public PaymentStatusDto PaymentStatus { get; set; }

        public ShipmentStatusDto ShipmentStatus { get; set; }

        public string ShipmentTrackingUrl { get; set; }

        public string ShipmentTrackingId { get; set; }
    }
}
