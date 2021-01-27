namespace Streetwood.Core.Domain.Entities.Configuration
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderShipmentConfiguration : IEntityTypeConfiguration<OrderShipment>
    {
        public void Configure(EntityTypeBuilder<OrderShipment> builder)
        {
            builder.ToTable("OrderShipments");

            builder.Property<int>("OrderId");
            builder.Property<Guid>("ShipmentId");
            builder.HasKey("ShipmentId", "OrderId");

            builder.HasOne(x => x.Shipment)
                .WithMany()
                .HasForeignKey("ShipmentId");
        }
    }
}