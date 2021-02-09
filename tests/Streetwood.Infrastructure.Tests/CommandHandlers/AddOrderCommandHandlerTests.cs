using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Xunit;

namespace Streetwood.Infrastructure.Tests.CommandHandlers
{
    public class AddOrderCommandHandlerTests : AddOrderCommandHandlerFixture
    {
        public AddOrderCommandHandlerTests()
        {
            OrderCommandServiceMock
                .Setup(x => x.CreateOrderAsync(It.IsAny<User>(), It.IsAny<IList<ProductOrder>>(), It.IsAny<Shipment>(), It.IsAny<Payment>(),
                    It.IsAny<OrderDiscount>(), It.IsAny<string>(), It.IsAny<Address>()))
                .ReturnsAsync(Order);
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Order_Gets_Raw_User_From_Service_By_Id(User user)
        {
            // Arrange
            UserQueryServiceMock.Setup(s => s.GetRawByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(user);

            // Act
            await Sut.Handle(Request, CancellationToken.None);

            // Assert
            UserQueryServiceMock.Verify(s => s.GetRawByIdAsync(Request.UserId), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Order_Then_Creates_ProductOrders_In_Service(IList<ProductOrder> productsOrders)
        {
            // Arrange
            ProductOrderQueryServiceMock.Setup(x => x.CreateAsync(It.IsAny<IList<ProductWithCharmsOrderDto>>()))
                .ReturnsAsync(productsOrders);

            // Act
            await Sut.Handle(Request, default);

            // Assert
            ProductOrderQueryServiceMock.Verify(s => s.CreateAsync(Request.Products), Times.Once);
        }

        [Fact]
        public async Task When_Adding_Order_Then_Gets_Shipment_From_Service_By_Id()
        {
            // Act
            await Sut.Handle(Request, default);

            // Assert
            ShipmentQueryServiceMock.Verify(x => x.GetRawAsync(Request.ShipmentId), Times.Once);
        }

        [Fact]
        public async Task When_Adding_Order_Then_Gets_Order_Discount_From_Service()
        {
            // Act
            await Sut.Handle(Request, default);

            // Assert
            OrderDiscountQueryServiceMock.Verify(x => x.GetRawByCodeAsync(Request.PromoCode));
        }

        [Fact]
        public async Task When_Adding_Order_Then_Gets_Address_From_Service()
        {
            // Act
            await Sut.Handle(Request, default);

            // Assert
            AddressQueryServiceMock.Verify(x => x.GetAsync(Request.Address, Request.AddressId, Request.UserId));
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Order_Then_Adds_With_Service(User user, IList<ProductOrder> productOrders, Shipment shipment, Payment payment, Address address)
        {
            // Arrange
            UserQueryServiceMock.Setup(x => x.GetRawByIdAsync(It.IsAny<Guid>())).ReturnsAsync(user);
            ProductOrderQueryServiceMock.Setup(x => x.CreateAsync(It.IsAny<IList<ProductWithCharmsOrderDto>>())).ReturnsAsync(productOrders);
            ShipmentQueryServiceMock.Setup(x => x.GetRawAsync(It.IsAny<Guid>())).ReturnsAsync(shipment);
            OrderDiscountQueryServiceMock.Setup(x => x.GetRawByCodeAsync(It.IsAny<string>())).ReturnsAsync(OrderDiscount);
            AddressQueryServiceMock.Setup(x => x.GetAsync(It.IsAny<NewAddressDto>(), It.IsAny<Guid?>(), It.IsAny<Guid>())).ReturnsAsync(address);

            // Act
            await Sut.Handle(Request, default);

            // Assert
            OrderCommandServiceMock.Verify(x => x.CreateOrderAsync(user, productOrders, shipment, payment, OrderDiscount, Request.Comment, address));
        }

        [Fact]
        public async Task When_Adding_Order_Then_Returns_Order_Id()
        {
            // Act
            var result = await Sut.Handle(Request, default);

            // Assert
            result.Should().Be(Order.Id);
        }
    }
}
