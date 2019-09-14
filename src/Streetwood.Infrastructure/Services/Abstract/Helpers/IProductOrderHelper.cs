using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Models;

namespace Streetwood.Infrastructure.Services.Abstract.Helpers
{
    public interface IProductOrderHelper
    {
        ApplyCharmsToProductOrderResult ApplyCharmsToProductOrder(
            ProductOrder productOrder, ProductWithCharmsOrderDto productWithCharmsOrder, IList<Charm> charms, decimal finalPrice);
    }
}