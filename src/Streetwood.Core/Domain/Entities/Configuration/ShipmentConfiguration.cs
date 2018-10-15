using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streetwood.Core.Constants;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s => s.NameEng).HasMaxLength(50);
            builder.Property(s => s.Price)
                .HasColumnType(ConstantValues.PriceDecimalType);

            builder.HasMany(s => s.Orders)
                .WithOne(s => s.Shippment);
        }
    }
}
