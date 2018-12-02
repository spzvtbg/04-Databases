namespace ProductShop.Dtos
{
    using System.Collections.Generic;

    public class SuccessfullySelledProductDto
    {
        public SuccessfullySelledProductDto()
        {
            this.soldProducts = new List<SoldProductsDto>().ToArray();
        }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public SoldProductsDto[] soldProducts { get; set; }
    }

    public class SoldProductsDto
    {
        public string name { get; set; }

        public decimal price { get; set; }

        public string buyerFirstName { get; set; }

        public string buyerLastName { get; set; }
    }
}
