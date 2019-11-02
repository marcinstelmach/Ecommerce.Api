using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Models;
using Streetwood.Infrastructure.Services.Abstract.Helpers;
using Streetwood.Infrastructure.Services.Implementations.Helpers;
using Streetwood.Test.Helpers.Fixtures;
using Xunit;

namespace Streetwood.Infrastructure.Tests.Helpers
{
    public class ProductOrderHelperTests : EntitiesFixtures
    {
        private readonly Mock<IProductOrderCharmsHelper> productOrderCharmsHelperMock;
        private readonly ProductOrderHelper sut;

        public ProductOrderHelperTests()
        {
            productOrderCharmsHelperMock = new Mock<IProductOrderCharmsHelper>();
            sut = new ProductOrderHelper(productOrderCharmsHelperMock.Object);
        }

        [Theory]
        [AutoData]
        public void When_Applies_Charms_To_Product_Order_And_Product_Does_Not_Accepts_Charms_Then_Throws_Streetwood_Exception(
            ProductWithCharmsOrderDto productWithCharmsOrder, IList<Charm> charms, decimal finalPrice)
        {
            // Arrange
            var productOrder = ProductOrder;
            productOrder.Product.SetAcceptCharms(false);

            // Act
            Action action = () => sut.ApplyCharmsToProductOrder(productOrder, productWithCharmsOrder, charms, finalPrice);

            // Assert
            action.Should().Throw<StreetwoodException>();
        }

        [Theory]
        [AutoData]
        public void When_Applies_Charms_To_Product_Order_Then_Creates_Product_Order_Charms_With_Helper(
            ProductWithCharmsOrderDto productWithCharmsOrder, IList<Charm> charms, decimal finalPrice, IList<ProductOrderCharm> productOrderCharms)
        {
            // Arrange
            ProductOrder.Product.SetAcceptCharms(true);
            productOrderCharmsHelperMock
                .Setup(x =>x.CreateProductOrderCharms(It.IsAny<IEnumerable<CharmOrderDto>>(), It.IsAny<IList<Charm>>()))
                .Returns(productOrderCharms);

            // Act
            sut.ApplyCharmsToProductOrder(ProductOrder, productWithCharmsOrder, charms, finalPrice);

            // Assert
            productOrderCharmsHelperMock.Verify(x => x.CreateProductOrderCharms(productWithCharmsOrder.Charms, charms), Times.Once);
        }

        [Theory]
        [AutoData]
        public void When_Applies_Charms_To_Product_Order_Then_Adds_Product_Order_Charms_To_Product_Order(
            ProductWithCharmsOrderDto productWithCharmsOrder, IList<Charm> charms, decimal finalPrice,
            IList<ProductOrderCharm> productOrderCharms)
        {
            // Arrange
            ProductOrder.Product.SetAcceptCharms(true);
            productOrderCharmsHelperMock
                .Setup(x => x.CreateProductOrderCharms(It.IsAny<IEnumerable<CharmOrderDto>>(), It.IsAny<IList<Charm>>()))
                .Returns(productOrderCharms);

            // Act
            var result = sut.ApplyCharmsToProductOrder(ProductOrder, productWithCharmsOrder, charms, finalPrice);

            // Assert
            result.Should().NotBeNull();
            result.ProductOrder.ProductOrderCharms.Should().NotBeEmpty();
            result.ProductOrder.ProductOrderCharms.Should().BeEquivalentTo(productOrderCharms);
        }

        [Theory]
        [AutoData]
        public void When_Applies_Charms_To_Product_Order_Then_Returns_Correct_Final_Price(
            ProductWithCharmsOrderDto productWithCharmsOrder, IList<Charm> charms, decimal finalPrice, IList<ProductOrderCharm> productOrderCharms)
        {
            // Arrange
            ProductOrder.Product.SetAcceptCharms(true);
            ProductOrder.AddProductCategoryDiscount(null);
            productOrderCharmsHelperMock
                .Setup(x => x.CreateProductOrderCharms(It.IsAny<IEnumerable<CharmOrderDto>>(), It.IsAny<IList<Charm>>()))
                .Returns(productOrderCharms);
            var expected = finalPrice + productOrderCharms.Sum(x => x.CurrentPrice) - productOrderCharms.First().CurrentPrice;

            // Act
            var result = sut.ApplyCharmsToProductOrder(ProductOrder, productWithCharmsOrder, charms, finalPrice);

            // Assert
            result.Should().NotBeNull();
            result.FinalPrice.Should().Be(expected);
        }

        [Theory]
        [AutoData]
        public void When_Applies_Charms_To_Product_Then_Returns_Correct_Apply_Charms_To_Product_Order_Result(
            ProductWithCharmsOrderDto productWithCharmsOrder, IList<Charm> charms, decimal finalPrice, IList<ProductOrderCharm> productOrderCharms)
        {
            // Arrange
            ProductOrder.Product.SetAcceptCharms(true);
            ProductOrder.AddProductCategoryDiscount(null);
            productOrderCharmsHelperMock
                .Setup(x => x.CreateProductOrderCharms(It.IsAny<IEnumerable<CharmOrderDto>>(), It.IsAny<IList<Charm>>()))
                .Returns(productOrderCharms);
            var expected = finalPrice + productOrderCharms.Sum(x => x.CurrentPrice) - productOrderCharms.First().CurrentPrice;

            // Act
            var result = sut.ApplyCharmsToProductOrder(ProductOrder, productWithCharmsOrder, charms, finalPrice);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ApplyCharmsToProductOrderResult>();
        }
    }
}