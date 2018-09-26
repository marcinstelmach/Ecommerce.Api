using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Streetwood.Core.Domain.Entities.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Product)
                .WithMany(s => s.Images)
                .HasForeignKey("ProductId");
        }
    }
}
