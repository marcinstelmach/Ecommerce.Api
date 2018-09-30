using System;
using Streetwood.Infrastructure.Dto.User;

namespace Streetwood.Infrastructure.Managers.Abstract
{
    public interface ITokenManager
    {
        TokenModel GetToken(Guid userId, string email);
    }
}
