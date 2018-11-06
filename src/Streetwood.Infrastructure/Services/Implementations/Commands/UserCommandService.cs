using System;
using System.Linq;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Exceptions;
using Streetwood.Core.Managers;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class UserCommandService : IUserCommandService
    {
        private readonly IUserRepository userRepository;
        private readonly IEncrypter encrypter;
        private readonly IAddressCommandService addressCommandService;

        public UserCommandService(IUserRepository userRepository, IEncrypter encrypter, IAddressCommandService addressCommandService)
        {
            this.userRepository = userRepository;
            this.encrypter = encrypter;
            this.addressCommandService = addressCommandService;
        }

        public async Task AddUserAsync(string email, string firstName, string lastName, string password, int phoneNumber)
        {
            var existingUser = await userRepository.GetByEmailAsync(email);
            if (existingUser != null)
            {
                throw new StreetwoodException(ErrorCode.EmailExistInDatabase);
            }

            var user = new User(email, firstName, lastName, phoneNumber);
            user.SetPassword(password, encrypter);
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();
        }

        public async Task EraseUserDataAsync(Guid id)
        {
            var user = await userRepository.GetAndEnsureExistAsync(id);
            user.SetEmail("erased");
            user.SetFirstName("erased");
            user.SetLastName("Erased");
            user.SetPhoneNumber(000000000);
            user.SetUserStatus(UserStatus.Deactivated);

            await userRepository.SaveChangesAsync();

            var addresses = user.Addresses.ToList();
            await addressCommandService.EraseDataAsync(addresses);
        }
    }
}
