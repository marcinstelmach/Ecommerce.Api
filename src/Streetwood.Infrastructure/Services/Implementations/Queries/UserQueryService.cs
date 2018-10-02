using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Exceptions;
using Streetwood.Core.Managers;
using Streetwood.Infrastructure.Dto.User;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class UserQueryService : IUserQueryService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IEncrypter encrypter;
        private readonly ITokenManager tokenManager;

        public UserQueryService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter, ITokenManager tokenManager)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.encrypter = encrypter;
            this.tokenManager = tokenManager;
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

        public async Task<TokenModel> GetTokenAsync(string email, string password)
        {
            var user = await userRepository.GetByEmailAsync(email);
            var hash = encrypter.GetHash(password, user.Salt);
            if (hash != user.PasswordHash)
            {
                throw new StreetwoodException(ErrorCode.InvalidUserCredentials);
            }

            var token = tokenManager.GetToken(user.Id, user.Email);
            user.SetRefreshToken(token.RefreshToken);
            await userRepository.SaveChangesAsync();

            return token;
        }

        public async Task<TokenModel> RefreshToken(string jwtToken, string refreshToken)
        {
            var userId = tokenManager.GetUserIdFromExpiredToken(jwtToken);
            var user = await userRepository.GetAndEnsureExist(userId);
            if (refreshToken != user.RefreshToken)
            {
                throw new StreetwoodException(ErrorCode.InvalidRefreshToken);
            }

            var token = tokenManager.GetToken(userId, user.Email);
            user.SetRefreshToken(token.RefreshToken);
            await userRepository.SaveChangesAsync();

            return token;
        }
    }
}
