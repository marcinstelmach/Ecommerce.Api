using System.ComponentModel.DataAnnotations;

namespace Streetwood.Infrastructure.Dto
{
    public class NewAddressDto
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
