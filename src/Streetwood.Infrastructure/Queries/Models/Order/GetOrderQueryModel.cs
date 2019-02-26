using System;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Order
{
    public class GetOrderQueryModel : IRequest<OrderDto>
    {
        public int Id { get; }

        public GetOrderQueryModel(int id)
        {
            Id = id;
        }
    }
}
