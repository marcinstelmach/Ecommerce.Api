using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IProductCategoryDiscountQueryService
    {
        Task<IList<ProductCategoryDiscountDto>> GetAsync();

        Task<IList<ProductsCategoriesForDiscountDto>> GetCategoriesAsync(Guid id);

        Task<IList<ProductCategoryDiscountDto>> GetEnabledAsync();

        IList<Tuple<ProductDto, ProductCategoryDiscountDto>> ApplyDiscountsToProducts(IList<ProductDto> products,
            IList<ProductCategoryDiscountDto> discounts);
    }
}
