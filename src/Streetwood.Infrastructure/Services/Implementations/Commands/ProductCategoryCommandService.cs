using System;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class ProductCategoryCommandService : IProductCategoryCommandService
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryCommandService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task AddAsync(string name, string nameEng, Guid? productCategoryId)
        {
            var productCategory = new ProductCategory(name, nameEng);
            if (productCategoryId == null)
            {
                await productCategoryRepository.AddAsync(productCategory);
            }
            else
            {
                var rootproductCategory = await productCategoryRepository.GetAndEnsureExist(productCategoryId.Value);
                rootproductCategory.AddCategoryProduct(productCategory);
            }

            await productCategoryRepository.SaveChangesAsync();
        }
    }
}
