using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class ProductCategoryDiscountCommandService : IProductCategoryDiscountCommandService
    {
        private readonly IProductCategoryDiscountRepository productCategoryDiscountRepository;
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryDiscountCommandService(IProductCategoryDiscountRepository productCategoryDiscountRepository, IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryDiscountRepository = productCategoryDiscountRepository;
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task AddAsync(string name, string nameEng, string description, string descriptionEng, int percentValue,
            DateTime availableFrom, DateTime availableTo)
        {
            var discount = new ProductCategoryDiscount(name, nameEng, description, descriptionEng, percentValue, true,
                availableFrom, availableTo);

            await productCategoryDiscountRepository.AddAsync(discount);
            await productCategoryDiscountRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(IEnumerable<Guid> categoryIds, Guid discountId)
        {
//            var discount = await productCategoryDiscountRepository.GetAndEnsureExistAsync(discountId);
//            var categories = await productCategoryRepository.GetByIdsAsync(categoryIds);
//
//            discount.ProductCategories.Clear();
//            discount.AddProductCategory(categories);
//            await productCategoryDiscountRepository.SaveChangesAsync();
        }
    }
}
