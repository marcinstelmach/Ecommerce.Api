using System;
using System.Collections.Generic;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.Address
{
    public class GetUserAddressesQueryModel : IRequest<IList<AddressDto>>
    {
        public Guid UserId { get; protected set; }

        public GetUserAddressesQueryModel(Guid userId)
        {
            UserId = userId;
        }
    }
}
