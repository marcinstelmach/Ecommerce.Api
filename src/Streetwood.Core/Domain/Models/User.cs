using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Streetwood.Core.Domain.Abstract;
using Streetwood.Core.Domain.Enums;

namespace Streetwood.Core.Domain.Models
{
    public class User : Entity
    {
        [MaxLength(50)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(40)]
        public string LastName { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int PhoneNumber { get; set; }
        public UserType Type { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}