using Streetwood.Core.Domain.Entities;

namespace Streetwood.Infrastructure.Services.Abstract.Helpers
{
    public interface IProductOrderHelper
    {
        ProductOrder ApplyCharmsToProductOrder(ProductOrder productOrder);
    }
}