namespace FastFood.Data.ModelConfigurations
{
    using FastFood.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> item)
        {
            item.HasKey(i => i.Id);

            item.Property(i => i.Name).IsRequired(true).HasColumnType("nvarchar(30)");

            item.HasIndex(i => i.Name).IsUnique(true);

            item
                .HasOne(i => i.Category)
                .WithMany(x => x.Items)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
