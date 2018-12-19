using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Streetwood.Infrastructure.Commands.Models.Order;
using Streetwood.Infrastructure.Services.Abstract.Queries;

namespace Streetwood.Infrastructure.Commands.Handlers.Order
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandModel, Unit>
    {
        private readonly IProductQueryService productQueryService;
        private readonly ICharmQueryService charmQueryService;
        private readonly IProductCategoryDiscountQueryService productCategoryDiscountQueryService;
        private readonly IUserQueryService userQueryService;
        private readonly IShipmentQueryService shipmentQueryService;
        private readonly IOrderDiscountQueryService orderDiscountQueryService;

        public async Task<Unit> Handle(AddOrderCommandModel request, CancellationToken cancellationToken)
        {
            // on this level we have everything validated and checked => no validation here

            // Get user
            var user = await userQueryService.GetByIdAsync(request.UserId);

            // Get products by ids
            var productsIds = request.Products.Select(s => s.ProductId);
            var products = await productQueryService.GetRawByIds(productsIds);

            // Get charms by ids
            var charmsIds = request.Products.SelectMany(s => s.Charms).Select(s => s.CharmId).ToList();
            var charms = await charmQueryService.GetRawByIdsAsync(charmsIds);

            // Get enabled product category discounts
            var enabledDiscounts = await productCategoryDiscountQueryService.GetRawEnabledAsync();

            // Get shipment
            var shipments = await shipmentQueryService.GetAsync(request.ShipmentId);

            var codePromoValue = await orderDiscountQueryService.GetValueByCodeAsync(request.PromoCode);

            // Apply discounts to products
            var productsWithDiscount =
                productCategoryDiscountQueryService.ApplyDiscountsToProducts(products, enabledDiscounts);



            // If charms exists - build product order charm
            // Build product orders


            throw new NotImplementedException();
        }
    }
}
