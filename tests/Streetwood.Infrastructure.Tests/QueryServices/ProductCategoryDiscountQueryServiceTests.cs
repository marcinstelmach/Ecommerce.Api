using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Models;
using Streetwood.Infrastructure.Services.Implementations.Queries;
using Streetwood.Test.Helpers.Fixtures;
using Xunit;

namespace Streetwood.Infrastructure.Tests.QueryServices
{
    public class ProductCategoryDiscountQueryServiceTests : EntitiesFixtures
    {
        private readonly Mock<IProductCategoryDiscountRepository> discountRepositoryMock;
        private readonly Mock<IProductCategoryRepository> productCategoryRepositoryMock;
        private readonly Mock<IDiscountCategoryRepository> discountCategoryRepositoryMock;
        private readonly Mock<IMapper> mapperMock;
        private readonly ProductCategoryDiscountQueryService sut;

        public ProductCategoryDiscountQueryServiceTests()
        {
            discountRepositoryMock = new Mock<IProductCategoryDiscountRepository>();
            productCategoryRepositoryMock = new Mock<IProductCategoryRepository>();
            discountCategoryRepositoryMock = new Mock<IDiscountCategoryRepository>();
            mapperMock = new Mock<IMapper>();
            sut = new ProductCategoryDiscountQueryService(
                discountRepositoryMock.Object,
                productCategoryRepositoryMock.Object,
                discountCategoryRepositoryMock.Object,
                mapperMock.Object);
        }

        [Fact]
        public void When_Applies_Discounts_To_Products_And_There_Is_No_Products_Then_Returns_Empty_List()
        {
            // Arrange
            var discounts = new List<ProductCategoryDiscount> { ProductCategoryDiscount };

            // Act
            var result = sut.ApplyDiscountsToProducts(new List<Product>(), discounts);

            // Assert
            result.Should().BeEquivalentTo(new List<ApplyDiscountsToProductsResult>());
        }

        [Fact]
        public void When_Applies_Discounts_To_Products_And_There_Is_No_Product_Category_Discounts_Then_Returns_Empty_List()
        {
            // Arrange
            var products = new List<Product> { Product };

            // Act
            var result = sut.ApplyDiscountsToProducts(products, new List<ProductCategoryDiscount>());

            // Assert
            result.Should().BeEquivalentTo(new List<ApplyDiscountsToProductsResult>());
        }
    }
}