using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class ProductCategoryDiscountConfiguration : IEntityTypeConfiguration<ProductCategoryDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryDiscount> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.DiscountCategories)
                .WithOne(s => s.ProductCategoryDiscount);

            builder.Property(s => s.Name).HasMaxLength(30);
            builder.Property(s => s.NameEng).HasMaxLength(30);
        }
    }
}
