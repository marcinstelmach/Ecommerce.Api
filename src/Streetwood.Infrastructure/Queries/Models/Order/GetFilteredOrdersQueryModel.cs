using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Core.Domain.Enums;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Order
{
    public class GetFilteredOrdersQueryModel : IRequest<IEnumerable<OrdersListDto>>
    {
        private DateTime? dateTo;

        public int? Id { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo
        {
            get => dateTo?.AddDays(1) ?? dateTo;
            set => dateTo = value;
        }

        public ShipmentStatusDto? IsShipped { get; set; }

        public PaymentStatusDto? PaymentStatus { get; set; }

        public bool? IsClosed { get; set; }

        public int? Take { get; set; }

        public Guid UserId { get; private set; }

        public UserType UserType { get; private set; }

        public GetFilteredOrdersQueryModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }

        public GetFilteredOrdersQueryModel SetUserType(UserType userType)
        {
            UserType = userType;
            return this;
        }
    }
}