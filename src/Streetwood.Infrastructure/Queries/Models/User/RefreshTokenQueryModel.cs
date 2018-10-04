using System;
using MediatR;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Queries.Models.User
{
    public class RefreshTokenQueryModel : IRequest<TokenModel>
    {
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
