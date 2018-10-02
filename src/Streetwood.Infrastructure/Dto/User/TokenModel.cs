using System;

namespace Streetwood.Infrastructure.Dto.User
{
    public class TokenModel
    {
        public Guid UserId { get; protected set; }

        public string Email { get; protected set; }

        public string Token { get; protected set; }

        public DateTime Expires { get; protected set; }

        public string RefreshToken { get; protected set; }

        public TokenModel(Guid userId, string email, string token, DateTime expires, string refreshToken)
        {
            UserId = userId;
            Email = email;
            Token = token;
            Expires = expires;
            RefreshToken = refreshToken;
        }
    }
}
