namespace ProductShop.ModelConfig
{
    using ProductShop.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryProductConfig : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> map)
        {
            map.HasKey(e => new { e.CategoryId, e.ProductId });

            map.HasOne(e => e.Product)
                .WithMany(c => c.Categories)
                .HasForeignKey(e => e.ProductId);

            map.HasOne(e => e.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}
