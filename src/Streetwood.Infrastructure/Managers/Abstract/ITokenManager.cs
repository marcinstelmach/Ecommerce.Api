using System;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface ITokenManager
    {
        TokenModel GetToken(Guid userId, string email, string role);

        Guid GetUserIdFromExpiredToken(string token);
    }
}
