namespace BookShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.CategoryBooks = new List<BookCategory>();
        }

        public ICollection<BookCategory> CategoryBooks { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }
    }
}
