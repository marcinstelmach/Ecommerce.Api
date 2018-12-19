using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Commands
{
    public interface IProductOrderCharmCommandService
    {
        IList<(ProductOrderCharm, int productId)> Create(IList<ProductWithCharmsOrderDto> ordersDto, IList<Charm> charms);
    }
}
