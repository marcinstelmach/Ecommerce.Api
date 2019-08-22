using System;
using Streetwood.Core.Domain.Enums;
using Streetwood.Infrastructure.Queries.Models.Order;

namespace Streetwood.Infrastructure.Filters
{
    public class OrderQueryFilter
    {
        public int? Id { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public bool? IsShipped { get; set; }

        public bool? IsPayed { get; set; }

        public bool? IsClosed { get; set; }

        public int? Take { get; set; }

        public Guid UserId { get; }

        public UserType UserType { get; }

        public OrderQueryFilter(GetFilteredOrdersQueryModel filter)
        {
            Id = filter.Id;
            DateFrom = filter.DateFrom;
            DateTo = filter.DateTo;
            IsShipped = filter.IsShipped;
            IsPayed = filter.IsPayed;
            IsClosed = filter.IsClosed;
            Take = filter.Take;
            UserId = filter.UserId;
            UserType = filter.UserType;
        }
    }
}
