using System;
using Streetwood.Core.Domain.Enums;
using Streetwood.Infrastructure.Queries.Models.Order;

namespace Streetwood.Infrastructure.Filters
{
    using Streetwood.Infrastructure.Dto;

    public class OrderQueryFilter
    {
        public int? Id { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public ShipmentStatusDto? ShipmentStatus { get; set; }

        public PaymentStatusDto? PaymentStatus { get; set; }

        public bool? IsClosed { get; set; }

        public int? Take { get; set; }

        public Guid UserId { get; }

        public UserType UserType { get; }

        public OrderQueryFilter(GetFilteredOrdersQueryModel filter)
        {
            Id = filter.Id;
            DateFrom = filter.DateFrom;
            DateTo = filter.DateTo;
            ShipmentStatus = filter.IsShipped;
            PaymentStatus = filter.PaymentStatus;
            IsClosed = filter.IsClosed;
            Take = filter.Take;
            UserId = filter.UserId;
            UserType = filter.UserType;
        }
    }
}
