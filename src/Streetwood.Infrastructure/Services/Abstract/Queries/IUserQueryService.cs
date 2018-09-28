using System;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto.User;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IUserQueryService
    {
        Task<UserDto> GetByIdAsync(Guid id);
    }
}
