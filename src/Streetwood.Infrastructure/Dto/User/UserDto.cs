using System;

namespace Streetwood.Infrastructure.Dto.User
{
    public class UserDto
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreationDateTime { get; set; }

        public int PhoneNumber { get; set; }
    }
}
