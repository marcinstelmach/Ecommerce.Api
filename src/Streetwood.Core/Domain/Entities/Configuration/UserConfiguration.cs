using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasIndex(s => s.Email)
                .IsUnique();
            builder.Property(s => s.Email).HasMaxLength(50);
            builder.Property(s => s.FirstName).HasMaxLength(30);
            builder.Property(s => s.LastName).HasMaxLength(40);
            builder.HasMany(s => s.Orders)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
