using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey)),
                    SecurityAlgorithms.HmacSha256);
            var expires = now.AddMinutes(options.ExpiresMinutes);

            var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            var refreshToken = GetRefreshToken();
            return new TokenModel(userId, email, token, expires, refreshToken);
        }

        public Guid GetUserIdFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = options.Issuer,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var userId = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken).Identity.GetUserId();
            return userId;
        }

        private string GetRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
