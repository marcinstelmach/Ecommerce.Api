using System.Collections.Generic;
using System.Linq;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class ProductOrderCharmsFactory
    {
        public static ProductOrderCharm GetProductOrderCharm() 
            => new ProductOrderCharm(CharmFactory.GetCharm(), 1);

        public static IEnumerable<ProductOrderCharm> GetProductOrderCharms(int count)
        {
            var index = 1;
            var result = CharmFactory.GetCharms(count)
                .Select(s => new ProductOrderCharm(s, index++));
            return result;
        }
    }
}
