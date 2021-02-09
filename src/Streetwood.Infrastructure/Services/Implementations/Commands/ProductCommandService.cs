namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Streetwood.Core.Domain.Abstract.Repositories;
    using Streetwood.Core.Domain.Entities;
    using Streetwood.Core.Domain.Enums;
    using Streetwood.Core.Exceptions;
    using Streetwood.Core.Extensions;
    using Streetwood.Infrastructure.Dto;
    using Streetwood.Infrastructure.Dto.Products;
    using Streetwood.Infrastructure.Managers.Abstract;
    using Streetwood.Infrastructure.Services.Abstract.Commands;

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

        public async Task<int> AddAsync(AddProductDto dto)
        {
            var category = await productCategoryRepository.GetAndEnsureExistAsync(dto.ProductCategoryId);
            if (category.HasOneProduct)
            {
                var existingAvailableProducts = category.Products.Where(x => x.Status == ItemStatus.Available);
                if (existingAvailableProducts.Any())
                {
                    throw new StreetwoodException(ErrorCode.ThisProductCategoryCanHasOnlyOneProduct);
                }
            }

            var imagesPath = pathManager.GetProductPath(category.UniqueName, dto.Name.AppendRandom(5));
            var product = new Product(
                dto.Name, dto.NameEng, dto.Price, dto.Description, dto.DescriptionEng, dto.AcceptCharms, dto.AcceptGraver, dto.MaxCharmCount, dto.Sizes, imagesPath);

            category.AddProduct(product);
            await productCategoryRepository.SaveChangesAsync();

            return product.Id;
        }

        public async Task UpdateAsync(int id, string name, string nameEng, decimal price, string description,
            string descriptionEng,
            bool acceptCharms, bool acceptGraver, string sizes, ICollection<ProductColorDto> productColorDtos)
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

            if (productColorDtos != null)
            {
                product.AddProductColors(productColorDtos.Select(x => new ProductColor(x.Name, x.HexValue)));
            }

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
