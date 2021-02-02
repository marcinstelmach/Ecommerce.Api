namespace Streetwood.Infrastructure.Tests.QueryServices.UserQueryService
{
    public class GetTokenTests : UserQueryServiceFixture
    {
        private readonly Infrastructure.Services.Implementations.Queries.UserQueryService sut;

        public GetTokenTests()
        {
            sut = new Infrastructure.Services.Implementations.Queries.UserQueryService(
                UserRepositoryMock.Object,
                MapperMock.Object,
                EncrypterManagerMock.Object,
                TokenManagerMock.Object,
                StringGeneratorMock.Object);
        }
    }
}