using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Models;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class ProductCategoryDiscountQueryService : IProductCategoryDiscountQueryService
    {
        private readonly IProductCategoryDiscountRepository discountRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IDiscountCategoryRepository discountCategoryRepository;
        private readonly IMapper mapper;

        public ProductCategoryDiscountQueryService(IProductCategoryDiscountRepository discountRepository,
            IProductCategoryRepository productCategoryRepository,
            IDiscountCategoryRepository discountCategoryRepository,
            IMapper mapper)
        {
            this.discountRepository = discountRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.discountCategoryRepository = discountCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<IList<ProductCategoryDiscountDto>> GetAsync()
        {
            var discounts = await discountRepository.GetListAsync();
            return mapper.Map<IList<ProductCategoryDiscountDto>>(discounts.OrderByDescending(s => s.IsActive)
                .ThenBy(s => s.AvailableTo));
        }

        public async Task<IList<ProductsCategoriesForDiscountDto>> GetCategoriesForDiscountAsync(Guid id)
        {
            var discount = await discountRepository.GetAndEnsureExistAsync(id);
            var discountCategories = await discountCategoryRepository.GetCategories(discount);

            var categories = await productCategoryRepository.GetChildrenAsync();
            var mapped = MapCategories(categories, discountCategories);
            return mapped;
        }

        public async Task<IList<ProductCategoryDiscountDto>> GetEnabledAsync()
        {
            var enabledDiscounts = await GetRawActiveAsync();

            return mapper.Map<IList<ProductCategoryDiscountDto>>(enabledDiscounts);
        }

        public async Task<IList<ProductCategoryDiscount>> GetRawActiveAsync()
            => await discountRepository.GetActiveAsync();

        public IList<ProductWithDiscount> ApplyDiscountsToProducts(IList<Product> products, IList<ProductCategoryDiscount> discounts)
        {
            var result = new List<ProductWithDiscount>();

            if (!products.Any())
            {
                return result;
            }

            foreach (var product in products)
            {
                var discount = discounts.FirstOrDefault(x => x.DiscountCategories.Select(y => y.ProductCategory).Contains(product.ProductCategory));
                result.Add(new ProductWithDiscount(product, discount));
            }

            return result;
        }

        private IList<ProductsCategoriesForDiscountDto> MapCategories(IEnumerable<ProductCategory> dbCategories,
            IList<ProductCategory> discountCategories)
        {
            var mappedCategories = new List<ProductsCategoriesForDiscountDto>();
            foreach (var dbCategory in dbCategories)
            {
                var discountCategory = discountCategories.FirstOrDefault(s => s.Id == dbCategory.Id);
                mappedCategories.Add(discountCategory != null
                    ? new ProductsCategoriesForDiscountDto(dbCategory.Id, dbCategory.Name, true)
                    : new ProductsCategoriesForDiscountDto(dbCategory.Id, dbCategory.Name, false));
            }

            return mappedCategories;
        }
    }
}