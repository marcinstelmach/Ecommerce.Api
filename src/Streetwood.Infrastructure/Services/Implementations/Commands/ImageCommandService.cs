using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class ImageCommandService : IImageCommandService
    {
        private readonly IProductRepository productRepository;
        private readonly IPathManager pathManager;
        private readonly IFileManager fileManager;

        public ImageCommandService(IProductRepository productRepository, IPathManager pathManager, IFileManager fileManager)
        {
            this.productRepository = productRepository;
            this.pathManager = pathManager;
            this.fileManager = fileManager;
        }

        public async Task AddAsync(IFormFile file, int productId, bool isMain)
        {
            var product = await productRepository.GetAndEnsureExistAsync(productId);
            var directoryPath = pathManager.GetProductImagesPath(product.ProductCategory.Name, product.Name);
            var imagePath = Path.Combine(directoryPath, fileManager.GetUniqueName(file.FileName));
            var image = new Image(imagePath, isMain);
            product.AddImage(image);
            await productRepository.SaveChangesAsync();

            await fileManager.MoveFile(file, directoryPath, imagePath);
        }
    }
}
