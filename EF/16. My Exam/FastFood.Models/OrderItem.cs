namespace FastFood.Models
{
    public class OrderItem
    {
        //OrderId – integer, Primary Key
        public int OrderId { get; set; }

        //Order – the item’s order(required)
        public Order Order { get; set; }

        //ItemId – integer, Primary Key
        public int ItemId { get; set; }

        //Item – the order’s item(required)
        public Item Item { get; set; }

        //Quantity – the quantity of the item in the order(required, non-negative and non-zero)
        public int Quantity { get; set; }
    }
}