namespace FastFood.Data.ModelConfigurations
{
    using FastFood.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> employee)
        {
            employee.HasKey(e => e.Id);

            employee.Property(e => e.Name).IsRequired(true).HasColumnType("nvarchar(30)");

            employee.Property(e => e.Age).IsRequired(true);

            employee
                .HasOne(e => e.Position)
                .WithMany(x => x.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
