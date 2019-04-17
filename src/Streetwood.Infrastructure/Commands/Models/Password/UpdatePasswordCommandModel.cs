using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Password
{
    public class UpdatePasswordCommandModel : IRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare(nameof(NewPassword))]
        public string ConfirmNewPassword { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
