namespace BookShop.Data.ModelConfig
{
    using BookShop.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> book)
        {
            book.HasKey(b => b.BookId);

            book.Property(t => t.Title).IsRequired(true).IsUnicode(true).HasMaxLength(50);

            book.Property(d => d.Description).IsRequired(true).IsUnicode(true).HasMaxLength(1000);

            book.Property(rd => rd.ReleaseDate).IsRequired(false).HasColumnType("date");

            book.Property(c => c.Copies).IsRequired(true).HasColumnType("int");

            book.Property(p => p.Price).IsRequired(true).HasColumnType("decimal");

            book.Property(et => et.EditionType).IsRequired(true).HasColumnType("int");

            book.Property(ar => ar.AgeRestriction).IsRequired(true).HasColumnType("int");

            book.HasOne(a => a.Author).WithMany(b => b.Books).HasForeignKey(a => a.AuthorId);
        }
    }
}
