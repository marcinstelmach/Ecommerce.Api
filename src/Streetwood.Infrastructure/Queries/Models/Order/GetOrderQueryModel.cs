using System;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Order
{
    public class GetOrderQueryModel : IRequest<OrderDto>
    {
        public Guid Id { get; }

        public GetOrderQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
