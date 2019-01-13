using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Order
{
    public class GetFilteredOrdersQueryModel : IRequest<IEnumerable<OrderDto>>
    {
        public Guid? Id { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public bool? IsShipped { get; set; }

        public bool? IsPayed { get; set; }

        public bool? IsClosed { get; set; }

        public GetFilteredOrdersQueryModel(Guid? id, DateTime? dateFrom, DateTime? dateTo, bool? isShipped, bool? isPayed, bool? isClosed)
        {
            Id = id;
            DateFrom = dateFrom;
            DateTo = dateTo;
            IsShipped = isShipped;
            IsPayed = isPayed;
            IsClosed = isClosed;
        }
    }
}