using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IDiscountCategoryRepository discountCategoryRepository;

        public ProductCategoryDiscountCommandService(IProductCategoryDiscountRepository productCategoryDiscountRepository,
            IProductCategoryRepository productCategoryRepository,
            IDiscountCategoryRepository discountCategoryRepository)
        {
            this.productCategoryDiscountRepository = productCategoryDiscountRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.discountCategoryRepository = discountCategoryRepository;
        }

        public async Task AddAsync(string name, string nameEng, string description, string descriptionEng, int percentValue,
            DateTime availableFrom, DateTime availableTo)
        {
            var discount = new ProductCategoryDiscount(name, nameEng, description, descriptionEng, percentValue, true,
                availableFrom, availableTo);

            await productCategoryDiscountRepository.AddAsync(discount);
            await productCategoryDiscountRepository.SaveChangesAsync();
        }

        public async Task SetCategoriesAsync(Guid discountId, IEnumerable<Guid> categoryIds)
        {
            var discount = await productCategoryDiscountRepository.GetAndEnsureExistAsync(discountId);
            var categories = await productCategoryRepository.GetByIdsAsync(categoryIds);
            await discountCategoryRepository.DeleteRangeAsync(discount);

            var discountCategories = categories.Select(category => new DiscountCategory(category, discount)).ToList();

            await discountCategoryRepository.AddRangeAsync(discountCategories);
            await discountCategoryRepository.SaveChangesAsync();

        }

        public async Task UpdateAsync(Guid id, string name, string nameEng, string description, string descriptionEng, int percentValue,
            DateTime availableFrom, DateTime availableTo)
        {
            var discount = await productCategoryDiscountRepository.GetAndEnsureExistAsync(id);

            discount.SetDescription(description);
            discount.SetDescriptionEng(descriptionEng);
            discount.SetPercentValue(percentValue);
            discount.SetAvaibleFrom(availableFrom);
            discount.SetAvaibleTo(availableTo);
            discount.SetName(name);
            discount.SetNameEng(nameEng);

            await productCategoryDiscountRepository.SaveChangesAsync();
        }
    }
}
