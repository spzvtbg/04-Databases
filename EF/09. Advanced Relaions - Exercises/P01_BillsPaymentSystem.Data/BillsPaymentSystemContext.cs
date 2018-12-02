﻿namespace P01_BillsPaymentSystem.Data
{
    using P01_BillsPaymentSystem.Models;
    using P01_BillsPaymentSystem.Data.EntityConfig;

    using Microsoft.EntityFrameworkCore;

    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext() { }

        public BillsPaymentSystemContext(DbContextOptions options) : base(options) { }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder connection)
        {
            if (!connection.IsConfigured)
            {
                //commonConnection
                //connection.UseSqlServer(Configuration.CommonConnection);

                //myConnection
                connection.UseSqlServer(string.Format(Configuration.MyConnection, Configuration.Name));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankAccountConfig());
            modelBuilder.ApplyConfiguration(new CreditCardConfig());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
