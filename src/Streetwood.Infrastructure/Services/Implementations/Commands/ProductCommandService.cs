using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class ProductCommandService : IProductCommandService
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCommandService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task AddAsync(string name, string nameEng, decimal price, string description, string descriptionEng, bool acceptCharms, string sizes, Guid productCategoryId)
        {
            var category = await productCategoryRepository.GetAndEnsureExistAsync(productCategoryId);
            category.AddProduct(new Product(name, nameEng, price, description, descriptionEng, acceptCharms, sizes));
            await productCategoryRepository.SaveChangesAsync();
        }
    }
}
