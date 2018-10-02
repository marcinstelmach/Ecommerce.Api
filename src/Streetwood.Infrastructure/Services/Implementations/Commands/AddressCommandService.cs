using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract.Commands.Address;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class AddressCommandService : IAddressCommandService
    {
        private readonly IUserRepository userRepository;

        public AddressCommandService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task AddAsync(string city, string street, string postCode, int phoneNumber, string country, Guid userId)
        {
            var user = await userRepository.GetAsync(userId);
            var address = new Address(street, city, country, postCode);
            user.AddAddress(address);

            await userRepository.SaveChangesAsync();
        }
    }
}
