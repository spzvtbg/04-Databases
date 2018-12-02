namespace BookShop.Data.ModelConfig
{
    using BookShop.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookCategoryConfig : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> bookCategory)
        {
            bookCategory.HasKey(k => new { k.BookId, k.CategoryId});
        }
    }
}
