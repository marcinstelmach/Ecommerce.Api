using System;
using MediatR;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.User
{
    public class GetUserByIdQueryModel : IRequest<UserDto>
    {
        public Guid Id { get; }

        public Guid CurrentUserId { get; }

        public GetUserByIdQueryModel(Guid id, Guid currentUserId)
        {
            Id = id;
            CurrentUserId = currentUserId;
            Validate();
        }

        private void Validate()
        {
            if (Id != CurrentUserId)
            {
                throw new StreetwoodException(ErrorCode.NoAccess);
            }
        }
    }
}
