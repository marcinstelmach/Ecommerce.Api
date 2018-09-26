using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class ShippmentConfiguration : IEntityTypeConfiguration<Shippment>
    {
        public void Configure(EntityTypeBuilder<Shippment> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s => s.NameEng).HasMaxLength(50);

            builder.HasMany(s => s.Orders)
                .WithOne(s => s.Shippment);
        }
    }
}
