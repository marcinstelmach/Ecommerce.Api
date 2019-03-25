using System.ComponentModel.DataAnnotations;

namespace Streetwood.Infrastructure.Commands.Models.Address
{
    public class AddAddressCommandModel
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
    }
}
