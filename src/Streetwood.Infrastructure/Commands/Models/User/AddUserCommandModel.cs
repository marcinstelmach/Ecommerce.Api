using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.User
{
    public class AddUserCommandModel : IRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public int PhoneNumber { get; set; }
    }
}
