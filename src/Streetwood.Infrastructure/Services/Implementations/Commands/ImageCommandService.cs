using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class ImageCommandService : IImageCommandService
    {
        private readonly IProductRepository productRepository;
        private readonly IImageRepository imageRepository;
        private readonly IPathManager pathManager;
        private readonly IFileManager fileManager;

        public ImageCommandService(IProductRepository productRepository, IImageRepository imageRepository, IPathManager pathManager, IFileManager fileManager)
        {
            this.productRepository = productRepository;
            this.imageRepository = imageRepository;
            this.pathManager = pathManager;
            this.fileManager = fileManager;
        }

        public async Task AddAsync(IFormFile file, int productId, bool isMain)
        {
            var product = await productRepository.GetAndEnsureExistAsync(productId);
            var directoryPath = pathManager.GetProductImagesPath(product.ProductCategory.Name, product.Name);
            var imageName = fileManager.GetUniqueName(file.FileName);

            var imagePath = Path.Combine(directoryPath, imageName);
            var image = new Image(imagePath, isMain);
            product.AddImage(image);
            await productRepository.SaveChangesAsync();

            var physicalPath = pathManager.GetPhysicalPath(directoryPath);
            await fileManager.MoveFileAsync(file, physicalPath, imageName);
        }

        public async Task DeleteAsync(Guid id)
        {
            var image = await imageRepository.GetAndEnsureExistAsync(id);
            var physicalImagePath = pathManager.GetPhysicalPath(image.ImageUrl);
            try
            {
                File.Delete(physicalImagePath);
            }
            catch (Exception e)
            {
                throw new StreetwoodException(ErrorCode.UnableToDeletePhoto, e.Message, e);
            }

            await imageRepository.DeleteAsync(image);
            await imageRepository.SaveChangesAsync();
        }
    }
}
