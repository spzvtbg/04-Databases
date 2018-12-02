namespace Emploies.Data
{
    using Emploies.Connection;
    using Emploies.Models;

    using Microsoft.EntityFrameworkCore;

    public class EmploiesContext : DbContext
    {
        public EmploiesContext() { }

        public EmploiesContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Emploies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionStrings.Own);
                //optionsBuilder.UseSqlServer(ConnectionStrings.CommonConnectionSetings);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity => {

                entity.HasKey(k => k.ID);

                entity.Property(n => n.FirstName).IsRequired(true);

                entity.Property(n => n.Surname).IsRequired(true);

                entity.Property(n => n.Salary).IsRequired(true);

                entity
                .HasMany(e => e.ManagedEmploies)
                .WithOne(m => m.Manager)
                .HasForeignKey(m => m.ManagerID);
            });
        }
    }
}
