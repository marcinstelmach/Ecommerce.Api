using System.Collections.Generic;
using System.Linq;
using Streetwood.Core.Domain.Entities;
using Streetwood.Infrastructure.Dto;
using Streetwood.Infrastructure.Services.Abstract.Commands;

namespace Streetwood.Infrastructure.Services.Implementations.Commands
{
    internal class ProductOrderCharmCommandService : IProductOrderCharmCommandService
    {
        public IList<(ProductOrderCharm, int productId)> Create(IList<ProductWithCharmsOrderDto> ordersDto, IList<Charm> charms)
        {
            var result = new List<(ProductOrderCharm, int)>();

            foreach (var orderDto in ordersDto)
            {
                var charmsIds = orderDto.Charms.Select(s => s.CharmId);
                var orderCharms = charms.Where(s => charmsIds.Contains(s.Id)).ToList();

                if (orderCharms.Any())
                {
                    foreach (var orderCharm in orderCharms)
                    {
                        var charSequence = orderDto.Charms.Single(s => s.CharmId == orderCharm.Id).Sequence;
                        var productOrderCharm = new ProductOrderCharm(orderCharm, charSequence);
                        result.Add((productOrderCharm, orderDto.ProductId));
                    }
                }
            }

            return result;
        }
    }
}