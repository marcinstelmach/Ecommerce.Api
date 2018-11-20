using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using Streetwood.Core.Constants;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid GetUserId(this IIdentity identity)
        {
            if (Guid.TryParse(identity.Name, out var userId))
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
