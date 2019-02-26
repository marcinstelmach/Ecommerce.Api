using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Domain.Enums;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class ProductQueryService : IProductQueryService
    {
        private readonly IProductRepository productRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IProductCategoryDiscountRepository productCategoryDiscountRepository;
        private readonly IMapper mapper;

        public ProductQueryService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository,
            IProductCategoryDiscountRepository productCategoryDiscountRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.productCategoryDiscountRepository = productCategoryDiscountRepository;
            this.mapper = mapper;
        }

        public async Task<IList<ProductListDto>> GetAsync()
        {
            var products = await productRepository.GetListAsync();
            return mapper.Map<IList<ProductListDto>>(products);
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var product = await productRepository.GetAndEnsureExistAsync(id);
            return mapper.Map<ProductDto>(product);
        }

        public async Task<IList<ProductDto>> GetAvailableByCategoryIdAsync(Guid id)
        {
            var category = await productCategoryRepository.GetAndEnsureExistAsync(id);
            var availableProducts = category.Products.Where(s => s.Status == ItemStatus.Available);
            return mapper.Map<IList<ProductDto>>(availableProducts);
        }

        public async Task<IList<ProductWithDiscountDto>> GetAvailableWithDiscountByCategoryIdAsync(Guid id)
        {
            var category = await productCategoryRepository.GetAndEnsureExistAsync(id);
            var products = category.Products;
            var productsDto = mapper.Map<List<ProductWithDiscountDto>>(products);
            var discounts = await productCategoryDiscountRepository.GetActiveByCategoryId(id);
            if (discounts.Any())
            {
                var max = discounts.Max(s => s.PercentValue);
                var higherDiscount = mapper.Map<ProductCategoryDiscountDto>(discounts.FirstOrDefault(s => s.PercentValue == max));

                productsDto.ForEach(s => s.Discount = higherDiscount);
            }

            return productsDto;
        }

        public async Task<IList<Product>> GetRawByIdsAsync(IEnumerable<int> ids)
        {
            var products = await productRepository.GetByIdsAsync(ids);

            if (!products.Any())
            {
                throw new StreetwoodException(ErrorCode.OrderProductsNotFound);
            }

            return products;
        }
    }
}