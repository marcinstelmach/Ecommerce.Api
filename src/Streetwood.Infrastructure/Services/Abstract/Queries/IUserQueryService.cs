using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto.User;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IUserQueryService
    {
        Task<IList<UserDto>> GetAsync();

        Task<UserDto> GetByIdAsync(Guid id);

        Task<TokenModel> GetTokenAsync(string email, string password);

        Task<TokenModel> RefreshToken(string jwtToken, string refreshToken);
    }
}
