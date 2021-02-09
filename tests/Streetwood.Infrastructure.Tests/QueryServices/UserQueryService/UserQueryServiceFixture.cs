using AutoMapper;
using Moq;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Managers;
using Streetwood.Infrastructure.Managers.Abstract;

namespace Streetwood.Infrastructure.Tests.QueryServices.UserQueryService
{
    public class UserQueryServiceFixture
    {
        public Mock<IUserRepository> UserRepositoryMock { get; }

        public Mock<IMapper> MapperMock { get; }

        public Mock<IEncrypter> EncrypterManagerMock { get; }

        public Mock<ITokenManager> TokenManagerMock { get; }

        public Mock<IStringGenerator> StringGeneratorMock { get; }

        public UserQueryServiceFixture()
        {
            UserRepositoryMock = new Mock<IUserRepository>();
            MapperMock = new Mock<IMapper>();
            EncrypterManagerMock = new Mock<IEncrypter>();
            TokenManagerMock = new Mock<ITokenManager>();
            StringGeneratorMock = new Mock<IStringGenerator>();
        }
    }
}