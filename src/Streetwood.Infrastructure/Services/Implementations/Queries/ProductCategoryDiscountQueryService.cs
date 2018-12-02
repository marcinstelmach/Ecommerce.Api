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
        private readonly IMapper mapper;

        public ProductCategoryDiscountQueryService(IProductCategoryDiscountRepository discountRepository, IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            this.discountRepository = discountRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<IList<ProductCategoryDiscountDto>> GetAsync()
        {
            var discounts = await discountRepository.GetListAsync();
            return mapper.Map<IList<ProductCategoryDiscountDto>>(discounts);
        }

        public async Task<ProductCategoryDiscountWithDataDto> GetWithDataAsync(Guid id)
        {
//            var discount = await discountRepository.GetAndEnsureExistAsync(id);
//            var discountCategories = discount.ProductCategories;
//            var categories = await productCategoryRepository.GetListAsync();
//
//            var mappedCategories = MapCategories(categories, discountCategories);

            return null;
        }

        private IList<ProductCategoryDiscountWithDataDto> MapCategories(IList<ProductCategory> dbCategories,
            IList<ProductCategory> discountCategories)
        {
            var mappedCategories = new List<ProductCategoryDiscountWithDataDto>();
            foreach (var dbCategory in dbCategories)
            {
                var discountCategory = discountCategories.FirstOrDefault(s => s.Id == dbCategory.Id);
                if (discountCategory != null)
                {
                    mappedCategories.Add(new ProductCategoryDiscountWithDataDto(dbCategory.Id, dbCategory.Name, true));
                }

                mappedCategories.Add(new ProductCategoryDiscountWithDataDto(dbCategory.Id, dbCategory.Name, false));
            }

            return mappedCategories;
        }
    }
}
