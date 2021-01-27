namespace Streetwood.Core.Domain.Entities.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Streetwood.Core.Domain.Enums;

    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.Id);

            builder.HasDiscriminator(x => x.PaymentType)
                .HasValue<BankTransferPayment>(PaymentType.BankTransfer);
        }
    }
}