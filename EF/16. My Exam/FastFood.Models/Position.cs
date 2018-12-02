namespace FastFood.Models
{
    using System.Collections.Generic;

    public class Position
    {
        //Id – integer, Primary Key
        public int Id { get; set; }

        //Name – text with min length 3 and max length 30 (required, unique)
        public string Name { get; set; }

        //Employees – Collection of type Employee
        public ICollection<Employee> Employees { get; set; }
    }
}