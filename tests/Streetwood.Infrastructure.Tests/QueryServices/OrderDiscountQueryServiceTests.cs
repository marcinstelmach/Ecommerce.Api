using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Implementations.Queries;
using Xunit;

namespace Streetwood.Infrastructure.Tests.QueryServices
{
    public class OrderDiscountQueryServiceTests
    {
        private readonly Mock<IOrderDiscountRepository> orderDiscountRepositoryMock;
        private readonly Mock<IMapper> mapperMock;
        private readonly OrderDiscountQueryService sut;

        public OrderDiscountQueryServiceTests()
        {
            orderDiscountRepositoryMock = new Mock<IOrderDiscountRepository>();
            mapperMock = new Mock<IMapper>();
            sut = new OrderDiscountQueryService(orderDiscountRepositoryMock.Object, mapperMock.Object);
        }

        [Theory]
        [AutoData]
        public async Task When_Getting_Discount_By_Code_Then_Gets_Discount_From_Repository(string code, OrderDiscountDto dto)
        {
            // Arrange
            orderDiscountRepositoryMock.Setup(x => x.GetByCodeAsync(It.IsAny<string>())).ReturnsAsync(CreateOrderDiscount);
            mapperMock.Setup(x => x.Map<OrderDiscountDto>(It.IsAny<OrderDiscount>())).Returns(dto);

            // Act
            await sut.GetByCodeAsync(code);

            // Assert
            orderDiscountRepositoryMock.Verify(x => x.GetByCodeAsync(code), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Getting_Discount_By_Code_And_Discount_Does_Not_Exists_Then_Throws_Streetwood_Exception_With_Proper_Error_Code(string code)
        {
            // Arrange
            orderDiscountRepositoryMock.Setup(x => x.GetByCodeAsync(It.IsAny<string>())).ReturnsAsync((OrderDiscount)null);

            // Act
            Func<Task> func = () => sut.GetByCodeAsync(code);

            // Assert
            var exception = await func.Should().ThrowAsync<StreetwoodException>();
            exception.Which.ErrorCode.Should().BeEquivalentTo(ErrorCode.OrderDiscountNotFound);
        }

        [Theory]
        [AutoData]
        public async Task When_Getting_Discount_By_Code_Then_Maps_It_To_Order_Discount_Dto(string code, OrderDiscountDto dto)
        {
            // Arrange
            var orderDiscount = CreateOrderDiscount();
            orderDiscountRepositoryMock.Setup(x => x.GetByCodeAsync(It.IsAny<string>())).ReturnsAsync(orderDiscount);
            mapperMock.Setup(x => x.Map<OrderDiscountDto>(It.IsAny<OrderDiscount>())).Returns(dto);

            // Act
            await sut.GetByCodeAsync(code);

            // Assert
            mapperMock.Verify(x => x.Map<OrderDiscountDto>(orderDiscount), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Getting_Discount_By_Code_Then_Returns_Discount_Dto(string code, OrderDiscountDto dto)
        {
            // Arrange
            var orderDiscount = CreateOrderDiscount();
            orderDiscountRepositoryMock.Setup(x => x.GetByCodeAsync(It.IsAny<string>())).ReturnsAsync(orderDiscount);
            mapperMock.Setup(x => x.Map<OrderDiscountDto>(It.IsAny<OrderDiscount>())).Returns(dto);

            // Act
            var result = await sut.GetByCodeAsync(code);

            // Assert
            result.Should().BeEquivalentTo(dto);
        }

        private static OrderDiscount CreateOrderDiscount()
        {
            var fixture = new Fixture();
            return new OrderDiscount(
                fixture.Create<string>(),
                fixture.Create<string>(),
                fixture.Create<string>(),
                fixture.Create<string>(),
                fixture.Create<int>(),
                DateTime.Now,
                DateTime.Now.AddDays(5),
                fixture.Create<string>()
                );
        }
    }
}