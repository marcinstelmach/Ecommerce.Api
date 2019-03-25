using System.Collections.Generic;
using System.Linq;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class ProductOrderCharmsHelper
    {
        public static ProductOrderCharm GetProductOrderCharms() 
            => new ProductOrderCharm(CharmHelper.CreateCharms(1).First(), 1);

        public static IEnumerable<ProductOrderCharm> GetMultipleProductOrderCharms(int count)
        {
            var index = 1;
            var result = CharmHelper.CreateCharms(count)
                .Select(s => new ProductOrderCharm(s, index++));
            return result;
        }
    }
}
