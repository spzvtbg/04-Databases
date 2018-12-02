namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using P01_BillsPaymentSystem.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BankAccountConfig : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> bankAccount)
        {
            bankAccount.HasKey(ba => ba.BankAccountId);

            bankAccount.Ignore(pm => pm.PaymentMethodId);

            bankAccount.Property(n => n.BankName).IsRequired(true).HasMaxLength(50);

            bankAccount.Property(s => s.SwiftCode).IsRequired(true).IsUnicode(false).HasMaxLength(20);

            bankAccount.Property(b => b.Balance).IsRequired(true).HasDefaultValue(0);
        }
    }
}
