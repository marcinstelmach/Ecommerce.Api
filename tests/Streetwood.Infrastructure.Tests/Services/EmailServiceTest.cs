using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Implementations;
using Streetwood.Test.Helpers;
using Xunit;

namespace Streetwood.Infrastructure.Tests.Services
{
    public class EmailServiceTest
    {
        private readonly Mock<IEmailTemplatesManager> emailTemplateManagerMock;

        public EmailServiceTest()
        {
            emailTemplateManagerMock = new Mock<IEmailTemplatesManager>();
        }

        [Fact]
        public async Task PrepareNewOrderEmailAsync_Should_Return_Proper_Template()
        {
            // arrange
            var emailTemplate = await File.ReadAllTextAsync("./Resources/Emails/NewOrder.html");
            var expected = await File.ReadAllTextAsync("./Resources/Emails/NewOrderExpected.html");
            emailTemplateManagerMock.Setup(s => s.ReadTemplateAsync(It.IsAny<string>())).ReturnsAsync(emailTemplate);
            var order = new Order(UserFactory.CreateUser(), ProductsOrderFactory.GetProductsOrders(),
                DiscountFactory.GetOrderDiscount(), ShipmentFactory.GetShipment(), 30, 139, "Some comment", null);
//            var sut = new EmailService(emailTemplateManagerMock.Object);
//
//            //act
//            var result = await sut.PrepareNewOrderEmailAsync(order);
//
//            // assert
//            result.Should().BeEquivalentTo(expected);
        }
    }
}
