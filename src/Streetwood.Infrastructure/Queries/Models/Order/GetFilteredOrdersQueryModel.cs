using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Core.Domain.Enums;
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

        public Guid UserId { get; }

        public UserType UserType { get; }

        public GetFilteredOrdersQueryModel(int? id, DateTime? dateFrom, DateTime? dateTo, bool? isShipped, bool? isPayed, bool? isClosed, int? take, Guid userId, UserType userType)
        {
            Id = id;
            DateFrom = dateFrom;
            SetDateTo(dateTo);
            IsShipped = isShipped;
            IsPayed = isPayed;
            IsClosed = isClosed;
            Take = take;
            UserId = userId;
            UserType = userType;
        }

        public void SetDateTo(DateTime? dateTo)
        {
            dateTo = dateTo?.AddDays(1);
            DateTo = dateTo;
        }
    }
}