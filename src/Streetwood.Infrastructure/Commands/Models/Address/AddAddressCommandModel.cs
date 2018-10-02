using System;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Address
{
    public class AddAddressCommandModel : IRequest
    {
        public string City { get; set; }

        public string Street { get; set; }

        public string PostCode { get; set; }

        public int PhoneNumber { get; set; }

        public string Country { get; set; }

        public Guid UserId { get; protected set; }

        public AddAddressCommandModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}
