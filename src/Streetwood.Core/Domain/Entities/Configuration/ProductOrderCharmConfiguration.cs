using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class ProductOrderCharmConfiguration : IEntityTypeConfiguration<ProductOrderCharm>
    {
        public void Configure(EntityTypeBuilder<ProductOrderCharm> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.ProductOrder)
                .WithMany(s => s.ProductOrderCharms)
                .HasForeignKey("ProductOrderId");

            builder.HasOne(s => s.Charm)
                .WithMany(s => s.ProductOrderCharms)
                .HasForeignKey("CharmId");
        }
    }
}
