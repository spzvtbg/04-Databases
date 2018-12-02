namespace BookShop.Data.ModelConfig
{
    using BookShop.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> author)
        {
            author.HasKey(a => a.AuthorId);

            author.Property(fn => fn.FirstName).IsRequired(false).HasMaxLength(50).IsUnicode(true);

            author.Property(ln => ln.LastName).IsRequired(true).HasMaxLength(50).IsUnicode(true);

            author.HasMany(b => b.Books).WithOne(a => a.Author).HasForeignKey(a => a.AuthorId);
        }
    }
}
