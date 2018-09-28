using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Managers;
using Streetwood.Infrastructure.Services.Abstract.Commands.User;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    public class UserCommandService : IUserCommandService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordEncrypter passwordEncrypter;

        public UserCommandService(IUserRepository userRepository, IPasswordEncrypter passwordEncrypter)
        {
            this.userRepository = userRepository;
            this.passwordEncrypter = passwordEncrypter;
        }

        public async Task AddUser(string email, string firstName, string lastName, string password, int phoneNumber)
        {
            var user = new User(email, firstName, lastName, phoneNumber);
            user.SetPassword(password, passwordEncrypter);
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
        }
    }
}
