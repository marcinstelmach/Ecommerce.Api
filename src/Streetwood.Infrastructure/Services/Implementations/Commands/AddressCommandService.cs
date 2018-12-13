using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class AddressCommandService : IAddressCommandService
    {
        private readonly IUserRepository userRepository;
        private readonly IAddressRepository addressRepository;

        public AddressCommandService(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            this.userRepository = userRepository;
            this.addressRepository = addressRepository;
        }

        public async Task AddAsync(string city, string street, string postCode, int phoneNumber, string country, Guid userId)
        {
            var user = await userRepository.GetAsync(userId);
            var address = new Address(street, city, country, postCode);

            await userRepository.SaveChangesAsync();
        }

        public async Task EraseDataAsync(IEnumerable<Address> addresses)
        {
            foreach (var address in addresses)
            {
                address.SetCity("erased");
                address.SetCountry("erased");
                address.SetStreet("erased");
                address.SetPostCode("erase");

                await addressRepository.UpdateAsync(address);
            }

            await addressRepository.SaveChangesAsync();
        }
    }
}
