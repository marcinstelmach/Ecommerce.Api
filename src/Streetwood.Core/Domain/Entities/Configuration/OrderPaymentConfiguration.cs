namespace Streetwood.Core.Domain.Entities.Configuration
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderPaymentConfiguration : IEntityTypeConfiguration<OrderPayment>
    {
        public void Configure(EntityTypeBuilder<OrderPayment> builder)
        {
            builder.ToTable("OrderPayments");

            builder.Property<int>("OrderId");
            builder.Property<Guid>("PaymentId");

            builder.HasKey("PaymentId", "OrderId");
            builder.HasOne(x => x.Payment)
                .WithMany()
                .HasForeignKey("PaymentId");
        }
    }
}