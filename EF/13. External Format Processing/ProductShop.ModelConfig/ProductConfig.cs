namespace ProductShop.ModelConfig
{
    using ProductShop.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product.HasKey(e => e.ProductId);

            product.Property(e => e.ProductName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(125);

            product.Property(e => e.ProductPrice)
                .IsRequired(true)
                .HasColumnType("decimal(18, 2)");

            product.HasOne(e => e.ProductBuyer)
                .WithMany(u => u.ProductsBuyed)
                .HasForeignKey(e => e.ProductBuyerId);

            product.HasOne(e => e.ProductSeller)
                .WithMany(u => u.ProductsSelled)
                .HasForeignKey(e => e.ProductSellerId);
        }
    }
}
