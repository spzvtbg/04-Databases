namespace ProductShop.Dtos
{
    public class ProductDto
    {
        public string name { get; set; }

        public decimal price { get; set; }

        public int? ProductBuyerId { get; set; }

        public int? ProductSellerId { get; set; }
    }
}
