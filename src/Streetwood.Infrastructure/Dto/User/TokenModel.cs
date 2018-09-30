using System;
using System.Collections.Generic;
using System.Text;

namespace Streetwood.Infrastructure.Dto.User
{
    public class TokenModel
    {
        public Guid UserId { get; protected set; }

        public string Email { get; protected set; }

        public string Token { get; protected set; }

        public DateTime Expires { get; protected set; }

        public TokenModel(Guid userId, string email, string token, DateTime expires)
        {
            UserId = userId;
            Email = email;
            Token = token;
            Expires = expires;
        }
    }
}
