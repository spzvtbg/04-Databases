namespace FastFood.Models
{
    using System.Collections.Generic;

    public class Item
    {
        public Item()
        {
            this.OrderItems = new List<OrderItem>();
        }

        //Id – integer, Primary Key
        public int Id { get; set; }

        //Name – text with min length 3 and max length 30 (required, unique)
        public string Name { get; set; }

        //CategoryId – integer, foreign key
        public int CategoryId { get; set; }

        //Category – the item’s category(required)
        public Category Category { get; set; }

        //Price – decimal (non-negative, minimum value: 0.01, required)
        public decimal Price { get; set; }

        //OrderItems – collection of type OrderItem
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}