using System;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.User
{
    public class GetUserByIdQueryModel : IRequest<UserDto>
    {
        public Guid Id { get; }

        public GetUserByIdQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
