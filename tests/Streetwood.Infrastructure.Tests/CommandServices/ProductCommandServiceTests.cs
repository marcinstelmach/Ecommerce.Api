using System;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto.Products;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Implementations.Commands;
using Xunit;

namespace Streetwood.Infrastructure.Tests.CommandServices
{
    public class ProductCommandServiceTests
    {
        private readonly Mock<IProductCategoryRepository> productCategoryRepositoryMock;
        private readonly Mock<IProductRepository> productRepositoryMock;
        private readonly Mock<IPathManager> pathManagerMock;
        private readonly ProductCommandService sut;

        public ProductCommandServiceTests()
        {
            productCategoryRepositoryMock = new Mock<IProductCategoryRepository>();
            productRepositoryMock = new Mock<IProductRepository>();
            pathManagerMock = new Mock<IPathManager>();
            sut = new ProductCommandService(productCategoryRepositoryMock.Object, pathManagerMock.Object, productRepositoryMock.Object);
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Product_Then_Gets_Category_From_Repository(AddProductDto dto)
        {
            // Arrange
            productCategoryRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<Guid>()))
                .ReturnsAsync(CreateProductCategory(false));

            // Act
            await sut.AddAsync(dto);

            // Assert
            productCategoryRepositoryMock.Verify(x => x.GetAndEnsureExistAsync(dto.ProductCategoryId), Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Product_And_Category_Has_Only_One_Product_Flag_And_Already_Exists_One_Product_Then_Throws_Exception(
            AddProductDto dto, Product product)
        {
            // Arrange
            var productCategory = CreateProductCategory(true);
            productCategory.AddProduct(product);
            productCategoryRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<Guid>()))
                .ReturnsAsync(productCategory);

            // Act
            Func<Task> func = () => sut.AddAsync(dto);

            // Assert
            await func.Should().ThrowAsync<StreetwoodException>();
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Product_And_Category_Has_Only_One_Product_Flag_And_Already_Does_Not_Exists_One_Product_Then_Does_Not_Throw_Exception(
            AddProductDto dto)
        {
            // Arrange
            var productCategory = CreateProductCategory(true);
            productCategoryRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<Guid>()))
                .ReturnsAsync(productCategory);

            // Act
            Func<Task> func = () => sut.AddAsync(dto);

            // Assert
            await func.Should().NotThrowAsync<StreetwoodException>();
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Product_Then_Gets_Product_Path_From_Manager(AddProductDto dto)
        {
            // Arrange
            var category = CreateProductCategory(false);
            productCategoryRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<Guid>()))
                .ReturnsAsync(category);

            // Act
            await sut.AddAsync(dto);

            // Assert
            pathManagerMock.Verify(
                x => x.GetProductPath(category.UniqueName, It.IsAny<string>()),
                Times.Once);
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Product_Then_Adds_Product_To_Category(AddProductDto dto, string imagesPath)
        {
            // Arrange
            var category = CreateProductCategory(false);
            productCategoryRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<Guid>()))
                .ReturnsAsync(category);
            pathManagerMock.Setup(x => x.GetProductPath(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(imagesPath);

            // Act
            await sut.AddAsync(dto);

            // Assert
            category.Products.Should().HaveCount(1);
            var product = category.Products.First();
            product.Name.Should().Be(dto.Name);
            product.NameEng.Should().Be(dto.NameEng);
            product.Price.Should().Be(dto.Price);
            product.Description.Should().Be(dto.Description);
            product.DescriptionEng.Should().Be(dto.DescriptionEng);
            product.AcceptCharms.Should().Be(dto.AcceptCharms);
            product.Sizes.Should().Be(dto.Sizes);
            product.ImagesPath.Should().Be(imagesPath);
        }

        [Theory]
        [AutoData]
        public async Task When_Adding_Product_Then_Saves_Changes_In_Repository(AddProductDto productDto)
        {
            // Arrange
            productCategoryRepositoryMock.Setup(x => x.GetAndEnsureExistAsync(It.IsAny<Guid>()))
                .ReturnsAsync(CreateProductCategory(false));

            // Act
            await sut.AddAsync(productDto);

            // Assert
            productCategoryRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        private static ProductCategory CreateProductCategory(bool hasOneProduct)
        {
            var fixture = new Fixture();
            return new ProductCategory(fixture.Create<string>(), fixture.Create<string>(), hasOneProduct);
        }
    }
}