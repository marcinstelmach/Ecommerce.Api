using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Models
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}