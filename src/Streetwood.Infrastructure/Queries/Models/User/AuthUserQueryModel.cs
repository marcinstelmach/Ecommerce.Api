using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.User
{
    public class AuthUserQueryModel : IRequest<TokenModel>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
