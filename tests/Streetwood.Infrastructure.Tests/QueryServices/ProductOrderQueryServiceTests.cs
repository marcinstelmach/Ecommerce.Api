using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Mappers;
using Streetwood.Infrastructure.Services.Abstract.Queries;
using Streetwood.Infrastructure.Services.Implementations.Queries;
using Xunit;

namespace Streetwood.Infrastructure.Tests.QueryServices
{
    public class ProductOrderQueryServiceTests
    {
        private readonly Mock<IProductQueryService> productQueryServiceMock;
        private readonly Mock<ICharmQueryService> charmQueryServiceMock;
        private readonly Mock<IProductCategoryDiscountQueryService> productCategoryDiscountQueryServiceMock;
        private readonly IMapper mapperMock;
        private readonly ProductOrderQueryService sut;

        public ProductOrderQueryServiceTests()
        {
            productQueryServiceMock = new Mock<IProductQueryService>();
            charmQueryServiceMock = new Mock<ICharmQueryService>();
            productCategoryDiscountQueryServiceMock = new Mock<IProductCategoryDiscountQueryService>();
            mapperMock = AutoMapperConfig.Initialize();
            sut = new ProductOrderQueryService(productQueryServiceMock.Object, charmQueryServiceMock.Object, productCategoryDiscountQueryServiceMock.Object);
        }

        [Fact]
        public async Task CreateAsync_ForOrderWithoutDiscountShouldReturnProperProductsOrder()
        {
            // arrange
            var (productsWithCharmsOrderDto, products, charms, expected) = PrepareTestDataWithoutDiscount();
            productQueryServiceMock.Setup(s => s.GetRawByIdsAsync(It.IsAny<IList<int>>())).ReturnsAsync(products);
            charmQueryServiceMock.Setup(s => s.GetRawByIdsAsync(It.IsAny<List<Guid>>())).ReturnsAsync(charms);
            productCategoryDiscountQueryServiceMock.Setup(s => s.GetRawActiveAsync())
                .ReturnsAsync(new List<ProductCategoryDiscount>());
            productCategoryDiscountQueryServiceMock.Setup(s =>
                    s.ApplyDiscountsToProducts(It.IsAny<List<Product>>(), It.IsAny<List<ProductCategoryDiscount>>()))
                .Returns(new List<(int, ProductCategoryDiscount)>());

            // act
            var result = await sut.CreateAsync(productsWithCharmsOrderDto);

            // assert
            var orderedResult = result.OrderBy(s => s.Product.Id).ToList();
            orderedResult.Should()
                .BeEquivalentTo(expected, s => s.Excluding(x => x.Id)
                .Excluding(x => x.RuntimeType == typeof(Guid)));
        }

        private (IList<ProductWithCharmsOrderDto>, IList<Product>, IList<Charm>, IList<ProductOrder>) PrepareTestDataWithoutDiscount()
        {
            var products = new List<Product>
            {
                new Product("Test", "Test", 50, "Test", "Test", true, 5, "", "") {Id = 1},
                new Product("Test", "Test", 50, "Test", "Test", true,5,  "", "") {Id = 2},
                new Product("Test", "Test", 50, "Test", "Test", true, 5, "", "") {Id = 3},
                new Product("Test", "Test", 100, "Test", "Test", false, 0,"", "") {Id = 4},
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

            var productOrderCharms1 = new List<ProductOrderCharm>
            {
                new ProductOrderCharm(charms[0], 1),
                new ProductOrderCharm(charms[1], 2),
                new ProductOrderCharm(charms[2], 3)
            };

            var productOrderCharms2 = new List<ProductOrderCharm>
            {
                new ProductOrderCharm(charms[3], 1),
                new ProductOrderCharm(charms[4], 2)
            };

            var productOrderCharms3 = new List<ProductOrderCharm>
            {
                new ProductOrderCharm(charms[5], 1)
            };

            var productOrderCharms4 = new List<ProductOrderCharm>();

            var productsWithCharmsOrderDto = new List<ProductWithCharmsOrderDto>
            {
                new ProductWithCharmsOrderDto
                {
                    ProductId = 1,
                    Amount = 2,
                    Comment = "With 3 charms",
                    Charms = mapperMock.Map<List<CharmOrderDto>>(productOrderCharms1)
                },
                new ProductWithCharmsOrderDto
                {
                    ProductId = 2,
                    Amount = 1,
                    Comment = "With 2 charms",
                    Charms = mapperMock.Map<List<CharmOrderDto>>(productOrderCharms2)
                },
                new ProductWithCharmsOrderDto
                {
                    ProductId = 3,
                    Amount = 2,
                    Comment = "With 1 charm",
                    Charms = mapperMock.Map<List<CharmOrderDto>>(productOrderCharms3)
                },
                new ProductWithCharmsOrderDto
                {
                    ProductId = 4,
                    Amount = 4,
                    Comment = "Normal product without charm",
                    Charms = mapperMock.Map<List<CharmOrderDto>>(productOrderCharms4)
                }
            };

            var productOrder1 =
                new ProductOrder(productsWithCharmsOrderDto[0].Amount, productsWithCharmsOrderDto[0].Comment);
            productOrder1.SetCurrentProductPrice(50);
            productOrder1.SetFinalPrice(60);
            productOrder1.SetCharmsPrice(10);
            productOrder1.AddProduct(products[0]);
            productOrder1.AddProductOrderCharms(productOrderCharms1);

            var productOrder2 =
                new ProductOrder(productsWithCharmsOrderDto[1].Amount, productsWithCharmsOrderDto[1].Comment);
            productOrder2.SetCurrentProductPrice(50);
            productOrder2.SetFinalPrice(55);
            productOrder2.SetCharmsPrice(5);
            productOrder2.AddProduct(products[1]);
            productOrder2.AddProductOrderCharms(productOrderCharms2);

            var productOrder3 =
                new ProductOrder(productsWithCharmsOrderDto[2].Amount, productsWithCharmsOrderDto[2].Comment);
            productOrder3.SetCurrentProductPrice(50);
            productOrder3.SetFinalPrice(50);
            productOrder3.SetCharmsPrice(0);
            productOrder3.AddProduct(products[2]);
            productOrder3.AddProductOrderCharms(productOrderCharms3);

            var productOrder4 =
                new ProductOrder(productsWithCharmsOrderDto[3].Amount, productsWithCharmsOrderDto[3].Comment);
            productOrder4.SetCurrentProductPrice(100);
            productOrder4.SetFinalPrice(100);
            productOrder4.SetCharmsPrice(0);
            productOrder4.AddProduct(products[3]);
            productOrder4.AddProductOrderCharms(productOrderCharms4);

            var expected = new List<ProductOrder>
            {
                productOrder1, productOrder2, productOrder3, productOrder4
            };

            return (productsWithCharmsOrderDto, products, charms, expected.OrderBy(s => s.Product.Id).ToList());
        }
    }
}