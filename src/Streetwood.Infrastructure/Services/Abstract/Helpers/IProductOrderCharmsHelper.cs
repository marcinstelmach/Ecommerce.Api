using System.Collections.Generic;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;

namespace Streetwood.Infrastructure.Services.Abstract.Helpers
{
    public interface IProductOrderCharmsHelper
    {
        IList<ProductOrderCharm> CreateProductOrderCharms(IEnumerable<CharmOrderDto> charmsOrderDto, IList<Charm> charms);
    }
}