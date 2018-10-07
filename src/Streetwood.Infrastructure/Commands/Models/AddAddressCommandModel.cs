using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models
{
    public class AddAddressCommandModel : IRequest
    {
        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string PostCode { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public Guid UserId { get; protected set; }

        public AddAddressCommandModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}
