using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;
using Streetwood.Infrastructure.Services.Implementations.Commands;
using Xunit;

namespace Streetwood.Infrastructure.Tests.CommandServices
{
    public class OrderCommandServiceTests
    {
        private readonly Mock<IOrderRepository> orderRepositoryMock;
        private readonly Mock<IEmailService> emailServiceMock;
        private readonly OrderCommandService sut;

        public OrderCommandServiceTests()
        {
            var loggerMock = new Mock<ILogger<IOrderCommandService>>();
            orderRepositoryMock = new Mock<IOrderRepository>();
            emailServiceMock = new Mock<IEmailService>();
            sut = new OrderCommandService(loggerMock.Object, orderRepositoryMock.Object, emailServiceMock.Object);
        }

        [Theory]
        [AutoData]
        public async Task When_Updating_Then_Gets_Order_From_Repository(int id, bool payed, bool shipped, bool closed)
        {
            // Arrange
            var order = CreateOrder();
            orderRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<int>())).ReturnsAsync(order);

            // Act
            await sut.UpdateAsync(id, payed, shipped, closed);

            //  Assert
            orderRepositoryMock.Verify(x => x.GetAndEnsureExistAsync(id), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Updating_Then_Saves_With_Correct_Payed_Flag(int id, bool payed, bool shipped, bool closed)
        {
            // Arrange
            var order = CreateOrder();
            orderRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<int>())).ReturnsAsync(order);

            // Act
            await sut.UpdateAsync(id, payed, shipped, closed);

            // Assert
            order.IsPayed.Should().Be(payed);
        }

        [Theory]
        [AutoData]
        public async Task When_Updating_Then_Saves_With_Correct_Shipped_Flag(int id, bool payed, bool shipped, bool closed)
        {
            // Arrange
            var order = CreateOrder();
            orderRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<int>())).ReturnsAsync(order);

            // Act
            await sut.UpdateAsync(id, payed, shipped, closed);

            // Assert
            order.IsShipped.Should().Be(shipped);
        }

        [Theory]
        [AutoData]
        public async Task When_Updating_Then_Saves_With_Correct_Closed_Flag(int id, bool payed, bool shipped, bool closed)
        {
            // Arrange
            var order = CreateOrder();
            orderRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<int>())).ReturnsAsync(order);

            // Act
            await sut.UpdateAsync(id, payed, shipped, closed);

            // Assert
            order.IsClosed.Should().Be(closed);
        }

        [Theory]
        [AutoData]
        public async Task When_Updating_Then_Saves_Changes(int id, bool payed, bool shipped, bool closed)
        {
            // Arrange
            var order = CreateOrder();
            orderRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<int>())).ReturnsAsync(order);

            // Act
            await sut.UpdateAsync(id, payed, shipped, closed);

            // Assert
            orderRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Updating_And_Shipped_Flag_Was_Set_To_True_From_False_Then_Send_Email(int id, bool payed,
            bool closed)
        {
            // Arrange
            var order = CreateOrder();
            order.SetIsShipped(false);
            orderRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<int>())).ReturnsAsync(order);

            // Act
            await sut.UpdateAsync(id, payed, true, closed);

            // Assert
            emailServiceMock.Verify(x => x.SendOrderWasShippedEmailAsync(order), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Updating_And_Shipped_Flag_Was_Set_To_True_From_True_Then_Does_Not_Send_Email(int id, bool payed,
            bool closed)
        {
            // Arrange
            var order = CreateOrder();
            order.SetIsShipped(true);
            orderRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<int>())).ReturnsAsync(order);

            // Act
            await sut.UpdateAsync(id, payed, true, closed);

            // Assert
            emailServiceMock.Verify(x => x.SendOrderWasShippedEmailAsync(It.IsAny<Order>()), Times.Never);
        }

        [Theory]
        [AutoData]
        public async Task When_Updating_And_Shipped_Flag_Was_Set_To_False_From_True_Then_Does_Not_Send_Email(int id, bool payed,
            bool closed)
        {
            // Arrange
            var order = CreateOrder();
            order.SetIsShipped(true);
            orderRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<int>())).ReturnsAsync(order);

            // Act
            await sut.UpdateAsync(id, payed, false, closed);

            // Assert
            emailServiceMock.Verify(x => x.SendOrderWasShippedEmailAsync(It.IsAny<Order>()), Times.Never);
        }

        private static Order CreateOrder()
        {
            var fixture = new Fixture();
            var discountStart = fixture.Create<DateTime>();
            var orderDiscount = new OrderDiscount(
                fixture.Create<string>(), 
                fixture.Create<string>(), 
                fixture.Create<string>(), 
                fixture.Create<string>(),
                fixture.Create<int>(), 
                discountStart, 
                discountStart.AddDays(5), 
                fixture.Create<string>());

            return new Order(
                fixture.Create<User>(),
                fixture.Create<IEnumerable<ProductOrder>>(),
                orderDiscount, 
                fixture.Create<Shipment>(),
            fixture.Create<decimal>(), 
                fixture.Create<decimal>(), 
                fixture.Create<string>(), 
                fixture.Create<Address>());
        }
    }
}