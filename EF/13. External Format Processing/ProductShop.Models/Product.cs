namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.Categories = new List<CategoryProduct>();
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }


        public int? ProductBuyerId { get; set; }

        public User ProductBuyer { get; set; }


        public int? ProductSellerId { get; set; }

        public User ProductSeller { get; set; }


        public ICollection<CategoryProduct> Categories { get; set; }
    }
}
