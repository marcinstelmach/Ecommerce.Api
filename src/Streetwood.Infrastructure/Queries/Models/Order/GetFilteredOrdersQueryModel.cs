using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Order
{
    public class GetFilteredOrdersQueryModel : IRequest<IEnumerable<OrdersListDto>>
    {
        public int? Id { get; }

        public DateTime? DateFrom { get; }

        public DateTime? DateTo { get; private set; }

        public bool? IsShipped { get; }

        public bool? IsPayed { get; }

        public bool? IsClosed { get; }

        public int? Take { get; set; }

        public GetFilteredOrdersQueryModel(int? id, DateTime? dateFrom, DateTime? dateTo, bool? isShipped, bool? isPayed, bool? isClosed, int? take)
        {
            Id = id;
            DateFrom = dateFrom;
            SetDateTo(dateTo);
            IsShipped = isShipped;
            IsPayed = isPayed;
            IsClosed = isClosed;
            Take = take;
        }

        public void SetDateTo(DateTime? dateTo)
        {
            dateTo = dateTo?.AddDays(1);
            DateTo = dateTo;
        }
    }
}