namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using P01_BillsPaymentSystem.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(u => u.UserId);

            user.Property(fn => fn.FirstName).IsRequired(true).HasMaxLength(50);

            user.Property(ln => ln.LastName).IsRequired(true).HasMaxLength(50);

            user.Property(em => em.Email).IsRequired(true).IsUnicode(false).HasMaxLength(80);

            user.Property(p => p.Password).IsRequired(true).IsUnicode(false).HasMaxLength(25);
        }
    }
}
