using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Exceptions;
using Streetwood.Core.Managers;
using Streetwood.Infrastructure.Services.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class UserCommandService : IUserCommandService
    {
        private readonly IUserRepository userRepository;
        private readonly IEncrypter encrypter;
        private readonly IEmailService emailService;

        public UserCommandService(IUserRepository userRepository, IEncrypter encrypter, IEmailService emailService)
        {
            this.userRepository = userRepository;
            this.encrypter = encrypter;
            this.emailService = emailService;
        }

        public async Task AddUserAsync(string email, string firstName, string lastName, string password)
        {
            var existingUser = await userRepository.GetByEmailAsync(email);
            if (existingUser != null)
            {
                throw new StreetwoodException(ErrorCode.EmailExistInDatabase);
            }

            var user = new User(email, firstName, lastName);
            user.SetPassword(password, encrypter);
            await userRepository.AddAsync(user);
            await userRepository.SaveChangesAsync();

            await emailService.SendNewUserEmailAsync(user);
        }

        public async Task EraseUserDataAsync(Guid id)
        {
            var user = await userRepository.GetAndEnsureExistAsync(id);
            user.SetEmail("erased");
            user.SetFirstName("erased");
            user.SetLastName("Erased");
            user.SetUserStatus(UserStatus.Deleted);

            await userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserPasswordAsync(string email, string newPassword, string token)
        {
            var user = await userRepository.GetByEmailAndEnsureExistAsync(email, ErrorCode.GenericNotExist(typeof(User)));
            if (user.ChangePasswordToken != token)
            {
                throw new StreetwoodException(ErrorCode.InvalidChangePasswordToken);
            }

            user.SetPassword(newPassword, encrypter);
            user.SetChangePasswordToken();

            await userRepository.SaveChangesAsync();
        }
    }
}
