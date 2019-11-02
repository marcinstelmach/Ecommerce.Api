using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using Castle.DynamicProxy;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Mappers;
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
        private readonly IMapper mapperMock;
        private readonly ProductOrderQueryService sut;

        public ProductOrderQueryServiceTests()
        {
            productQueryServiceMock = new Mock<IProductQueryService>();
            charmQueryServiceMock = new Mock<ICharmQueryService>();
            productCategoryDiscountQueryServiceMock = new Mock<IProductCategoryDiscountQueryService>();
            productOrderHelperMock = new Mock<IProductOrderHelper>();
            mapperMock = AutoMapperConfig.Initialize();
            sut = new ProductOrderQueryService(productQueryServiceMock.Object,
                charmQueryServiceMock.Object,
                productCategoryDiscountQueryServiceMock.Object,
                productOrderHelperMock.Object);
        }

        [Theory]
        [AutoData]
        public async Task When_Creates_Product_Order_Then_Gets_Products_By_Id_From_Product_Service(
            IList<ProductWithCharmsOrderDto> productWithCharmsOrder)
        {
            // Arrange
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(new List<ApplyDiscountsToProductsResult>());
            var productIds = productWithCharmsOrder.Select(y => y.ProductId).ToList();

            // Act
            await sut.CreateAsync(productWithCharmsOrder);

            // Assert
            productQueryServiceMock.Verify(x => x.GetRawByIdsAsync(productIds), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Creates_Product_Order_Then_Gets_Charms_By_Id_From_Charms_Service(
            IList<ProductWithCharmsOrderDto> productWithCharmsOrder)
        {
            // Arrange
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(new List<ApplyDiscountsToProductsResult>());
            var productIds = productWithCharmsOrder.SelectMany(x => x.Charms).Select(x => x.CharmId).ToList();

            // Act
            await sut.CreateAsync(productWithCharmsOrder);

            // Assert
            charmQueryServiceMock.Verify(x => x.GetRawByIdsAsync(productIds), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Creates_Product_Order_Then_Gets_Active_Product_Category_Discounts_From_Service(
            IList<ProductWithCharmsOrderDto> productWithCharmsOrder)
        {
            // Arrange
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(new List<ApplyDiscountsToProductsResult>());

            // Act
            await sut.CreateAsync(productWithCharmsOrder);

            // Assert
            productCategoryDiscountQueryServiceMock.Verify(x => x.GetRawActiveAsync(), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Creates_Product_Order_Then_Applies_Discounts_To_Products(
            IList<ProductWithCharmsOrderDto> productWithCharmsOrder)
        {
            // Arrange
            var products = Products;
            var discounts = new List<ProductCategoryDiscount> {ProductCategoryDiscount};
            productQueryServiceMock.Setup(x => x.GetRawByIdsAsync(It.IsAny<IList<int>>())).ReturnsAsync(products);
            productCategoryDiscountQueryServiceMock.Setup(x => x.GetRawActiveAsync()).ReturnsAsync(discounts);
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(new List<ApplyDiscountsToProductsResult>());

            // Act
            await sut.CreateAsync(productWithCharmsOrder);

            // Assert
            productCategoryDiscountQueryServiceMock.Verify(x => x.ApplyDiscountsToProducts(products, discounts),
                Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Creates_Product_Order_Then_For_Products_With_Charms_Applies_Charms(ApplyCharmsToProductOrderResult applyCharmsToProductOrderResult)
        {
            // Arrange
            var productsWithDiscounts = GetProductsWithDiscounts();
            var productWithCharmsOrder = GetProductsWithCharmsOrderDtos(productsWithDiscounts);
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
            var productsWithDiscounts = GetProductsWithDiscounts();
            var productWithCharmsOrder = GetProductsWithCharmsOrderDtos(productsWithDiscounts);
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
            var productWithDiscount = new ApplyDiscountsToProductsResult(Product, null);
            var productsWithCharmOrder = GetProductWithCharmsOrderDto(productWithDiscount.Product.Id);
            productsWithCharmOrder.Charms = new List<CharmOrderDto>();
            productCategoryDiscountQueryServiceMock.Setup(x =>
                    x.ApplyDiscountsToProducts(It.IsAny<IList<Product>>(), It.IsAny<IList<ProductCategoryDiscount>>()))
                .Returns(new List<ApplyDiscountsToProductsResult> { productWithDiscount });

            // Act
            var result = await sut.CreateAsync(new List<ProductWithCharmsOrderDto> { productsWithCharmOrder });

            // Assert
            result.Should().NotBeNull();

        }

        private IList<ApplyDiscountsToProductsResult> GetProductsWithDiscounts()
        {
            return new List<ApplyDiscountsToProductsResult>
            {
                new ApplyDiscountsToProductsResult(Products[0], ProductCategoryDiscount),
                new ApplyDiscountsToProductsResult(Products[1], null)
            };
        }

        private IList<ProductWithCharmsOrderDto> GetProductsWithCharmsOrderDtos(IList<ApplyDiscountsToProductsResult> productsWithDiscounts)
        {
            var results = Fixture.CreateMany<ProductWithCharmsOrderDto>(productsWithDiscounts.Count).ToList();
            for (var i = 0; i < productsWithDiscounts.Count; i++)
            {
                results[i].ProductId = productsWithDiscounts[i].Product.Id;
            }

            if (results.Any())
            {
                results[0].Charms = new List<CharmOrderDto>();
            }

            return results;
        }

        private ProductWithCharmsOrderDto GetProductWithCharmsOrderDto(int productId)
        {
            return Fixture.Build<ProductWithCharmsOrderDto>()
                .With(x => x.ProductId, productId)
                .Create();
        }
    }
}