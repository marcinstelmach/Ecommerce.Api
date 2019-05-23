using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;

namespace Streetwood.Core.Domain.Abstract.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddAsync(User user);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetByEmailAndEnsureExistAsync(string email, ErrorCode errorCode);
    }
}
