namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Products = new List<CategoryProduct>();
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ICollection<CategoryProduct> Products { get; set; }
    }
}
