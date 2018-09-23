using System;
using System.Collections.Generic;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Models
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int PhoneNumber { get; set; }
        public UserType Type { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}