using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Managers;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class UserCommandService : IUserCommandService
    {
        private readonly IUserRepository userRepository;
        private readonly IEncrypter encrypter;

        public UserCommandService(IUserRepository userRepository, IEncrypter encrypter)
        {
            this.userRepository = userRepository;
            this.encrypter = encrypter;
        }

        public async Task AddUserAsync(string email, string firstName, string lastName, string password, int phoneNumber)
        {
            var user = new User(email, firstName, lastName, phoneNumber);
            user.SetPassword(password, encrypter);
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
        }
    }
}
