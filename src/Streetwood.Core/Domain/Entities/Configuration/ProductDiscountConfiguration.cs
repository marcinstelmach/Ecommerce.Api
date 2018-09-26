using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class ProductDiscountConfiguration : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Products)
                .WithOne(s => s.ProductDiscount)
                .HasForeignKey("ProductDiscountId");

            builder.Property(s => s.Name).HasMaxLength(30);
            builder.Property(s => s.NameEng).HasMaxLength(30);
        }
    }
}
