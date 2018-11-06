using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Core.Extensions;
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

        public ImageCommandService(IProductRepository productRepository,
            IImageRepository imageRepository,
            IPathManager pathManager,
            IFileManager fileManager)
        {
            this.productRepository = productRepository;
            this.imageRepository = imageRepository;
            this.pathManager = pathManager;
            this.fileManager = fileManager;
        }

        public async Task AddAsync(IFormFile file, int productId, bool isMain)
        {
            var product = await productRepository.GetAndEnsureExistAsync(productId);
            var uniqueFileName = file.FileName.GetUniqueFileName();

            var imagePath = Path.Combine(product.ImagesPath, uniqueFileName);
            var image = new Image(imagePath, isMain);
            product.AddImage(image);
            await productRepository.SaveChangesAsync();

            var imagesPhysicalPath = pathManager.GetPhysicalPath(product.ImagesPath);
            await fileManager.MoveFileAsync(file, imagesPhysicalPath, uniqueFileName);
        }

        public async Task DeleteAsync(Guid id)
        {
            var image = await imageRepository.GetAndEnsureExistAsync(id);
            var physicalImagePath = pathManager.GetPhysicalPath(image.ImageUrl);
            try
            {
                File.Delete(physicalImagePath);
            }
            catch (Exception ex)
            {
                throw new StreetwoodException(ErrorCode.UnableToDeletePhoto, ex.Message, ex);
            }

            await imageRepository.DeleteAsync(image);
            await imageRepository.SaveChangesAsync();
        }
    }
}