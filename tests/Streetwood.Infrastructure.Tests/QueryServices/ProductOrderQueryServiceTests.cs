using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;
using Streetwood.Infrastructure.Services.Implementations.Queries;
using Xunit;

namespace Streetwood.Infrastructure.Tests.QueryServices
{
    public class ProductOrderQueryServiceTests
    {
        private readonly Mock<IProductQueryService> productQueryService;
        private readonly Mock<ICharmQueryService> charmQueryService;
        private readonly Mock<IProductCategoryDiscountQueryService> productCategoryDiscountQueryService;

        public ProductOrderQueryServiceTests()
        {
            productQueryService = new Mock<IProductQueryService>();
            charmQueryService = new Mock<ICharmQueryService>();
            productCategoryDiscountQueryService = new Mock<IProductCategoryDiscountQueryService>();
        }

        [Fact]
        public async Task CreateAsync_ForOrderWithoutDiscountShouldReturnProperProductsOrder()
        {
            // arrange
            var (productsWithCharmsOrderDto, products, charms, expected) = PrepareTestDataWithoutDiscount();
            productQueryService.Setup(s => s.GetRawByIdsAsync(It.IsAny<IEnumerable<int>>())).ReturnsAsync(products);
            charmQueryService.Setup(s => s.GetRawByIdsAsync(It.IsAny<List<Guid>>())).ReturnsAsync(charms);
            productCategoryDiscountQueryService.Setup(s => s.GetRawActiveAsync())
                .ReturnsAsync(new List<ProductCategoryDiscount>());
            productCategoryDiscountQueryService.Setup(s =>
                    s.ApplyDiscountsToProducts(It.IsAny<List<Product>>(), It.IsAny<List<ProductCategoryDiscount>>()))
                .Returns(new List<(int, ProductCategoryDiscount)>());

            var sut = new ProductOrderQueryService(productQueryService.Object, charmQueryService.Object,
                productCategoryDiscountQueryService.Object);

            // act
            var result = await sut.CreateAsync(productsWithCharmsOrderDto);

            // assert
            var orderedResult = result.OrderBy(s => s.Product.Id).ToList();
            orderedResult.Should().BeEquivalentTo(expected, s => s.Excluding(x => x.Id));
        }

        private (IList<ProductWithCharmsOrderDto>, IList<Product>, IList<Charm>, IList<ProductOrder>)
            PrepareTestDataWithoutDiscount()
        {
            var products = new List<Product>
            {
                new Product("Test", "Test", 50, "Test", "Test", true, "", "") {Id = 1},
                new Product("Test", "Test", 50, "Test", "Test", true, "", "") {Id = 2},
                new Product("Test", "Test", 50, "Test", "Test", true, "", "") {Id = 3},
                new Product("Test", "Test", 100, "Test", "Test", false, "", "") {Id = 4},
            };

            var charms = new List<Charm>
            {
                new Charm("Charm1", "", "", 5),
                new Charm("Charm2", "", "", 5),
                new Charm("Charm3", "", "", 5),
                new Charm("Charm4", "", "", 5),
                new Charm("Charm5", "", "", 5),
                new Charm("Charm6", "", "", 5),
            };
            var productsWithCharmsOrderDto = new List<ProductWithCharmsOrderDto>
            {
                new ProductWithCharmsOrderDto
                {
                    ProductId = 1,
                    Amount = 2,
                    Comment = "With 3 charms",
                    Charms = new List<CharmOrderDto>
                    {
                        new CharmOrderDto {CharmId = charms[0].Id, Sequence = 1},
                        new CharmOrderDto {CharmId = charms[1].Id, Sequence = 2},
                        new CharmOrderDto {CharmId = charms[2].Id, Sequence = 3}
                    }
                },
                new ProductWithCharmsOrderDto
                {
                    ProductId = 2,
                    Amount = 1,
                    Comment = "With 2 charms",
                    Charms = new List<CharmOrderDto>
                    {
                        new CharmOrderDto {CharmId = charms[3].Id, Sequence = 1},
                        new CharmOrderDto {CharmId = charms[4].Id, Sequence = 2}
                    }
                },
                new ProductWithCharmsOrderDto
                {
                    ProductId = 3,
                    Amount = 2,
                    Comment = "With 1 charm",
                    Charms = new List<CharmOrderDto>
                    {
                        new CharmOrderDto {CharmId = charms[5].Id, Sequence = 1}
                    }
                },
                new ProductWithCharmsOrderDto
                {
                    ProductId = 4,
                    Amount = 4,
                    Comment = "Normal product without charm",
                    Charms = new List<CharmOrderDto>()
                }
            };

            var productOrder1 =
                new ProductOrder(productsWithCharmsOrderDto[0].Amount, productsWithCharmsOrderDto[0].Comment);
            productOrder1.SetCurrentProductPrice(50);
            productOrder1.SetFinalPrice(60);
            productOrder1.SetCharmsPrice(10);
            productOrder1.AddProduct(products[0]);

            var productOrder2 =
                new ProductOrder(productsWithCharmsOrderDto[1].Amount, productsWithCharmsOrderDto[1].Comment);
            productOrder2.SetCurrentProductPrice(50);
            productOrder2.SetFinalPrice(55);
            productOrder2.SetCharmsPrice(5);
            productOrder2.AddProduct(products[1]);

            var productOrder3 =
                new ProductOrder(productsWithCharmsOrderDto[2].Amount, productsWithCharmsOrderDto[2].Comment);
            productOrder3.SetCurrentProductPrice(50);
            productOrder3.SetFinalPrice(50);
            productOrder3.SetCharmsPrice(0);
            productOrder3.AddProduct(products[2]);

            var productOrder4 =
                new ProductOrder(productsWithCharmsOrderDto[3].Amount, productsWithCharmsOrderDto[3].Comment);
            productOrder4.SetCurrentProductPrice(100);
            productOrder4.SetFinalPrice(100);
            productOrder4.SetCharmsPrice(0);
            productOrder4.AddProduct(products[3]);

            var expected = new List<ProductOrder>
            {
                productOrder1, productOrder2, productOrder3, productOrder4
            };

            return (productsWithCharmsOrderDto, products, charms, expected.OrderBy(s => s.Product.Id).ToList());
        }
    }
}