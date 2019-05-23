using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Streetwood.Infrastructure.Commands.Models.Email
{
    public class SendPasswordResetEmailCommandModel : IRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; }

        public SendPasswordResetEmailCommandModel(string email)
        {
            Email = email;
        }
    }
}
