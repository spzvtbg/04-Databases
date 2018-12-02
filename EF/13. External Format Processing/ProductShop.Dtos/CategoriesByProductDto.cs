namespace ProductShop.Dtos
{
    using System.Collections.Generic;

    public class CategoriesByProductDto
    {
        public string category { get; set; }

        public int productsCount { get; set; }

        public decimal averagePrice { get; set; }

        public decimal totalRevenue { get; set; }
    }
}
