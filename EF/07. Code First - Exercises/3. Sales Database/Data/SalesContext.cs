namespace P03_SalesDatabase
{
    using Microsoft.EntityFrameworkCore;

    using P03_SalesDatabase.Data.Context;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext() { }

        public SalesContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ContextConfiguring.Connection(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ContextModeling.Store(modelBuilder);

            ContextModeling.Product(modelBuilder);

            ContextModeling.Customer(modelBuilder);

            ContextModeling.Sale(modelBuilder);
        }
    }
}
