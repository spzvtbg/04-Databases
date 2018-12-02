namespace FastFood.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Items = new List<Item>();
        }

        //Id – integer, Primary Key
        public int Id { get; set; }

        //Name – text with min length 3 and max length 30 (required)
        public string Name { get; set; }

        //Items – collection of type Item
        public ICollection<Item> Items { get; set; }
    }
}