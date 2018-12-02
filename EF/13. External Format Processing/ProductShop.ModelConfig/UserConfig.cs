namespace ProductShop.ModelConfig
{
    using ProductShop.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(e => e.UserId);

            user.Property(e => e.FirstName)
                .IsRequired(false)
                .IsUnicode(true)
                .HasMaxLength(25);

            user.Property(e => e.LastName)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(25);

            user.Property(e => e.Age).IsRequired(false);
        }
    }
}
