namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using P01_BillsPaymentSystem.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> paymentMethod)
        {
            paymentMethod.HasKey(pm => pm.Id);

            paymentMethod.HasIndex(i => new { i.UserId, i.BankAccountId, i.CreditCardId }).IsUnique(true);

            paymentMethod.HasOne(u => u.User).WithMany(pm => pm.PaymentMethods).HasForeignKey(u => u.UserId);

            paymentMethod.HasOne(ba => ba.BankAccount).WithOne(pm => pm.PaymentMethod)
                .HasForeignKey<PaymentMethod>(ba => ba.BankAccountId);

            paymentMethod.HasOne(cc => cc.CreditCard).WithOne(pm => pm.PaymentMethod)
                .HasForeignKey<PaymentMethod>(cc => cc.CreditCardId);//?
        }
    }
}
