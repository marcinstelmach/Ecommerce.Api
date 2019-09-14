using System.Collections.Generic;
using System.Linq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Models;
using Streetwood.Infrastructure.Services.Abstract.Helpers;

namespace Streetwood.Infrastructure.Services.Implementations.Helpers
{
    public class ProductOrderHelper : IProductOrderHelper
    {
        private readonly IProductOrderCharmsHelper productOrderCharmsHelper;

        public ProductOrderHelper(IProductOrderCharmsHelper productOrderCharmsHelper)
        {
            this.productOrderCharmsHelper = productOrderCharmsHelper;
        }

        public ApplyCharmsToProductOrderResult ApplyCharmsToProductOrder(
            ProductOrder productOrder, ProductWithCharmsOrderDto productWithCharmsOrder, IList<Charm> charms, decimal finalPrice)
        {
            if (!productOrder.Product.AcceptCharms)
            {
                throw new StreetwoodException(ErrorCode.ProductNotAcceptCharms);
            }

            var productOrderCharms = productOrderCharmsHelper.CreateProductOrderCharms(productWithCharmsOrder.Charms, charms);
            productOrder.AddProductOrderCharms(productOrderCharms);
            var charmsPrice = productOrderCharms.Sum(x => x.CurrentPrice);

            // we subtract one charm, because first is for free
            charmsPrice -= productOrderCharms.First().CurrentPrice;
            finalPrice += charmsPrice;
            productOrder.SetCharmsPrice(charmsPrice);
            return new ApplyCharmsToProductOrderResult(productOrder, finalPrice);
        }
    }
}