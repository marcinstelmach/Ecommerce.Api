using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Xunit;

namespace Streetwood.Infrastructure.Tests.CommandHandlers
{
    public class AddOrderCommandHandlerTests : AddOrderCommandHandlerFixture
    {
        [Fact]
        public async Task When_Adding_Order_Handler_Should_Get_Raw_User_By_Id()
        {
            // Arrange
            Fixture.Register<Guid>(() => Request.UserId);
            var user = Fixture.Create<User>();

            UserQueryServiceMock.Setup(s => s.GetRawByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(user);
            OrderCommandServiceMock
                .Setup(x => x.AddAsync(It.IsAny<User>(), It.IsAny<IList<ProductOrder>>(), It.IsAny<Shipment>(),
                    It.IsAny<OrderDiscount>(), It.IsAny<string>(), It.IsAny<Address>()))
                .ReturnsAsync(Order);

            // Act
            await Sut.Handle(Request, CancellationToken.None);

            // Assert
            UserQueryServiceMock.Verify(s => s.GetRawByIdAsync(Request.UserId), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Order_Handler_Should_Create_ProductOrders(IList<ProductWithCharmsOrderDto> productWithCharms, IList<ProductOrder> productsOrders)
        {
            // Arrange
            Fixture.Register<Guid>(() => Request.UserId);
            var user = Fixture.Create<User>();

            UserQueryServiceMock.Setup(s => s.GetRawByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(user);
            OrderCommandServiceMock
                .Setup(x => x.AddAsync(It.IsAny<User>(), It.IsAny<IList<ProductOrder>>(), It.IsAny<Shipment>(),
                    It.IsAny<OrderDiscount>(), It.IsAny<string>(), It.IsAny<Address>()))
                .ReturnsAsync(Order);
            ProductOrderQueryServiceMock.Setup(x => x.CreateAsync(It.IsAny<IList<ProductWithCharmsOrderDto>>()))
                .ReturnsAsync(productsOrders);

            // Act
            await Sut.Handle(Request, CancellationToken.None);

            // Assert
            ProductOrderQueryServiceMock.Verify(s => s.CreateAsync(productWithCharms), Times.Once);
        }
    }
}
