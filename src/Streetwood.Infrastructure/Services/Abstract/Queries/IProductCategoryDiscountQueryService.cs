using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Models;

namespace Streetwood.Infrastructure.Services.Abstract.Queries
{
    public interface IProductCategoryDiscountQueryService
    {
        Task<IList<ProductCategoryDiscountDto>> GetAsync();

        Task<IList<ProductsCategoriesForDiscountDto>> GetCategoriesForDiscountAsync(Guid id);

        Task<IList<ProductCategoryDiscountDto>> GetEnabledAsync();

        Task<IList<ProductCategoryDiscount>> GetRawActiveAsync();

        IList<ApplyDiscountsToProductsResult> ApplyDiscountsToProducts(IList<Product> products,
            IList<ProductCategoryDiscount> discounts);
    }
}
