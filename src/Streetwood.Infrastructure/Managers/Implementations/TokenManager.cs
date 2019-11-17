using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Streetwood.Core.Extensions;
using Streetwood.Core.Settings;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Managers.Implementations
{
    internal class TokenManager : ITokenManager
    {
        private readonly JwtSettings settings;

        public TokenManager(IOptions<JwtSettings> options)
        {
            this.settings = options.Value;
        }

        public TokenModel GetToken(Guid userId, string email, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.Role, role)
            };

            var signingCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey)),
                    SecurityAlgorithms.HmacSha256);
            var expires = now.AddMinutes(settings.ExpiresMinutes);

            var jwt = new JwtSecurityToken(
                issuer: settings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            var refreshToken = GetRefreshToken();
            return new TokenModel(userId, email, token, expires, refreshToken, role);
        }

        public Guid GetUserIdFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = settings.Issuer,
                ValidateLifetime = false,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var userId = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken).GetUserId();
            return userId;
        }

        private static string GetRefreshToken()
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
