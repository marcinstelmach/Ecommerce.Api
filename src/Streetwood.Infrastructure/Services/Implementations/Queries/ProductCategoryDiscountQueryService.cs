using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
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
            return mapper.Map<IList<ProductCategoryDiscountDto>>(discounts);
        }

        public async Task<IList<ProductsCategoriesForDiscountDto>> GetCategoriesAsync(Guid id)
        {
            var discount = await discountRepository.GetAndEnsureExistAsync(id);
            var discountCategories = await discountCategoryRepository.GetCategories(discount);

            var categories = await productCategoryRepository.GetListAsync();
            var mapped = MapCategories(categories, discountCategories);
            return mapped;
        }

        public async Task<IList<ProductCategoryDiscountDto>> GetEnabledAsync()
        {
            var enabledDiscounts = await discountRepository.GetEnabledAsync();

            return mapper.Map<IList<ProductCategoryDiscountDto>>(enabledDiscounts);
        }

        public IList<Tuple<ProductDto, ProductCategoryDiscountDto>> ApplyDiscountsToProducts(IList<ProductDto> products,
            IList<ProductCategoryDiscountDto> discounts)
        {
            if (!products.Any() || !discounts.Any())
            {
                return null;
            }

            var result = new List<Tuple<ProductDto, ProductCategoryDiscountDto>>();
            foreach (var discount in discounts)
            {
                var discountProducts = products.Where(s => discount.CategoryIds.Contains(s.ProductCategoryId)).ToList();
                discountProducts.ForEach(
                    s => result.Add(new Tuple<ProductDto, ProductCategoryDiscountDto>(s, discount)));
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