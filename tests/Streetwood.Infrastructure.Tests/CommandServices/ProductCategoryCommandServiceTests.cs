using System;
using System.Threading.Tasks;
using Moq;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Implementations.Commands;
using Xunit;

namespace Streetwood.Infrastructure.Tests.CommandServices
{
    public class ProductCategoryCommandServiceTests
    {
        [Fact]
        public async Task AddAsync_ForNullCategoryId_ShouldCreateRootCategory()
        {
            //arrange
            var productCategoryRepository = new Mock<IProductCategoryRepository>();
            var name = "Name";
            var nameEng = "nameEng";
            var sut = new ProductCategoryCommandService(productCategoryRepository.Object);

            //act
            await sut.AddAsync(name, nameEng, null, false);

            //assert
            productCategoryRepository.Verify(s => s.AddAsync(It.IsAny<ProductCategory>()), Times.Once);
            productCategoryRepository.Verify(s => s.GetAndEnsureExistAsync(It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task AddAsync_ForSpecificCategoryId_ShouldAddCategoryAsChild()
        {
            //arrange
            var productCategoryRepository = new Mock<IProductCategoryRepository>();
            var name = "Name";
            var nameEng = "nameEng";
            productCategoryRepository.Setup(s => s.GetAndEnsureExistAsync(It.IsAny<Guid>())).ReturnsAsync(new ProductCategory(name, nameEng, false));
            var sut = new ProductCategoryCommandService(productCategoryRepository.Object);

            //act
            await sut.AddAsync(name, nameEng, Guid.NewGuid(), false);

            //assert
            productCategoryRepository.Verify(s => s.AddAsync(It.IsAny<ProductCategory>()), Times.Never);
            productCategoryRepository.Verify(s => s.GetAndEnsureExistAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
