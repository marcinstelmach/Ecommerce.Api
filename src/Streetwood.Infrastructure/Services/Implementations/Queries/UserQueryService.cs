using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Infrastructure.Dto.User;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class UserQueryService : IUserQueryService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserQueryService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IList<UserDto>> GetAsync()
        {
            var users = await userRepository.GetAsync();
            return mapper.Map<IList<UserDto>>(users);
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await userRepository.GetAndEnsureExist(id);
            return mapper.Map<UserDto>(user);
        }
    }
}
