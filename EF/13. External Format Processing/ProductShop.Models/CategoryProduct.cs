namespace ProductShop.Models
{
    public class CategoryProduct
    {
        public CategoryProduct() { }

        public CategoryProduct(int categoryId, int productId)
        {
            this.CategoryId = categoryId;
            this.ProductId = productId;
        }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }


        public int? ProductId { get; set; }

        public Product Product { get; set; }
    }
}
