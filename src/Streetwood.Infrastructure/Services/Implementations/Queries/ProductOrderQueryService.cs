using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Helpers;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class ProductOrderQueryService : IProductOrderQueryService
    {
        private readonly IProductQueryService productQueryService;
        private readonly ICharmQueryService charmQueryService;
        private readonly IProductCategoryDiscountQueryService productCategoryDiscountQueryService;
        private readonly IProductOrderHelper productOrderHelper;

        public ProductOrderQueryService(
            IProductQueryService productQueryService,
            ICharmQueryService charmQueryService,
            IProductCategoryDiscountQueryService productCategoryDiscountQueryService,
            IProductOrderHelper productOrderHelper)
        {
            this.productQueryService = productQueryService;
            this.charmQueryService = charmQueryService;
            this.productCategoryDiscountQueryService = productCategoryDiscountQueryService;
            this.productOrderHelper = productOrderHelper;
        }

        public async Task<IList<ProductOrder>> CreateAsync(IList<ProductWithCharmsOrderDto> productsWithCharmsOrder)
        {
            var productsIds = productsWithCharmsOrder.Select(s => s.ProductId).Distinct().ToList();
            var charmsIds = productsWithCharmsOrder.SelectMany(s => s.Charms).Select(s => s.CharmId).ToList();
            var products = await productQueryService.GetRawByIdsAsync(productsIds);
            var charms = await charmQueryService.GetRawByIdsAsync(charmsIds);
            var enabledDiscounts = await productCategoryDiscountQueryService.GetRawActiveAsync();
            var productsWithDiscounts = productCategoryDiscountQueryService.ApplyDiscountsToProducts(products, enabledDiscounts);
            var productOrders = new List<ProductOrder>();

            foreach (var productWithCharmsOrder in productsWithCharmsOrder)
            {
                var productOrder = new ProductOrder(productWithCharmsOrder.Amount, productWithCharmsOrder.Comment, productWithCharmsOrder.Size);
                var productWithDiscount = productsWithDiscounts.First(x => x.Product.Id == productWithCharmsOrder.ProductId);
                productOrder.AddProduct(productWithDiscount.Product);

                var finalPrice = productWithDiscount.Product.Price;
                if (productWithCharmsOrder.HaveCharms)
                {
                    var result = productOrderHelper.ApplyCharmsToProductOrder(productOrder, productWithCharmsOrder, charms, finalPrice);
                    finalPrice = result.FinalPrice;
                }

                if (productWithDiscount.ProductCategoryDiscount != null)
                {
                    productOrder.AddProductCategoryDiscount(productWithDiscount.ProductCategoryDiscount);
                    var discountValue = finalPrice * (productWithDiscount.ProductCategoryDiscount.PercentValue / 100.0M);
                    finalPrice -= discountValue;
                }

                productOrder.SetCurrentProductPrice(productWithDiscount.Product.Price);
                productOrder.SetFinalPrice(finalPrice);
                productOrders.Add(productOrder);
            }

            return productOrders;
        }
    }
}