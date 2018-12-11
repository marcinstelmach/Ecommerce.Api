using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class OrderDiscountConfiguration : IEntityTypeConfiguration<OrderDiscount>
    {
        public void Configure(EntityTypeBuilder<OrderDiscount> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Orders)
                .WithOne(s => s.OrderDiscount);

            builder.Property(s => s.Name).HasMaxLength(30);
            builder.Property(s => s.NameEng).HasMaxLength(30);
            builder.Property(s => s.Code).HasMaxLength(30);
        }
    }
}
