using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class CharmCategoryConfiguration : IEntityTypeConfiguration<CharmCategory>
    {
        public void Configure(EntityTypeBuilder<CharmCategory> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Charms)
                .WithOne(s => s.CharmCategory)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
