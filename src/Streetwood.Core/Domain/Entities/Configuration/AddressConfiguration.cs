using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.City).HasMaxLength(50);
            builder.Property(s => s.Street).HasMaxLength(50);
            builder.Property(s => s.PostCode).HasMaxLength(8);

            builder.HasOne(s => s.User)
                .WithMany(s => s.Addresses)
                .HasForeignKey("AddressId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
