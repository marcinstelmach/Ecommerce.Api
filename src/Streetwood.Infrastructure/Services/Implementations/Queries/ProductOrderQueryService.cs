using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Services.Implementations.Queries
{
    internal class ProductOrderQueryService : IProductOrderQueryService
    {
        private readonly IProductQueryService productQueryService;
        private readonly ICharmQueryService charmQueryService;
        private readonly IProductCategoryDiscountQueryService productCategoryDiscountQueryService;

        public ProductOrderQueryService(IProductQueryService productQueryService, ICharmQueryService charmQueryService, IProductCategoryDiscountQueryService productCategoryDiscountQueryService)
        {
            this.productQueryService = productQueryService;
            this.charmQueryService = charmQueryService;
            this.productCategoryDiscountQueryService = productCategoryDiscountQueryService;
        }

        public async Task<IList<ProductOrder>> CreateAsync(IList<ProductWithCharmsOrderDto> productsWithCharmsOrder)
        {
            var productsIds = productsWithCharmsOrder.Select(s => s.ProductId);
            var charmsIds = productsWithCharmsOrder.SelectMany(s => s.Charms).Select(s => s.CharmId).ToList();
            var products = await productQueryService.GetRawByIds(productsIds);
            var charms = await charmQueryService.GetRawByIdsAsync(charmsIds);
            var enabledDiscounts = await productCategoryDiscountQueryService.GetRawEnabledAsync();
            var productsDiscounts = productCategoryDiscountQueryService.ApplyDiscountsToProducts(products, enabledDiscounts);
            var productOrders = new List<ProductOrder>();

            foreach (var productWithCharmsOrder in productsWithCharmsOrder)
            {
                var productOrderCharms = new List<ProductOrderCharm>();
                if (productWithCharmsOrder.HaveCharms)
                {
                    productOrderCharms.AddRange(CreateProductOrderCharms(productWithCharmsOrder.Charms, charms));
                }

                var product = products.SingleOrDefault(s => s.Id == productWithCharmsOrder.ProductId);
                if (product == null)
                {
                    throw new StreetwoodException(ErrorCode.OrderProductsNotFound);
                }

                var discount = productsDiscounts.FirstOrDefault(s => s.Item1 == product.Id).Item2;
                var agreedPrice = product.Price;
                if (discount != null)
                {
                    agreedPrice = agreedPrice * (discount.PercentValue / 100.0M);
                }

                var productOrder = new ProductOrder(productWithCharmsOrder.Amount, productWithCharmsOrder.Comment);
                productOrder.AddProduct(product);
                productOrder.AddProductOrderCharms(productOrderCharms);
                productOrder.SetCurrentProductPrice(product.Price);
                productOrder.AddProductCategoryDiscount(discount);
                productOrder.SetAgreedPrice(agreedPrice);

                productOrders.Add(productOrder);
            }

            return productOrders;
        }

        private IEnumerable<ProductOrderCharm> CreateProductOrderCharms(IEnumerable<CharmOrderDto> charmsOrderDto, IList<Charm> charms)
        {
            var productOrderCharms = new List<ProductOrderCharm>();
            foreach (var charmOrder in charmsOrderDto)
            {
                var charm = charms.SingleOrDefault(s => s.Id == charmOrder.CharmId);
                if (charm == null)
                {
                    throw new StreetwoodException(ErrorCode.OrderCharmsNotFound);
                }

                var productCharmOrder = new ProductOrderCharm(charm, charmOrder.Sequence);
                productOrderCharms.Add(productCharmOrder);
            }

            return productOrderCharms;
        }
    }
}