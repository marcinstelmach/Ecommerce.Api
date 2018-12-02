using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class DiscountCategoryConfiguration : IEntityTypeConfiguration<DiscountCategory>
    {
        public void Configure(EntityTypeBuilder<DiscountCategory> builder)
        {
            builder.HasOne(s => s.ProductCategory)
                .WithMany(s => s.DiscountCategories)
                .HasForeignKey("ProductCategoryId");

            builder.HasOne(s => s.ProductCategoryDiscount)
                .WithMany(s => s.DiscountCategories)
                .HasForeignKey("ProductCategoryDiscountId");
        }
    }
}
