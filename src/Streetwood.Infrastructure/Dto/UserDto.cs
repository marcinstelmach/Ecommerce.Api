using System;

namespace Streetwood.Infrastructure.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public DateTime CreationDateTime { get; set; }
    }
}
