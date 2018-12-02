namespace FastFood.Models
{
    using System.Collections.Generic;

    public class Employee
	{
        public Employee()
        {
            this.Orders = new List<Order>();
        }

        //Id – integer, Primary Key
        public int Id { get;  set; }

        //Name – text with min length 3 and max length 30 (required)
        public string Name { get; set; }

        //Age – integer in the range[15, 80] (required)
        public int Age { get; set; }

        //PositionId – integer, foreign key
        public int PositionId { get; set; }

        //Position – the employee’s position(required)
        public Position Position { get; set; }

        //Orders – the orders the employee has processed
        public ICollection<Order> Orders { get; set; }
    }
}