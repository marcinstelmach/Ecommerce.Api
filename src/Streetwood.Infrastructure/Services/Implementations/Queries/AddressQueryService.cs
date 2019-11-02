using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class AddressQueryService : IAddressQueryService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public AddressQueryService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IList<AddressDto>> GetByUserAsync(Guid userId)
        {
            var user = await userRepository.GetAndEnsureExistAsync(userId);
            var orders = user.Orders.ToList();
            var addresses = user
                .Orders
                .Select(s => s.Address)
                .Distinct();

            return mapper.Map<IList<AddressDto>>(addresses);
        }

        public async Task<Address> GetAsync(NewAddressDto addressDto, Guid? id, Guid userId)
        {
            if (id != null)
            {
                var user = await userRepository.GetAndEnsureExistAsync(userId);
                return user.Orders
                    .Select(s => s.Address)
                    .Distinct()
                    .EnsureSingleExists(s => s.Id == id.Value);
            }

            return new Address(addressDto.Street, addressDto.City, addressDto.Country, addressDto.PostCode, addressDto.PhoneNumber);
        }
    }
}
