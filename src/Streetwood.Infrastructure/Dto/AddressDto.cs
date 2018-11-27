using System;
using System.Collections.Generic;
using System.Text;

namespace Streetwood.Infrastructure.Dto
{
    public class AddressDto
    {
        public Guid Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PostCode { get; set; }
    }
}
