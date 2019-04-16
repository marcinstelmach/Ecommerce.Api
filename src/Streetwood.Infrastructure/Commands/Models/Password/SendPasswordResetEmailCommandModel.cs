using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Password
{
    public class SendPasswordResetEmailCommandModel : IRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
