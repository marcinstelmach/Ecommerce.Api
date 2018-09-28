using System;
using MediatR;
using Streetwood.Infrastructure.Dto.User;

namespace Streetwood.Infrastructure.Queries.Models.User
{
    public class GetUserByIdQueryModel : IRequest<UserDto>, IRequest<Unit>
    {
        public Guid Id { get; }

        public GetUserByIdQueryModel(Guid id)
        {
            Id = id;
        }
    }
}
