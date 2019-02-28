using System;
using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IUserCommandService
    {
        Task AddUserAsync(string email, string firstName, string lastName, string password);

        Task EraseUserDataAsync(Guid id);
    }
}
