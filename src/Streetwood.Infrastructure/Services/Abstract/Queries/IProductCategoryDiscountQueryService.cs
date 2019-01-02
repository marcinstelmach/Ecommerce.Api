using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IProductCategoryDiscountQueryService
    {
        Task<IList<ProductCategoryDiscountDto>> GetAsync();

        Task<IList<ProductsCategoriesForDiscountDto>> GetCategoriesAsync(Guid id);

        Task<IList<ProductCategoryDiscountDto>> GetEnabledAsync();

        Task<IList<ProductCategoryDiscount>> GetRawEnabledAsync();

        IList<(int, ProductCategoryDiscount)> ApplyDiscountsToProducts(IList<Product> products,
            IList<ProductCategoryDiscount> discounts);
    }
}
