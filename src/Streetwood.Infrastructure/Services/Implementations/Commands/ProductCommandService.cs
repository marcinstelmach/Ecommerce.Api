using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Exceptions;
using Streetwood.Core.Extensions;
using Streetwood.Infrastructure.Managers.Abstract;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class ProductCommandService : IProductCommandService
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IProductRepository productRepository;
        private readonly IPathManager pathManager;

        public ProductCommandService(IProductCategoryRepository productCategoryRepository, IPathManager pathManager, IProductRepository productRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.productRepository = productRepository;
            this.pathManager = pathManager;
        }

        public async Task<int> AddAsync(string name, string nameEng, decimal price, string description, string descriptionEng,
            bool acceptCharms, bool acceptGraver, int maxCharmsCount, string sizes, Guid productCategoryId)
        {
            var category = await productCategoryRepository.GetAndEnsureExistAsync(productCategoryId);
            if (category.HasOneProduct && category.Products.Count > 0)
            {
                throw new StreetwoodException(ErrorCode.ThisProductCategoryCanHasOnlyOneProduct);
            }

            var imagesPath = pathManager.GetProductPath(category.UniqueName, name.AppendRandom(5));
            var product = new Product(name, nameEng, price, description, descriptionEng, acceptCharms, acceptGraver, maxCharmsCount, sizes, imagesPath);

            category.AddProduct(product);
            await productCategoryRepository.SaveChangesAsync();

            return product.Id;
        }

        public async Task UpdateAsync(int id, string name, string nameEng, decimal price, string description, string descriptionEng,
            bool acceptCharms, bool acceptGraver, string sizes)
        {
            var product = await productRepository.GetAndEnsureExistAsync(id);
            product.SetName(name);
            product.SetNameEng(name);
            product.SetPrice(price);
            product.SetDescription(description);
            product.SetDescriptionEng(descriptionEng);
            product.SetAcceptCharms(acceptCharms);
            product.SetAcceptGraver(acceptGraver);
            product.SetSizes(sizes);

            await productRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await productRepository.GetAndEnsureExistAsync(id);

            product.SetStatus(ItemStatus.Deleted);
            await productRepository.SaveChangesAsync();
        }
    }
}
