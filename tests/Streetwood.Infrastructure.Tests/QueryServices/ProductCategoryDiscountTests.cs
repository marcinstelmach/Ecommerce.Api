using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Implementations.Queries;
using Xunit;

namespace Streetwood.Infrastructure.Tests.QueryServices
{
    public class ProductCategoryDiscountTests
    {
        private readonly Mock<IProductCategoryDiscountRepository> categoryDiscountRepository;
        private readonly Mock<IProductCategoryRepository> productCategoryRepository;
        private readonly Mock<IDiscountCategoryRepository> discountCategoryRepository;
        private readonly Mock<IMapper> mapper;

        public ProductCategoryDiscountTests()
        {
            categoryDiscountRepository = new Mock<IProductCategoryDiscountRepository>();
            productCategoryRepository = new Mock<IProductCategoryRepository>();
            discountCategoryRepository = new Mock<IDiscountCategoryRepository>();
            mapper = new Mock<IMapper>();
        }

        [Fact]
        public void ApplyDiscountsToProducts_ForEmptyProducts_NotReturnsNull()
        {
            // arrange
            var products = new List<Product>();
            var discounts = new List<ProductCategoryDiscount>
            {
                new ProductCategoryDiscount("Name", "", "", "", 35, DateTime.Now, DateTime.Now.AddDays(3))
            };
            var sut = new ProductCategoryDiscountQueryService(categoryDiscountRepository.Object,
                productCategoryRepository.Object, discountCategoryRepository.Object, mapper.Object);

            // act
            var result = sut.ApplyDiscountsToProducts(products, discounts);

            // assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void ApplyDiscountsToProducts_ForEmptyDiscounts_NotReturnsNull()
        {
            // arrange
            var products = new List<Product>
            {
                new Product("", "", 35, "", "", true, "", "")
            };
            var discounts = new List<ProductCategoryDiscount>();
            var sut = new ProductCategoryDiscountQueryService(categoryDiscountRepository.Object,
                productCategoryRepository.Object, discountCategoryRepository.Object, mapper.Object);

            // act
            var result = sut.ApplyDiscountsToProducts(products, discounts);

            // assert
            result.Should().NotBeNull();
        }

        [Fact]
        public void ApplyDiscountToProducts_WhenAreDiscounts_ReturnValidPairs()
        {
            // arrange
            var (products, discounts) = PrepareProductsWithDiscounts();

            var expected = new List<(int, ProductCategoryDiscount)>
            {
                (products[0].Id, discounts[0]),
                (products[1].Id, discounts[0]),
                (products[2].Id, discounts[1]),
                (products[3].Id, null)
            };

            // act
            var sut = new ProductCategoryDiscountQueryService(categoryDiscountRepository.Object,
                productCategoryRepository.Object, discountCategoryRepository.Object, mapper.Object);

            var result = sut.ApplyDiscountsToProducts(products, discounts);

            // assert
            result.Count.Should().Be(products.Count);
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void ApplyDiscountToProducts_ReturnProductsIfDifferentDiscount()
        {
            // arrange
            var data = PrepareProductsWithDiscounts();

            // product and discount are not joined
            var products = data.Item1;
            var discounts = data.Item2;

            // act
            var sut = new ProductCategoryDiscountQueryService(categoryDiscountRepository.Object,
                productCategoryRepository.Object, discountCategoryRepository.Object, mapper.Object);
            var result = sut.ApplyDiscountsToProducts(products, discounts);
            var productsWithoutDiscounts = result.Where(s => s.Item2 == null);

            // assert
            productsWithoutDiscounts.Count().Should().Be(1);
        }

        private (List<Product>, List<ProductCategoryDiscount>) PrepareProductsWithDiscounts()
        {
            var product1 = new Product("Test", "Test", 50, "Test", "Test", true, "", "") { Id = 1 };
            var product2 = new Product("Test2", "Test2", 40, "Test2", "Test2", true, "", "") { Id = 2 };
            var product3 = new Product("Test3", "Test3", 30, "Test3", "Test3", true, "", "") { Id = 3 };
            var product4 = new Product("Test4", "Test3", 30, "Test3", "Test3", true, "", "") { Id = 4 };

            var category1 = new ProductCategory("Test1", "Test1");
            var category2 = new ProductCategory("Test2", "Test2");

            product1.SetProductCategory(category1);
            product2.SetProductCategory(category1);
            product3.SetProductCategory(category2);

            var productCategoryDiscount1 = new ProductCategoryDiscount("Test1", "Test1", "Test1", "Test1", 30, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(10));
            var productCategoryDiscount2 = new ProductCategoryDiscount("Test2", "Test2", "Test2", "Test2", 30, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(10));

            var discountCategory1 = new DiscountCategory(category1, productCategoryDiscount1);
            var discountCategory2 = new DiscountCategory(category2, productCategoryDiscount2);

            productCategoryDiscount1.AddProductCategory(new[] { discountCategory1 });
            productCategoryDiscount2.AddProductCategory(new[] { discountCategory2 });

            var products = new List<Product> { product1, product2, product3, product4 };
            var discounts = new List<ProductCategoryDiscount> { productCategoryDiscount1, productCategoryDiscount2 };

            return (products, discounts);
        }
    }
}