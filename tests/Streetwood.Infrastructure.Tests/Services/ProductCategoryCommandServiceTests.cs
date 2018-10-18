using System;
using System.Threading.Tasks;
using Moq;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Implementations.Commands;
using Xunit;

namespace Streetwood.Infrastructure.Tests.Services
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
            await sut.AddAsync(name, nameEng, null);

            //asert
            productCategoryRepository.Verify(s => s.AddAsync(It.IsAny<ProductCategory>()), Times.Once);
            productCategoryRepository.Verify(s => s.GetAndEnsureExistAsync(It.IsAny<Guid>()), Times.Never);
        }

        [Fact]
        public async Task AddAsync_ForSpecyficCategoryId_ShouldAddCategoryAsChild()
        {
            //arrange
            var productCategoryRepository = new Mock<IProductCategoryRepository>();
            var name = "Name";
            var nameEng = "nameEng";
            var sut = new ProductCategoryCommandService(productCategoryRepository.Object);

            //act
            await sut.AddAsync(name, nameEng, Guid.NewGuid());

            //assert
            productCategoryRepository.Verify(s => s.AddAsync(It.IsAny<ProductCategory>()), Times.Never);
            productCategoryRepository.Verify(s => s.GetAndEnsureExistAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
