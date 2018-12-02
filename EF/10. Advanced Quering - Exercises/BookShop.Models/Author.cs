namespace BookShop.Models
{
    using System.Collections.Generic;

    public class Author
    {
        public Author()
        {
            this.Books = new List<Book>();
        }

        public ICollection<Book> Books { get; set; }

        public int AuthorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
