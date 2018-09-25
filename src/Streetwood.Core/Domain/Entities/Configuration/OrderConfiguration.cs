using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasMany(s => s.ProductOrders)
                .WithOne(s => s.Order)
                .HasForeignKey("OrderId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
