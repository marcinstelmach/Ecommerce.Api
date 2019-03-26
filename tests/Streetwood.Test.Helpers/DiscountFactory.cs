using System;
using Streetwood.Core.Domain.Entities;

namespace Streetwood.Test.Helpers
{
    public class DiscountFactory
    {
        public static OrderDiscount GetOrderDiscount()
        {
            return new OrderDiscount("Discount", "Discount eng", "Description", 
                "Description Eng", 35, DateTime.Now,
                DateTime.Now.AddDays(5), "DISCOUNT");
        }

        public static ProductCategoryDiscount GetProductCategoryDiscount()
        {
            return new ProductCategoryDiscount("CategoryDiscount", "CategoryDiscount Eng", 
                "Description", "Desc", 25, 
                DateTime.Now, DateTime.Now.AddDays(5));
        }
    }
}
