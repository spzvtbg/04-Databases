namespace ProductShop.Data
{
    using ProductShop.Models;
    using ProductShop.ModelConfig;

    using Microsoft.EntityFrameworkCore;

    public class ProductShopDbContext : DbContext
    {
        public ProductShopDbContext() { }

        public ProductShopDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryProduct> CategoriesProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConnectionProvider.CreateConection(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());

            modelBuilder.ApplyConfiguration(new CategoryProductConfig());

            modelBuilder.ApplyConfiguration(new ProductConfig());

            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
