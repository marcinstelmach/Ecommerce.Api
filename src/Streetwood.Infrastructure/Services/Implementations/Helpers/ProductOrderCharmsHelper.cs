using System.Collections.Generic;
using System.Linq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Core.Exceptions;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Helpers;

namespace Streetwood.Infrastructure.Services.Implementations.Helpers
{
    public class ProductOrderCharmsHelper : IProductOrderCharmsHelper
    {
        public IList<ProductOrderCharm> CreateProductOrderCharms(IEnumerable<CharmOrderDto> charmsOrderDto, IList<Charm> charms)
        {
            var productOrderCharms = new List<ProductOrderCharm>();
            foreach (var charmOrder in charmsOrderDto)
            {
                var charm = charms.SingleOrDefault(s => s.Id == charmOrder.CharmId);
                if (charm == null)
                {
                    throw new StreetwoodException(ErrorCode.OrderCharmsNotFound);
                }

                var productOrderCharm = new ProductOrderCharm(charm, charmOrder.Sequence);
                productOrderCharms.Add(productOrderCharm);
            }

            return productOrderCharms.OrderBy(s => s.Sequence).ToList();
        }
    }
}