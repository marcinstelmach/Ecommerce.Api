using System.Threading.Tasks;
using Moq;
using Streetwood.Infrastructure.Managers.Abstract;
using Xunit;

namespace Streetwood.Infrastructure.Tests.Services
{
    public class EmailServiceTest
    {
        private readonly IMock<IPathManager> pathManager;

        public EmailServiceTest()
        {
            pathManager = new Mock<IPathManager>();
        }

        [Fact]
        public async Task PrepareNewOrderEmailAsync_Should_Return_Proper_Template()
        {
//            // arrange
//            pathManager.Setup(s => s.GetEmailTemplatePath(It.IsAny<string>()))
//                .Returns("./Resources/Emails/NewOrder.html");
//
//            var order = new Order(UserHelper.CreateUser(), ProductsOrderHelper.GetProductsOrders(),
//                DiscountHelper.GetOrderDiscount(), ShipmentHelper.GetShipment(), 30, 35,
//                "", null);
//            var sut = new EmailService();
//
//            //act
//            var result = await sut.PrepareNewOrderEmailAsync(order);
//
//            //
//            result.Should().NotBeEmpty();
        }
    }
}
