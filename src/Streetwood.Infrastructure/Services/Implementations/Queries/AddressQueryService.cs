using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class AddressQueryService : IAddressQueryService
    {
        private readonly IUserRepository userRepository;
        private readonly IAddressRepository addressRepository;
        private readonly IMapper mapper;

        public AddressQueryService(IUserRepository userRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.addressRepository = addressRepository;
            this.mapper = mapper;
        }

        public async Task<IList<AddressDto>> GetByUserAsync(Guid userId)
        {
            var user = await userRepository.GetAndEnsureExistAsync(userId);
            var addresses = user.Orders.Select(s => s.Address);

            return mapper.Map<IList<AddressDto>>(addresses);
        }

        public async Task<Address> GetAsync(Guid id)
           => await addressRepository.GetAndEnsureExistAsync(id);

        public async Task<Address> GetAsync(NewAddressDto addressDto, Guid? id)
        {
            if (id != null)
            {
                return await addressRepository.GetAndEnsureExistAsync(id.Value);
            }

            return new Address(addressDto.Street, addressDto.City, addressDto.Country, addressDto.PostCode, addressDto.PhoneNumber);
        }
    }
}
