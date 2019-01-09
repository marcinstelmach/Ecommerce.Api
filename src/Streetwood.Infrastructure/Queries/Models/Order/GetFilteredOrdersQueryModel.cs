using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Order
{
    public class GetFilteredOrdersQueryModel : IRequest<IEnumerable<OrderDto>>
    {
        public Guid? Id { get; set; }

        public DateTime CreationDateTime { get; set; }

        public bool IsShipped { get; set; }

        public bool IsPayed { get; set; }

        public bool IsClosed { get; set; }
    }
}