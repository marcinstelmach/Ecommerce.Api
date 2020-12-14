using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streetwood.Core.Constants;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Price)
                .HasColumnType(ConstantValues.PriceDecimalType);

            builder.HasMany(s => s.Images)
                .WithOne(s => s.Product)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.ProductOrders)
                .WithOne(s => s.Product)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.ProductCategory)
                .WithMany(s => s.Products)
                .HasForeignKey(x => x.ProductCategoryId);

            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s => s.NameEng).HasMaxLength(50);
            builder.Property(s => s.Sizes).HasMaxLength(50);
        }
    }
}
