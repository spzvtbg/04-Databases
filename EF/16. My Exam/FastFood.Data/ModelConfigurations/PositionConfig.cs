namespace FastFood.Data.ModelConfigurations
{
    using FastFood.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> position)
        {
            position.HasKey(p => p.Id);

            position.Property(p => p.Name).IsRequired(true);

            position.HasIndex(p => p.Name).IsUnique(true);
        }
    }
}
