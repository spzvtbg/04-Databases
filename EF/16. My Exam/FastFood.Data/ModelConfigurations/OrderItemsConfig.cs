namespace FastFood.Data.ModelConfigurations
{
    using FastFood.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderItemsConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId });

            entity.Property(e => e.Quantity).IsRequired(true);

            entity
                .HasOne(e => e.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity
                .HasOne(e => e.Item)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(e => e.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
