using System;
using Streetwood.Infrastructure.Queries.Models.Order;

namespace Streetwood.Infrastructure.Filters
{
    public class OrderQueryFilter : GetFilteredOrdersQueryModel
    {
        public OrderQueryFilter(Guid? id, DateTime? dateFrom, DateTime? dateTo, bool? isShipped, bool? isPayed, bool? isClosed)
            : base(id, dateFrom, dateTo, isShipped, isPayed, isClosed)
        {
        }
    }
}
