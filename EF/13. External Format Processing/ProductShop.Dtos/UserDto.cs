namespace ProductShop.Dtos
{
    using System.Collections.Generic;

    public class UserDto
    {
        public UserDto()
        {
            this.soldProducts = new List<SoldProductsDtoByNameAndPrice>();
        }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int? age { get; set; }

        public ICollection<SoldProductsDtoByNameAndPrice> soldProducts { get; set; }
    }
}
