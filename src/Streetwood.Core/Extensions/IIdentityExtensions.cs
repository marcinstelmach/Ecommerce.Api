using System;
using System.Security.Principal;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Extensions
{
    public static class IIdentityExtensions
    {
        public static Guid GetUserId(this IIdentity identity)
        {
            if (Guid.TryParse(identity.Name, out var userId))
            {
                return userId;
            }
            throw new StreetwoodException(ErrorCode.InvalidUserClaimName);
        }
    }
}
