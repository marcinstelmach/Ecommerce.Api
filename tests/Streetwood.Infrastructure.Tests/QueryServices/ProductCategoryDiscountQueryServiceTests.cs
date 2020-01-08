using System.Collections.Generic;
using System.Linq;
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
        private readonly ProductCategoryDiscountQueryService sut;

        public ProductCategoryDiscountQueryServiceTests()
        {
            var discountRepositoryMock = new Mock<IProductCategoryDiscountRepository>();
            var productCategoryRepositoryMock = new Mock<IProductCategoryRepository>();
            var discountCategoryRepositoryMock = new Mock<IDiscountCategoryRepository>();
            var mapperMock = new Mock<IMapper>();
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
            var discounts = new List<ProductCategoryDiscount> {ProductCategoryDiscount};

            // Act
            var result = sut.ApplyDiscountsToProducts(new List<Product>(), discounts);

            // Assert
            result.Should().BeEquivalentTo(new List<ProductWithDiscount>());
        }

        [Fact]
        public void When_Applies_Discount_To_Products_And_There_Is_No_Discounts_Then_Returns_List_Of_Products_Without_Discounts()
        {
            var expected = new List<ProductWithDiscount>();
            Products.ToList().ForEach(x => expected.Add(new ProductWithDiscount(x, null)));

            // Act
            var result = sut.ApplyDiscountsToProducts(Products.ToList(), new List<ProductCategoryDiscount>());

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveSameCount(Products);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void When_Applies_Discount_To_Products_And_There_Are_Discounts_For_This_Products_Then_Returns_Correct_List_Of_Products_With_Discounts()
        {
            // Arrange
            var productCategory = new ProductCategory("", "", false);
            productCategory.AddProduct(Product);
            Product.SetProductCategory(productCategory);
            var discountCategory = new DiscountCategory(productCategory, ProductCategoryDiscount);
            ProductCategoryDiscount.AddProductCategory(new[] {discountCategory});
            var expected = new List<ProductWithDiscount>
            {
                new ProductWithDiscount(Product, ProductCategoryDiscount)
            };

            // Act
            var result = sut.ApplyDiscountsToProducts(new List<Product> {Product},
                new List<ProductCategoryDiscount> {ProductCategoryDiscount});

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void When_Applies_Discount_To_Products_And_There_Are_Discounts_But_Not_For_This_Products_Then_Returns_Correct_List_Of_Products_Without_Discounts()
        {
            // Arrange
            var expected = new List<ProductWithDiscount>
            {
                new ProductWithDiscount(Product, null)
            };

            // Act
            var result = sut.ApplyDiscountsToProducts(new List<Product> {Product},
                new List<ProductCategoryDiscount> {ProductCategoryDiscount});

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }
    }
}