namespace Instagraph.Data.MondelsConfigs
{
    using Instagraph.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(u => u.Id);

            user.Property(u => u.Username).IsRequired(true).HasColumnType("nvarchar(30)");

            user.Property(u => u.Password).IsRequired(true).HasColumnType("nvarchar(20)");
        }
    }
}
