namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User()
        {
            this.ProductsBuyed = new List<Product>();

            this.ProductsSelled = new List<Product>();
        }

        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ICollection<Product> ProductsBuyed { get; set; }

        public ICollection<Product> ProductsSelled { get; set; }
    }
}
