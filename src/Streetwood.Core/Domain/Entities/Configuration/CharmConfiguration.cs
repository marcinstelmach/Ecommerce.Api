using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class CharmConfiguration : IEntityTypeConfiguration<Charm>
    {
        public void Configure(EntityTypeBuilder<Charm> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s => s.NameEng).HasMaxLength(50);

            builder.HasOne(s => s.CharmCategory)
                .WithMany(s => s.Charms)
                .HasForeignKey("CharmCategoryId");

            builder.HasMany(s => s.ProductOrderCharms)
                .WithOne(s => s.Charm);
        }
    }
}
