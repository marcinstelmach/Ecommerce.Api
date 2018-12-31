using System;
using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Dto;
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
        public void ApplyDiscountsToProducts_ForEmptyDiscounts_ReturnsNull()
        {
            // arrange
            var products = new List<Product>
            {
                new Product("", "", 30, "", "", true, "", "")
            };
            var discounts = new List<ProductCategoryDiscount>();
            var sut = new ProductCategoryDiscountQueryService(categoryDiscountRepository.Object,
                productCategoryRepository.Object, discountCategoryRepository.Object, mapper.Object);

            // act
            var result = sut.ApplyDiscountsToProducts(products, discounts);

            // assert
            result.Should().BeNull();
        }

        [Fact]
        public void ApplyDiscountToProducts_ReturnValidPairs()
        {
            // arrange
            var product1 = new Product("Test", "Test", 50, "Test", "Test", true, "", "");
            var product2 = new Product("Test2", "Test2", 40, "Test2", "Test2", true, "", "");
            var product3 = new Product("Test3", "Test3", 30, "Test3", "Test3", true, "", "");
            var product4 = new Product("Test4", "Test3", 30, "Test3", "Test3", true, "", "");

            var category1 = new ProductCategory("Test1", "Test1");
            var category2 = new ProductCategory("Test2", "Test2");

            product1.SetProductCategory(category1);
            product2.SetProductCategory(category1);
            product3.SetProductCategory(category2);

            var productCategoryDiscount1 = new ProductCategoryDiscount("Test1", "Test1", "Test1", "Test1", 30, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(10));
            var productCategoryDiscount2 = new ProductCategoryDiscount("Test2", "Test2", "Test2", "Test2", 30, true, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(10));

            var discountCategory1 = new DiscountCategory(category1, productCategoryDiscount1);
            var discountCategory2 = new DiscountCategory(category2, productCategoryDiscount2);

            productCategoryDiscount1.AddProductCategory(new []{discountCategory1});
            productCategoryDiscount2.AddProductCategory(new []{discountCategory2});

            var products = new List<Product>{product1, product2, product3, product4};
            var discount = new List<ProductCategoryDiscount>{productCategoryDiscount1, productCategoryDiscount2};

            // act
            var sut = new ProductCategoryDiscountQueryService(categoryDiscountRepository.Object,
                productCategoryRepository.Object, discountCategoryRepository.Object, mapper.Object);

            var result = sut.ApplyDiscountsToProducts(products, discount);

            // assert
        }

        //        private List<(Product, List<ProductCategoryDiscount>)> PrepareTestData()
        //        {
        //            var categoryIds = new List<Guid>
        //            {
        //                Guid.NewGuid(),
        //                Guid.NewGuid(),
        //                Guid.NewGuid(),
        //                Guid.NewGuid()
        //            };
        //
        //            var products = new List<ProductDto>();
        //            var discounts = new List<ProductCategoryDiscountDto>();
        //
        //            // we add 2 real products and last fake, not belong to any categories
        //            foreach (var id in categoryIds)
        //            {
        //                products.Add(new ProductDto
        //                {
        //                    Id = 10.GetRandom(),
        //                    ProductCategoryId = id
        //                });
        //                products.Add(new ProductDto
        //                {
        //                    Id = 10.GetRandom(),
        //                    ProductCategoryId = id
        //                });
        //                products.Add(new ProductDto
        //                {
        //                    Id = 10.GetRandom(),
        //                    ProductCategoryId = Guid.NewGuid()
        //                });
        //            }
        //
        //            // and here 2 real discounts and one fake 
        //            discounts.Add(new ProductCategoryDiscountDto
        //            {
        //                Id = Guid.NewGuid(),
        //                CategoryIds = new List<Guid>
        //                {
        //                    categoryIds[0],
        //                    categoryIds[1]
        //                }
        //            });
        //
        //            discounts.Add(new ProductCategoryDiscountDto
        //            {
        //                Id = Guid.NewGuid(),
        //                CategoryIds = new List<Guid>
        //                {
        //                    categoryIds[2],
        //                    categoryIds[3]
        //                }
        //            });
        //
        //            discounts.Add(new ProductCategoryDiscountDto
        //            {
        //                Id = Guid.NewGuid(),
        //                CategoryIds = new List<Guid>
        //                {
        //                    Guid.NewGuid(),
        //                    Guid.NewGuid()
        //                }
        //            });
        //
        //            return (products, discounts);
        //        }
    }
}