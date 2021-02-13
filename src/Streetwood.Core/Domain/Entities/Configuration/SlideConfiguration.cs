namespace Streetwood.Core.Domain.Entities.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text).HasMaxLength(512);
            builder.Property(x => x.TextEng).HasMaxLength(512);
            builder.Property(x => x.ImageUrl).HasMaxLength(256);
        }
    }
}