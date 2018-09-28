using System.Threading.Tasks;

namespace Streetwood.Infrastructure.Services.Abstract.Commands.User
{
    public interface IUserCommandService
    {
        Task AddUser(string email, string firstName, string lastName, string password, int phoneNumber);
    }
}
