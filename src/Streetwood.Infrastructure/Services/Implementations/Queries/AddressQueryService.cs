using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
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
            var addresses = user.Addresses;

            return mapper.Map<IList<AddressDto>>(addresses);
        }
    }
}
