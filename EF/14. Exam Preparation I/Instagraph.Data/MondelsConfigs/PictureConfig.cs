namespace Instagraph.Data.MondelsConfigs
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> picture)
        {
            picture.HasKey(p => p.Id);

            picture.Property(p => p.Path).IsRequired(true);

            picture.Property(p => p.Size).IsRequired(true).HasColumnType("decimal(20,4)");
        }
    }
}
