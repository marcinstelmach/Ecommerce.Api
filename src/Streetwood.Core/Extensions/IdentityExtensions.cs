using System;
using System.Linq;
using System.Security.Claims;
using Streetwood.Core.Constants;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
            if (Guid.TryParse(principal.Identity.Name, out var userId))
            {
                return userId;
            }

            throw new StreetwoodException(ErrorCode.InvalidUserClaimName);
        }

        public static UserType GetUserType(this ClaimsPrincipal claimsPrincipal)
        {
            var claims = claimsPrincipal.Claims.ToList();

            if (!claims.Any())
            {
                return UserType.None;
            }

            var role = claims.FirstOrDefault(s => s.Type == ConstantValues.IdentityRoleName)?.Value ?? string.Empty;

            if (!Enum.TryParse(typeof(UserType), role, true, out var type))
            {
                return UserType.None;
            }

            return (UserType)type;
        }
    }
}
