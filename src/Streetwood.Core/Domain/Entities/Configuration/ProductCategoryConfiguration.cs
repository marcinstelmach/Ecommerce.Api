using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(30);

            builder.HasMany(s => s.Products)
                .WithOne(s => s.ProductCategory)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.ProductCategoryDiscount)
                .WithMany(s => s.ProductCategories)
                .HasForeignKey("ProductCategoryDiscountId");
        }
    }
}
