namespace Streetwood.API.ViewModels.Orders
{
    using System.ComponentModel.DataAnnotations;
    using Streetwood.Infrastructure.Dto;

    public class UpdateOrderViewModel
    {
        [Required]
        public PaymentStatusDto? PaymentStatus { get; set; }

        [Required]
        public ShipmentStatusDto? ShipmentStatus { get; set; }

        public string ShipmentTrackingUrl { get; set; }

        public string ShipmentTrackingId { get; set; }
    }
}