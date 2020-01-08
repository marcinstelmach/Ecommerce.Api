using System;
using System.Linq;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
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

        public async Task AddAsync(string name, string nameEng, Guid? productCategoryId, bool hasOneProduct)
        {
            var productCategory = new ProductCategory(name, nameEng, hasOneProduct);
            if (productCategoryId == null)
            {
                await productCategoryRepository.AddAsync(productCategory);
            }
            else
            {
                var rootProductCategory = await productCategoryRepository.GetAndEnsureExistAsync(productCategoryId.Value);
                rootProductCategory.AddCategoryProduct(productCategory);
            }

            await productCategoryRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, string name, string nameEng)
        {
            var category = await productCategoryRepository.GetWithChildrenAsync(id);
            category.SetName(name);
            category.SetNameEng(nameEng);

            await productCategoryRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await productCategoryRepository.GetAndEnsureExistAsync(id);
            var products = category.Products.ToList();

            products.ForEach(s => s.SetStatus(ItemStatus.Deleted));
            category.SetStatus(ItemStatus.Deleted);

            await productCategoryRepository.SaveChangesAsync();
        }
    }
}
