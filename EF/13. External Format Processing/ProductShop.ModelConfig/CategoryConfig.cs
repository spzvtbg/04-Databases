namespace ProductShop.ModelConfig
{
    using ProductShop.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.HasKey(e => e.CategoryId);

            category.Property(e => e.CategoryName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(25);
        }
    }
}
