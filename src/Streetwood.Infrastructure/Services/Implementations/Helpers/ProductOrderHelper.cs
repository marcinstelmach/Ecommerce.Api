using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Services.Abstract.Helpers;

namespace Streetwood.Infrastructure.Services.Implementations.Helpers
{
    public class ProductOrderHelper : IProductOrderHelper
    {
        public ProductOrder ApplyCharmsToProductOrder(ProductOrder productOrder)
        {
            if (!productOrder.Product.AcceptCharms)
            {
                throw new StreetwoodException(ErrorCode.ProductNotAcceptCharms);
            }

            return productOrder;
        }
    }
}