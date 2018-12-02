namespace FastFood.Data.ModelConfigurations
{
    using FastFood.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            order.HasKey(o => o.Id);

            order.Property(o => o.Customer).IsRequired(true);

            order.Property(o => o.DateTime).IsRequired(true);

            order
                .HasOne(o => o.Employee)
                .WithMany(x => x.Orders)
                .HasForeignKey(o => o.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
