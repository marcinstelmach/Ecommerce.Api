using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Streetwood.Core.Domain.Abstract;

namespace Streetwood.Core.Domain.Models
{
    public class Address : Entity
    {
        [MaxLength(50)]
        public string Street { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string PostCode { get; set; }
        [MaxLength(6)]
        public int PhoneNumber { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}