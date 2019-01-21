using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Streetwood.Core.Domain.Abstract.Repositories;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class ProductCategoryQueryService : IProductCategoryQueryService
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IMapper mapper;

        public ProductCategoryQueryService(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.mapper = mapper;
        }

        public async Task<ProductCategoryDto> GetByIdAsync(Guid id)
        {
            var productCategory = await productCategoryRepository.GetWithChildrenAsync(id);
            return mapper.Map<ProductCategoryDto>(productCategory);
        }

        public async Task<IList<ProductCategoryDto>> GetAvailableAsync()
        {
            var productCategories = await productCategoryRepository.GetAvailableTreeAsync();
            return mapper.Map<IList<ProductCategoryDto>>(productCategories);
        }
    }
}
