namespace P03_SalesDatabase.Data.Context
{
    using Microsoft.EntityFrameworkCore;

    using P03_SalesDatabase.Data.Models;

    public class ContextModeling
    {
        public static void Product(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);

                entity.Property(n => n.Name)
                .IsUnicode(true)
                .HasMaxLength(50);

                //entity.Property(n => n.Description)
                //.IsUnicode(true)
                //.HasMaxLength(250);

                entity.Property(q => q.Quantity)
                .IsRequired();

                entity.Property(p => p.Price)
                .HasColumnType("DECIMAL");
            });
        }

        public static void Customer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);

                entity.Property(n => n.Name)
                .IsUnicode(true)
                .HasMaxLength(100);

                entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasMaxLength(80);

                entity.Property(ccn => ccn.CreditCardNumber)
                .IsUnicode(false);
            });
        }

        public static void Store(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(s => s.StoreId);

                entity.Property(n => n.Name)
                .IsUnicode(true)
                .HasMaxLength(80);
            });
        }

        public static void Sale(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.SaleId);

                entity.Property(d => d.Date)
                .IsRequired()
                /*.HasDefaultValueSql("GETDATE()")*/;

                entity.HasOne(p => p.Product)
                .WithMany(s => s.Sales)
                .HasForeignKey(p => p.ProductId);

                entity.HasOne(c => c.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(c => c.CustomerId);

                entity.HasOne(s => s.Store)
                .WithMany(ss => ss.Sales)
                .HasForeignKey(s => s.StoreId);
            });
        }
    }
}
