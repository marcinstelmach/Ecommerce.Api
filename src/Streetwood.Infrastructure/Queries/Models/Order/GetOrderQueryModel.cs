using System;
using MediatR;
using Streetwood.Core.Domain.Enums;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Order
{
    public class GetOrderQueryModel : IRequest<OrderDto>
    {
        public int Id { get; }

        public Guid UserId { get; private set; }

        public UserType UserType { get; private set; }

        public GetOrderQueryModel(int id)
        {
            Id = id;
        }

        public GetOrderQueryModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }

        public GetOrderQueryModel SetUserType(UserType userType)
        {
            UserType = userType;
            return this;
        }
    }
}
