using System;
using System.Diagnostics.SymbolStore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Extensions;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Dto.User;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class TokenManager : ITokenManager
    {
        private readonly JwtOptions options;

        public TokenManager(IOptions<JwtOptions> options)
        {
            this.options = options.Value;
        }

        public TokenModel GetToken(Guid userId, string email)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString())
            };

            var signingCredentials =
                new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                    SecurityAlgorithms.HmacSha256);
            var expires = now.AddMinutes(options.ExpiresMinutes);

            var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return new TokenModel(userId, email, token, expires);
        }
    }
}
