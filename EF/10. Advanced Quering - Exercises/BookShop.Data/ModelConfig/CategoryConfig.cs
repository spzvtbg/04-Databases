namespace BookShop.Data.ModelConfig
{
    using BookShop.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> category)
        {
            category.HasKey(c => c.CategoryId);

            category.Property(n => n.Name).IsRequired(true).IsUnicode(true).HasMaxLength(50);

            category.HasMany(cb => cb.CategoryBooks).WithOne(x => x.Category).HasForeignKey(cb => cb.CategoryId);
        }
    }
}
