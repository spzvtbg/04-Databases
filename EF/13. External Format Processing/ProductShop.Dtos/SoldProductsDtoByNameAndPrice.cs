namespace ProductShop.Dtos
{
    using System.Collections.Generic;

    public class SoldProductsDtoByNameAndPrice
    {
        public SoldProductsDtoByNameAndPrice()
        {
            this.products = new List<ProductDto>();
        }

        public int count { get; set; }

        public ICollection<ProductDto> products { get; set; }
    }
}
