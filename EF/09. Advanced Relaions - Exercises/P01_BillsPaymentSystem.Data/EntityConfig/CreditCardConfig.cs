namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using P01_BillsPaymentSystem.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> creditCard)
        {
            creditCard.HasKey(cc => cc.CreditCardId);

            creditCard.Ignore(ll => ll.LimitLeft);

            creditCard.Ignore(pm => pm.PaymentMethodId);

            creditCard.Property(b => b.Limit).HasDefaultValue(0);

            creditCard.Property(mo => mo.MoneyOwed).HasDefaultValue(0);

            creditCard.Property(ed => ed.ExpirationDate).HasColumnType("date");
        }
    }
}
