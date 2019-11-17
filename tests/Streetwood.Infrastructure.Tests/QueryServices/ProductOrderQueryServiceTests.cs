using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Models;
using Streetwood.Infrastructure.Services.Abstract.Helpers;
using Streetwood.Infrastructure.Services.Abstract.Queries;
using Streetwood.Infrastructure.Services.Implementations.Queries;
using Streetwood.Test.Helpers.Fixtures;
using Xunit;

namespace Streetwood.Infrastructure.Tests.QueryServices
{
    public class ProductOrderQueryServiceTests : EntitiesFixtures
    {
        private readonly Mock<IProductQueryService> productQueryServiceMock;
        private readonly Mock<ICharmQueryService> charmQueryServiceMock;
        private readonly Mock<IProductCategoryDiscountQueryService> productCategoryDiscountQueryServiceMock;
        private readonly Mock<IProductOrderHelper> productOrderHelperMock;
        private readonly ProductOrderQueryService sut;

        public ProductOrderQueryServiceTests()
        {
            productQueryServiceMock = new Mock<IProductQueryService>();
            charmQueryServiceMock = new Mock<ICharmQueryService>();
            productCategoryDiscountQueryServiceMock = new Mock<IProductCategoryDiscountQueryService>();
            productOrderHelperMock = new Mock<IProductOrderHelper>();
            productOrderHelperMock
                .Setup(x => x.ApplyCharmsToProductOrder(It.IsAny<ProductOrder>(), It.IsAny<ProductWithCharmsOrderDto>(),
                    It.IsAny<IList<Charm>>(), It.IsAny<decimal>()))
                .Returns(Fixture.Create<ApplyCharmsToProductOrderResult>());
            sut = new ProductOrderQueryService(productQueryServiceMock.Object,
                charmQueryServiceMock.Object,
                productCategoryDiscountQueryServiceMock.Object,
                productOrderHelperMock.Object);
        }

        [Fact]
        public async Task When_Creates_Product_Order_Then_Gets_Products_By_Id_From_Product_Service()
        {
            // Arrange
            var productsWithDiscounts = CreateProductsWithDiscounts();
            var productWithCharmOrders = CreateProductsWithCharmsOrderDtos(productsWithDiscounts);

            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(new List<ProductWithDiscount>());
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(productsWithDiscounts);
            var productIds = productWithCharmOrders.Select(y => y.ProductId).ToList();

            // Act
            await sut.CreateAsync(productWithCharmOrders);

            // Assert
            productQueryServiceMock.Verify(x => x.GetRawByIdsAsync(productIds), Times.Once);
        }

        [Fact]
        public async Task When_Creates_Product_Order_Then_Gets_Charms_By_Id_From_Charms_Service()
        {
            // Arrange
            var productsWithDiscounts = CreateProductsWithDiscounts();
            var productWithCharmOrders = CreateProductsWithCharmsOrderDtos(productsWithDiscounts);

            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(productsWithDiscounts);
            var productIds = productWithCharmOrders.SelectMany(x => x.Charms).Select(x => x.CharmId).ToList();

            // Act
            await sut.CreateAsync(productWithCharmOrders);

            // Assert
            charmQueryServiceMock.Verify(x => x.GetRawByIdsAsync(productIds), Times.Once);
        }

        [Fact]
        public async Task When_Creates_Product_Order_Then_Gets_Active_Product_Category_Discounts_From_Service()
        {
            // Arrange
            var productsWithDiscounts = CreateProductsWithDiscounts();
            var productWithCharmOrders = CreateProductsWithCharmsOrderDtos(productsWithDiscounts);

            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(productsWithDiscounts);

            // Act
            await sut.CreateAsync(productWithCharmOrders);

            // Assert
            productCategoryDiscountQueryServiceMock.Verify(x => x.GetRawActiveAsync(), Times.Once);
        }

        [Fact]
        public async Task When_Creates_Product_Order_Then_Applies_Discounts_To_Products()
        {
            // Arrange
            var productsWithDiscounts = CreateProductsWithDiscounts();
            var productWithCharmOrders = CreateProductsWithCharmsOrderDtos(productsWithDiscounts);
            var products = Products;
            var discounts = new List<ProductCategoryDiscount> {ProductCategoryDiscount};
            productQueryServiceMock.Setup(x => x.GetRawByIdsAsync(It.IsAny<IList<int>>())).ReturnsAsync(products);
            productCategoryDiscountQueryServiceMock.Setup(x => x.GetRawActiveAsync()).ReturnsAsync(discounts);
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(productsWithDiscounts);

            // Act
            await sut.CreateAsync(productWithCharmOrders);

            // Assert
            productCategoryDiscountQueryServiceMock.Verify(x => x.ApplyDiscountsToProducts(products, discounts),
                Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Creates_Product_Order_Then_For_Products_With_Charms_Applies_Charms(ApplyCharmsToProductOrderResult applyCharmsToProductOrderResult)
        {
            // Arrange
            var productsWithDiscounts = CreateProductsWithDiscounts();
            var productWithCharmsOrder = CreateProductsWithCharmsOrderDtos(productsWithDiscounts);
            var products = Products;
            var discounts = new List<ProductCategoryDiscount> {ProductCategoryDiscount};
            productQueryServiceMock.Setup(x => x.GetRawByIdsAsync(It.IsAny<IList<int>>())).ReturnsAsync(products);
            productCategoryDiscountQueryServiceMock.Setup(x => x.GetRawActiveAsync()).ReturnsAsync(discounts);
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(productsWithDiscounts);
            productOrderHelperMock.Setup(x => x.ApplyCharmsToProductOrder(It.IsAny<ProductOrder>(),
                It.IsAny<ProductWithCharmsOrderDto>(),
                It.IsAny<IList<Charm>>(),
                It.IsAny<decimal>())).Returns(applyCharmsToProductOrderResult);

            // Act
            await sut.CreateAsync(productWithCharmsOrder);

            // Assert
            productOrderHelperMock.Verify(
                x => x.ApplyCharmsToProductOrder(
                    It.IsAny<ProductOrder>(),
                    It.IsAny<ProductWithCharmsOrderDto>(),
                    It.IsAny<IList<Charm>>(),
                    It.IsAny<decimal>()),
                Times.Exactly(productWithCharmsOrder.Select(x => x.Charms).Count()));
        }

        [Theory]
        [AutoData]
        public async Task When_Creates_Product_Order_Then_For_Products_With_Discounts_Applies_Discount(ApplyCharmsToProductOrderResult applyCharmsToProductOrderResult)
        {
            // Arrange
            var productsWithDiscounts = CreateProductsWithDiscounts();
            var productWithCharmsOrder = CreateProductsWithCharmsOrderDtos(productsWithDiscounts);
            var products = Products;
            var discounts = new List<ProductCategoryDiscount> { ProductCategoryDiscount };
            productQueryServiceMock.Setup(x => x.GetRawByIdsAsync(It.IsAny<IList<int>>())).ReturnsAsync(products);
            productCategoryDiscountQueryServiceMock.Setup(x => x.GetRawActiveAsync()).ReturnsAsync(discounts);
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(productsWithDiscounts);
            productOrderHelperMock.Setup(x => x.ApplyCharmsToProductOrder(It.IsAny<ProductOrder>(),
                It.IsAny<ProductWithCharmsOrderDto>(),
                It.IsAny<IList<Charm>>(),
                It.IsAny<decimal>())).Returns(applyCharmsToProductOrderResult);

            // Act
            var result = await sut.CreateAsync(productWithCharmsOrder);

            // Assert
            result.Select(x => x.ProductCategoryDiscount).Should().HaveSameCount(productsWithDiscounts.Select(x => x.ProductCategoryDiscount));
        }

        [Fact]
        public async Task When_Creates_Products_Without_Discount_And_Without_Charms_Then_Returns_Correct_Products_Order()
        {
            // Arrange
            var productWithDiscount = new ProductWithDiscount(Product, null);
            var productsWithCharmOrder = CreateProductWithCharmsOrderDto(productWithDiscount.Product.Id);
            productsWithCharmOrder.Charms = new List<CharmOrderDto>();
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(new List<ProductWithDiscount> { productWithDiscount });

            // Act
            var result = await sut.CreateAsync(new List<ProductWithCharmsOrderDto> { productsWithCharmOrder });

            // Assert
            result.Should().NotBeNull();

        }

        private IList<ProductWithDiscount> CreateProductsWithDiscounts()
        {
            return new List<ProductWithDiscount>
            {
                new ProductWithDiscount(Products[0], ProductCategoryDiscount),
                new ProductWithDiscount(Products[1], null)
            };
        }

        private IList<ProductWithCharmsOrderDto> CreateProductsWithCharmsOrderDtos(IList<ProductWithDiscount> productsWithDiscounts)
        {
            var results = Fixture.CreateMany<ProductWithCharmsOrderDto>(productsWithDiscounts.Count).ToList();
            for (var i = 0; i < productsWithDiscounts.Count; i++)
            {
                results[i].ProductId = productsWithDiscounts[i].Product.Id;
            }

            return results;
        }

        private ProductWithCharmsOrderDto CreateProductWithCharmsOrderDto(int productId)
        {
            return Fixture.Build<ProductWithCharmsOrderDto>()
                .With(x => x.ProductId, productId)
                .Create();
        }
    }
}