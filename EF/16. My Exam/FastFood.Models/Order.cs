namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;

    using FastFood.Models.Enums;
    using System.Linq;

    public class Order
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        //Id – integer, Primary Key
        public int Id { get; set; }

        //Customer – text(required)
        public string Customer { get; set; }

        //DateTime – date and time of the order(required)
        public DateTime DateTime { get; set; }

        //Type – OrderType enumeration with possible values: “ForHere, ToGo(default: ForHere)” (required)
        public OrderType Type { get; set; } = OrderType.ForHere;

        //TotalPrice – decimal value(calculated property, (not mapped to database), required)
        private decimal totalPrice;
        public decimal TotalPrice
        {
            get
            {
                return this.totalPrice;
            }
            set
            {
                this.totalPrice = this.OrderItems.Select(x => x.Item.Price * x.Quantity).Sum();
            }
        }


        //EmployeeId – integer, foreign key
        public int EmployeeId { get; set; }

        //Employee – The employee who will process the order(required)
        public Employee Employee { get; set; }

        //OrderItems – collection of type OrderItem
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}