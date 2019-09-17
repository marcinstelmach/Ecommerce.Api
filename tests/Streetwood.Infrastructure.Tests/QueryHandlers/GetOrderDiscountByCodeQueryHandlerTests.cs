using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Queries.Handlers.OrderDiscount;
using Streetwood.Infrastructure.Queries.Models.OrderDiscount;
using Streetwood.Infrastructure.Services.Abstract.Queries;
using Xunit;

namespace Streetwood.Infrastructure.Tests.QueryHandlers
{
    public class GetOrderDiscountByCodeQueryHandlerTests
    {
        private readonly Mock<IOrderDiscountQueryService> orderDiscountQueryServiceMock;
        private readonly GetOrderDiscountByCodeQueryHandler sut;

        public GetOrderDiscountByCodeQueryHandlerTests()
        {
            orderDiscountQueryServiceMock = new Mock<IOrderDiscountQueryService>();
            sut = new GetOrderDiscountByCodeQueryHandler(orderDiscountQueryServiceMock.Object);
        }

        [Theory]
        [AutoData]
        public async Task When_Handling_Then_Gets_From_Query_Handler(GetOrderDiscountByCodeQueryModel model)
        {
            // Act
            await sut.Handle(model, default);

            // Assert
            orderDiscountQueryServiceMock.Verify(x => x.GetByCodeAsync(model.Code), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Handling_Then_Returns_Order_Discount_Dto(GetOrderDiscountByCodeQueryModel model, OrderDiscountDto dto)
        {
            // Arrange
            orderDiscountQueryServiceMock.Setup(x => x.GetByCodeAsync(It.IsAny<string>())).ReturnsAsync(dto);

            // Act
            var result = await sut.Handle(model, default);

            // Assert
            result.Should().Be(dto);
        }
    }
}